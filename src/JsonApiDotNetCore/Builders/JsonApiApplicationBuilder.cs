using System;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Data;
using JsonApiDotNetCore.Formatters;
using JsonApiDotNetCore.Graph;
using JsonApiDotNetCore.Internal;
using JsonApiDotNetCore.Internal.Generics;
using JsonApiDotNetCore.Middleware;
using JsonApiDotNetCore.Models;
using JsonApiDotNetCore.Serialization;
using JsonApiDotNetCore.Hooks;
using JsonApiDotNetCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JsonApiDotNetCore.Internal.Contracts;
using JsonApiDotNetCore.Internal.Queries;
using JsonApiDotNetCore.Internal.QueryStrings;
using JsonApiDotNetCore.Queries;
using JsonApiDotNetCore.QueryStrings;
using JsonApiDotNetCore.Serialization.Server.Builders;
using JsonApiDotNetCore.Serialization.Server;
using Microsoft.Extensions.DependencyInjection.Extensions;
using JsonApiDotNetCore.RequestServices;
using JsonApiDotNetCore.RequestServices.Contracts;
using JsonApiDotNetCore.Services.Contract;

namespace JsonApiDotNetCore.Builders
{
    /// <summary>
    /// A utility class that builds a JsonApi application. It registers all required services
    /// and allows the user to override parts of the startup configuration.
    /// </summary>
    internal sealed class JsonApiApplicationBuilder
    {
        private readonly JsonApiOptions _options = new JsonApiOptions();
        private readonly IServiceCollection _services;
        private IServiceDiscoveryFacade _serviceDiscoveryFacade;
        private IResourceGraphBuilder _resourceGraphBuilder;
        private readonly IMvcCoreBuilder _mvcBuilder;

        public JsonApiApplicationBuilder(IServiceCollection services,
            IMvcCoreBuilder mvcBuilder)
        {
            _services = services;
            _mvcBuilder = mvcBuilder;
        }

        /// <summary>
        /// Executes the action provided by the user to configure <see cref="JsonApiOptions"/>
        /// </summary>
        public void ConfigureJsonApiOptions(Action<JsonApiOptions> configureOptions)
        {
            configureOptions?.Invoke(_options);
        }
        
        /// <summary>
        /// Configures built-in .NET Core MVC (things like middleware, routing). Most of this configuration can be adjusted for the developers' need.
        /// Before calling .AddJsonApi(), a developer can register their own implementation of the following services to customize startup:
        /// <see cref="IResourceGraphBuilder"/>, <see cref="IServiceDiscoveryFacade"/>, <see cref="IJsonApiExceptionFilterProvider"/>,
        /// <see cref="IJsonApiTypeMatchFilterProvider"/> and <see cref="IJsonApiRoutingConvention"/>.
        /// </summary>
        public void ConfigureMvc()
        {
            IJsonApiExceptionFilterProvider exceptionFilterProvider;
            IJsonApiTypeMatchFilterProvider typeMatchFilterProvider;
            IJsonApiRoutingConvention routingConvention;
            
            using (var intermediateProvider = _services.BuildServiceProvider())
            {
                exceptionFilterProvider = intermediateProvider.GetRequiredService<IJsonApiExceptionFilterProvider>();
                typeMatchFilterProvider = intermediateProvider.GetRequiredService<IJsonApiTypeMatchFilterProvider>();
                routingConvention = intermediateProvider.GetRequiredService<IJsonApiRoutingConvention>();
                _services.AddSingleton<IControllerResourceMapping>(routingConvention);
            }
            
            _mvcBuilder.AddMvcOptions(options =>
            {
                options.EnableEndpointRouting = true;
                options.Filters.Add(exceptionFilterProvider.Get());
                options.Filters.Add(typeMatchFilterProvider.Get());
                options.Filters.Add(new ConvertEmptyActionResultFilter());
                options.InputFormatters.Insert(0, new JsonApiInputFormatter());
                options.OutputFormatters.Insert(0, new JsonApiOutputFormatter());
                options.Conventions.Insert(0, routingConvention);
            });

            if (_options.ValidateModelState)
            {
                _mvcBuilder.AddDataAnnotations();
            }
        }

