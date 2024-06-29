using System.Net;
using JsonApiDotNetCore.OpenApi.Client.Kiota;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Http.HttpClientLibrary.Middleware.Options;
using OpenApiKiotaClientExample.GeneratedCode;
using OpenApiKiotaClientExample.GeneratedCode.Models;

namespace OpenApiKiotaClientExample;

public sealed class Worker(ExampleApiClient apiClient, IHostApplicationLifetime hostApplicationLifetime, SetQueryStringHttpMessageHandler queryStringHandler)
    : BackgroundService
{
    private readonly ExampleApiClient _apiClient = apiClient;
    private readonly IHostApplicationLifetime _hostApplicationLifetime = hostApplicationLifetime;
    private readonly SetQueryStringHttpMessageHandler _queryStringHandler = queryStringHandler;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            using (_queryStringHandler.CreateScope(new Dictionary<string, string?>
            {
                // Workaround for https://github.com/microsoft/kiota/issues/3800.
                ["filter"] = "has(assignedTodoItems)",
                ["sort"] = "-lastName",
                ["page[size]"] = "5",
                ["include"] = "assignedTodoItems.tags"
            }))
            {
                (PersonCollectionResponseDocument? getResponse, string? eTag) = await GetPeopleAsync(_apiClient, null, stoppingToken);
                PeopleMessageFormatter.PrintPeople(getResponse);

                (PersonCollectionResponseDocument? getResponseAgain, _) = await GetPeopleAsync(_apiClient, eTag, stoppingToken);
                PeopleMessageFormatter.PrintPeople(getResponseAgain);
            }

            await UpdatePersonAsync(stoppingToken);

            _ = await _apiClient.Api.People["999999"].GetAsync(cancellationToken: stoppingToken);
        }
        catch (ErrorResponseDocument exception)
        {
            Console.WriteLine($"JSON:API ERROR: {exception.Errors!.First().Detail}");
        }
        catch (HttpRequestException exception)
        {
            Console.WriteLine($"ERROR: {exception.Message}");
        }

        _hostApplicationLifetime.StopApplication();
    }

    private async Task<(PersonCollectionResponseDocument? response, string? eTag)> GetPeopleAsync(ExampleApiClient apiClient, string? ifNoneMatch,
        CancellationToken cancellationToken)
    {
        try
        {
            var headerInspector = new HeadersInspectionHandlerOption
            {
                InspectResponseHeaders = true
            };

            PersonCollectionResponseDocument? responseDocument = await apiClient.Api.People.GetAsync(configuration =>
            {
                if (!string.IsNullOrEmpty(ifNoneMatch))
                {
                    configuration.Headers.Add("If-None-Match", ifNoneMatch);
                }

                configuration.Options.Add(headerInspector);
            }, cancellationToken);

            string eTag = headerInspector.ResponseHeaders["ETag"].Single();

            return (responseDocument, eTag);
        }
        // Workaround for https://github.com/microsoft/kiota/issues/4190.
        catch (ApiException exception) when (exception.ResponseStatusCode == (int)HttpStatusCode.NotModified)
        {
            return (null, null);
        }
    }

    private async Task UpdatePersonAsync(CancellationToken cancellationToken)
    {
        var patchRequest = new UpdatePersonRequestDocument
        {
            Data = new DataInUpdatePersonRequest
            {
                Type = PersonResourceType.People,
                Id = "1",
                Attributes = new AttributesInUpdatePersonRequest
                {
                    LastName = "Doe"
                }
            }
        };

        _ = await _apiClient.Api.People[patchRequest.Data.Id].PatchAsync(patchRequest, cancellationToken: cancellationToken);
    }
}
