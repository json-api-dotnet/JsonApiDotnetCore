using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Errors;
using JsonApiDotNetCore.Middleware;
using JsonApiDotNetCore.Queries;
using JsonApiDotNetCore.Queries.Expressions;
using JsonApiDotNetCore.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace JsonApiDotNetCore.Repositories;

/// <inheritdoc cref="IResourceRepositoryAccessor" />
[PublicAPI]
public class ResourceRepositoryAccessor : IResourceRepositoryAccessor
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IResourceGraph _resourceGraph;
    private readonly IJsonApiRequest _request;

    public ResourceRepositoryAccessor(IServiceProvider serviceProvider, IResourceGraph resourceGraph, IJsonApiRequest request)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);
        ArgumentNullException.ThrowIfNull(resourceGraph);
        ArgumentNullException.ThrowIfNull(request);

        _serviceProvider = serviceProvider;
        _resourceGraph = resourceGraph;
        _request = request;
    }

    /// <inheritdoc />
    public ResourceType LookupResourceType(Type resourceClrType)
    {
        ArgumentNullException.ThrowIfNull(resourceClrType);

        return _resourceGraph.GetResourceType(resourceClrType);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<TResource>> GetAsync<TResource>(QueryLayer queryLayer, CancellationToken cancellationToken)
        where TResource : class, IIdentifiable
    {
        ArgumentNullException.ThrowIfNull(queryLayer);

        dynamic repository = ResolveReadRepository(typeof(TResource));
        return (IReadOnlyCollection<TResource>)await repository.GetAsync(queryLayer, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<IIdentifiable>> GetAsync(ResourceType resourceType, QueryLayer queryLayer, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resourceType);
        ArgumentNullException.ThrowIfNull(queryLayer);

        dynamic repository = ResolveReadRepository(resourceType);
        return (IReadOnlyCollection<IIdentifiable>)await repository.GetAsync(queryLayer, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<int> CountAsync(ResourceType resourceType, FilterExpression? filter, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(resourceType);

        dynamic repository = ResolveReadRepository(resourceType);
        return (int)await repository.CountAsync(filter, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<TResource> GetForCreateAsync<TResource, TId>(Type resourceClrType, [DisallowNull] TId id, CancellationToken cancellationToken)
        where TResource : class, IIdentifiable<TId>
    {
        ArgumentNullException.ThrowIfNull(resourceClrType);

        dynamic repository = GetWriteRepository(typeof(TResource));
        return await repository.GetForCreateAsync(resourceClrType, id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task CreateAsync<TResource>(TResource resourceFromRequest, TResource resourceForDatabase, CancellationToken cancellationToken)
        where TResource : class, IIdentifiable
    {
        ArgumentNullException.ThrowIfNull(resourceFromRequest);
        ArgumentNullException.ThrowIfNull(resourceForDatabase);

        dynamic repository = GetWriteRepository(typeof(TResource));
        await repository.CreateAsync(resourceFromRequest, resourceForDatabase, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<TResource?> GetForUpdateAsync<TResource>(QueryLayer queryLayer, CancellationToken cancellationToken)
        where TResource : class, IIdentifiable
    {
        ArgumentNullException.ThrowIfNull(queryLayer);

        dynamic repository = GetWriteRepository(typeof(TResource));
        return await repository.GetForUpdateAsync(queryLayer, cancellationToken);
    }

    /// <inheritdoc />
    public async Task UpdateAsync<TResource>(TResource resourceFromRequest, TResource resourceFromDatabase, CancellationToken cancellationToken)
        where TResource : class, IIdentifiable
    {
        ArgumentNullException.ThrowIfNull(resourceFromRequest);
        ArgumentNullException.ThrowIfNull(resourceFromDatabase);

        dynamic repository = GetWriteRepository(typeof(TResource));
        await repository.UpdateAsync(resourceFromRequest, resourceFromDatabase, cancellationToken);
    }

    /// <inheritdoc />
    public async Task DeleteAsync<TResource, TId>(TResource? resourceFromDatabase, [DisallowNull] TId id, CancellationToken cancellationToken)
        where TResource : class, IIdentifiable<TId>
    {
        dynamic repository = GetWriteRepository(typeof(TResource));
        await repository.DeleteAsync(resourceFromDatabase, id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task SetRelationshipAsync<TResource>(TResource leftResource, object? rightValue, CancellationToken cancellationToken)
        where TResource : class, IIdentifiable
    {
        ArgumentNullException.ThrowIfNull(leftResource);

        dynamic repository = GetWriteRepository(typeof(TResource));
        await repository.SetRelationshipAsync(leftResource, rightValue, cancellationToken);
    }

    /// <inheritdoc />
    public async Task AddToToManyRelationshipAsync<TResource, TId>(TResource? leftResource, [DisallowNull] TId leftId, ISet<IIdentifiable> rightResourceIds,
        CancellationToken cancellationToken)
        where TResource : class, IIdentifiable<TId>
    {
        ArgumentNullException.ThrowIfNull(rightResourceIds);

        dynamic repository = GetWriteRepository(typeof(TResource));
        await repository.AddToToManyRelationshipAsync(leftResource, leftId, rightResourceIds, cancellationToken);
    }

    /// <inheritdoc />
    public async Task RemoveFromToManyRelationshipAsync<TResource>(TResource leftResource, ISet<IIdentifiable> rightResourceIds,
        CancellationToken cancellationToken)
        where TResource : class, IIdentifiable
    {
        ArgumentNullException.ThrowIfNull(leftResource);
        ArgumentNullException.ThrowIfNull(rightResourceIds);

        dynamic repository = GetWriteRepository(typeof(TResource));
        await repository.RemoveFromToManyRelationshipAsync(leftResource, rightResourceIds, cancellationToken);
    }

    protected object ResolveReadRepository(Type resourceClrType)
    {
        ArgumentNullException.ThrowIfNull(resourceClrType);

        ResourceType resourceType = _resourceGraph.GetResourceType(resourceClrType);
        return ResolveReadRepository(resourceType);
    }

    protected virtual object ResolveReadRepository(ResourceType resourceType)
    {
        ArgumentNullException.ThrowIfNull(resourceType);

        Type repositoryType = typeof(IResourceReadRepository<,>).MakeGenericType(resourceType.ClrType, resourceType.IdentityClrType);
        return _serviceProvider.GetRequiredService(repositoryType);
    }

    private object GetWriteRepository(Type resourceClrType)
    {
        object writeRepository = ResolveWriteRepository(resourceClrType);

        if (_request.TransactionId != null)
        {
            if (writeRepository is not IRepositorySupportsTransaction repository)
            {
                ResourceType resourceType = _resourceGraph.GetResourceType(resourceClrType);
                throw new MissingTransactionSupportException(resourceType.PublicName);
            }

            if (repository.TransactionId != _request.TransactionId)
            {
                throw new NonParticipatingTransactionException();
            }
        }

        return writeRepository;
    }

    protected virtual object ResolveWriteRepository(Type resourceClrType)
    {
        ArgumentNullException.ThrowIfNull(resourceClrType);

        ResourceType resourceType = _resourceGraph.GetResourceType(resourceClrType);

        Type resourceDefinitionType = typeof(IResourceWriteRepository<,>).MakeGenericType(resourceType.ClrType, resourceType.IdentityClrType);
        return _serviceProvider.GetRequiredService(resourceDefinitionType);
    }
}