        /// <summary>
        /// Configures and build the resource graph with resources from the provided sources and adds it to the DI container. 
        /// </summary>
        public void AddResourceGraph(Type dbContextType, Action<IResourceGraphBuilder> configureResources)
        {
            using var intermediateProvider = _services.BuildServiceProvider();
            AutoDiscoverResources(_serviceDiscoveryFacade);
            AddResourcesFromDbContext(dbContextType, intermediateProvider, _resourceGraphBuilder);
            UserConfigureResources(configureResources, _resourceGraphBuilder);
            _services.AddSingleton(_resourceGraphBuilder.Build());
        }
        
        public void ConfigureAutoDiscovery(Action<IServiceDiscoveryFacade> configureAutoDiscovery)
        {
            using var intermediateProvider = _services.BuildServiceProvider();
            _serviceDiscoveryFacade = intermediateProvider.GetRequiredService<IServiceDiscoveryFacade>();
            _resourceGraphBuilder = intermediateProvider.GetRequiredService<IResourceGraphBuilder>();
            RegisterDiscoverableAssemblies(configureAutoDiscovery, _serviceDiscoveryFacade);
        }
        
        private void RegisterDiscoverableAssemblies(Action<IServiceDiscoveryFacade> configureAutoDiscovery, IServiceDiscoveryFacade serviceDiscoveryFacade)
        {
            configureAutoDiscovery?.Invoke(serviceDiscoveryFacade);
        }
        
        /// <summary>
        /// Registers the remaining internals.
        /// </summary>
        public void ConfigureServices(Type dbContextType)
        {
            if (dbContextType != null)
            {
                var contextResolverType = typeof(DbContextResolver<>).MakeGenericType(dbContextType);
                _services.TryAddScoped(typeof(IDbContextResolver), contextResolverType);
            }
            else
            {
                _services.AddScoped<DbContext>();
                _services.AddSingleton(new DbContextOptionsBuilder().Options);
            }

            AddRepositoryLayer();
            AddServiceLayer();

            _services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            _services.AddSingleton<IResourceContextProvider>(sp => sp.GetRequiredService<IResourceGraph>());
            _services.AddSingleton<IExceptionHandler, ExceptionHandler>();

            _services.AddScoped<ICurrentRequest, CurrentRequest>();
            _services.AddScoped<IScopedServiceProvider, RequestScopedServiceProvider>();
            _services.AddScoped<IJsonApiWriter, JsonApiWriter>();
            _services.AddScoped<IJsonApiReader, JsonApiReader>();
            _services.AddScoped<IGenericServiceFactory, GenericServiceFactory>();
            _services.AddScoped(typeof(RepositoryRelationshipUpdateHelper<>));
            _services.AddScoped<ITargetedFields, TargetedFields>();
            _services.AddScoped<IResourceDefinitionProvider, ResourceDefinitionProvider>();
            _services.AddScoped<IFieldsToSerialize, FieldsToSerialize>();
            _services.AddScoped(typeof(IResourceChangeTracker<>), typeof(ResourceChangeTracker<>));
            _services.AddScoped<IResourceFactory, ResourceFactory>();
            _services.AddScoped<IPaginationContext, PaginationContext>();
            _services.AddScoped<IQueryLayerComposer, QueryLayerComposer>();

            AddServerSerialization();
            AddQueryStringParameterServices();
            if (_options.EnableResourceHooks)
            {
                AddResourceHooks();
            }

            _services.AddScoped<IInverseRelationships, InverseRelationships>();
        }

        /// <summary>
        /// Discovers DI registrable services in the assemblies marked for discovery.
        /// </summary>
        public void DiscoverServices()
        {
            _serviceDiscoveryFacade.DiscoverServices();
        }

        private void AddRepositoryLayer()
        {
            _services.AddScoped(typeof(IResourceRepository<>), typeof(EntityFrameworkCoreRepository<>));
            _services.AddScoped(typeof(IResourceRepository<,>), typeof(EntityFrameworkCoreRepository<,>));

            _services.AddScoped(typeof(IResourceReadRepository<,>), typeof(EntityFrameworkCoreRepository<,>));
            _services.AddScoped(typeof(IResourceWriteRepository<,>), typeof(EntityFrameworkCoreRepository<,>));
        }

        private void AddServiceLayer()
        {
            _services.AddScoped(typeof(ICreateService<>), typeof(JsonApiResourceService<>));
            _services.AddScoped(typeof(ICreateService<,>), typeof(JsonApiResourceService<,>));

            _services.AddScoped(typeof(IGetAllService<>), typeof(JsonApiResourceService<>));
            _services.AddScoped(typeof(IGetAllService<,>), typeof(JsonApiResourceService<,>));

            _services.AddScoped(typeof(IGetByIdService<>), typeof(JsonApiResourceService<>));
            _services.AddScoped(typeof(IGetByIdService<,>), typeof(JsonApiResourceService<,>));

            _services.AddScoped(typeof(IGetRelationshipService<>), typeof(JsonApiResourceService<>));
            _services.AddScoped(typeof(IGetRelationshipService<,>), typeof(JsonApiResourceService<,>));

            _services.AddScoped(typeof(IGetSecondaryService<>), typeof(JsonApiResourceService<>));
            _services.AddScoped(typeof(IGetSecondaryService<,>), typeof(JsonApiResourceService<,>));

            _services.AddScoped(typeof(IUpdateService<>), typeof(JsonApiResourceService<>));
            _services.AddScoped(typeof(IUpdateService<,>), typeof(JsonApiResourceService<,>));

            _services.AddScoped(typeof(IDeleteService<>), typeof(JsonApiResourceService<>));
            _services.AddScoped(typeof(IDeleteService<,>), typeof(JsonApiResourceService<,>));

            _services.AddScoped(typeof(IResourceService<>), typeof(JsonApiResourceService<>));
            _services.AddScoped(typeof(IResourceService<,>), typeof(JsonApiResourceService<,>));

            _services.AddScoped(typeof(IResourceQueryService<,>), typeof(JsonApiResourceService<,>));
            _services.AddScoped(typeof(IResourceCommandService<,>), typeof(JsonApiResourceService<,>));
        }

        private void AddQueryStringParameterServices()
        {
            _services.AddScoped<IIncludeQueryStringParameterReader, IncludeQueryStringParameterReader>();
            _services.AddScoped<IFilterQueryStringParameterReader, FilterQueryStringParameterReader>();
            _services.AddScoped<ISortQueryStringParameterReader, SortQueryStringParameterReader>();
            _services.AddScoped<ISparseFieldSetQueryStringParameterReader, SparseFieldSetQueryStringParameterReader>();
            _services.AddScoped<IPaginationQueryStringParameterReader, PaginationQueryStringParameterReader>();
            _services.AddScoped<IDefaultsQueryStringParameterReader, DefaultsQueryStringParameterReader>();
            _services.AddScoped<INullsQueryStringParameterReader, NullsQueryStringParameterReader>();
            _services.AddScoped<IResourceDefinitionQueryableParameterReader, ResourceDefinitionQueryableParameterReader>();

            _services.AddScoped<IQueryStringParameterReader>(sp => sp.GetService<IIncludeQueryStringParameterReader>());
            _services.AddScoped<IQueryStringParameterReader>(sp => sp.GetService<IFilterQueryStringParameterReader>());
            _services.AddScoped<IQueryStringParameterReader>(sp => sp.GetService<ISortQueryStringParameterReader>());
            _services.AddScoped<IQueryStringParameterReader>(sp => sp.GetService<ISparseFieldSetQueryStringParameterReader>());
            _services.AddScoped<IQueryStringParameterReader>(sp => sp.GetService<IPaginationQueryStringParameterReader>());
            _services.AddScoped<IQueryStringParameterReader>(sp => sp.GetService<IDefaultsQueryStringParameterReader>());
            _services.AddScoped<IQueryStringParameterReader>(sp => sp.GetService<INullsQueryStringParameterReader>());
            _services.AddScoped<IQueryStringParameterReader>(sp => sp.GetService<IResourceDefinitionQueryableParameterReader>());

            _services.AddScoped<IQueryConstraintProvider>(sp => sp.GetService<IIncludeQueryStringParameterReader>());
            _services.AddScoped<IQueryConstraintProvider>(sp => sp.GetService<IFilterQueryStringParameterReader>());
            _services.AddScoped<IQueryConstraintProvider>(sp => sp.GetService<ISortQueryStringParameterReader>());
            _services.AddScoped<IQueryConstraintProvider>(sp => sp.GetService<ISparseFieldSetQueryStringParameterReader>());
            _services.AddScoped<IQueryConstraintProvider>(sp => sp.GetService<IPaginationQueryStringParameterReader>());
            _services.AddScoped<IQueryConstraintProvider>(sp => sp.GetService<IResourceDefinitionQueryableParameterReader>());

            _services.AddScoped<IQueryStringActionFilter, QueryStringActionFilter>();
            _services.AddScoped<IQueryStringReader, QueryStringReader>();
            _services.AddSingleton<IRequestQueryStringAccessor, RequestQueryStringAccessor>();
        }

        private void AddResourceHooks()
        {
            _services.AddSingleton(typeof(IHooksDiscovery<>), typeof(HooksDiscovery<>));
            _services.AddScoped(typeof(IResourceHookContainer<>), typeof(ResourceDefinition<>));
            _services.AddTransient(typeof(IResourceHookExecutor), typeof(ResourceHookExecutor));
            _services.AddTransient<IHookExecutorHelper, HookExecutorHelper>();
            _services.AddTransient<ITraversalHelper, TraversalHelper>();
        }

        private void AddServerSerialization()
        {
            _services.AddScoped<IIncludedResourceObjectBuilder, IncludedResourceObjectBuilder>();
            _services.AddScoped<IJsonApiDeserializer, RequestDeserializer>();
            _services.AddScoped<IResourceObjectBuilderSettingsProvider, ResourceObjectBuilderSettingsProvider>();
            _services.AddScoped<IJsonApiSerializerFactory, ResponseSerializerFactory>();
            _services.AddScoped<ILinkBuilder, LinkBuilder>();
            _services.AddScoped(typeof(IMetaBuilder<>), typeof(MetaBuilder<>));
            _services.AddScoped(typeof(ResponseSerializer<>));
            _services.AddScoped(sp => sp.GetRequiredService<IJsonApiSerializerFactory>().GetSerializer());
            _services.AddScoped<IResourceObjectBuilder, ResponseResourceObjectBuilder>();
        }

        /// <summary>
        /// Registers services that are required for the configuration of JsonApiDotNetCore during the start up.
        /// </summary>
        public void RegisterJsonApiStartupServices()
        {
            _services.AddSingleton<IJsonApiOptions>(_options);
            _services.TryAddSingleton<IJsonApiRoutingConvention, JsonApiRoutingConvention>();
            _services.TryAddSingleton<IResourceGraphBuilder, ResourceGraphBuilder>();
            _services.TryAddSingleton<IServiceDiscoveryFacade>(sp => new ServiceDiscoveryFacade(_services, sp.GetRequiredService<IResourceGraphBuilder>()));
            _services.TryAddScoped<IJsonApiExceptionFilterProvider, JsonApiExceptionFilterProvider>();
            _services.TryAddScoped<IJsonApiTypeMatchFilterProvider, JsonApiTypeMatchFilterProvider>();
        }
        
        private void AddResourcesFromDbContext(Type dbContextType, ServiceProvider intermediateProvider, IResourceGraphBuilder builder)
        {
            if (dbContextType != null)
            {
                var dbContext = (DbContext) intermediateProvider.GetRequiredService(dbContextType);

                foreach (var entityType in dbContext.Model.GetEntityTypes())
                {
                    builder.AddResource(entityType.ClrType);
                }
            }
        }

        /// <summary>
        /// Performs auto-discovery of JsonApiDotNetCore services.
        /// </summary>
        private void AutoDiscoverResources(IServiceDiscoveryFacade serviceDiscoveryFacade)
        {
            serviceDiscoveryFacade.DiscoverResources();
        }

        /// <summary>
        /// Executes the action provided by the user to configure the resources using <see cref="IResourceGraphBuilder"/>
        /// </summary>
        private void UserConfigureResources(Action<IResourceGraphBuilder> configureResources, IResourceGraphBuilder resourceGraphBuilder)
        {
            configureResources?.Invoke(resourceGraphBuilder);
        }
    }
}
