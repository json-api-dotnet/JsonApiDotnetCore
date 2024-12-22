using System.ComponentModel;
using JetBrains.Annotations;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Middleware;
using JsonApiDotNetCore.Queries.Expressions;
using JsonApiDotNetCore.Resources;
using JsonApiDotNetCoreExample.Models;

namespace JsonApiDotNetCoreExample.Definitions;

[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
public sealed class TodoItemDefinition(IResourceGraph resourceGraph, TimeProvider timeProvider)
    : JsonApiResourceDefinition<TodoItem, long>(resourceGraph)
{
    private readonly Func<DateTimeOffset> _getUtcNow = timeProvider.GetUtcNow;

    public override SortExpression OnApplySort(SortExpression? existingSort)
    {
        return existingSort ?? GetDefaultSortOrder();
    }

    private SortExpression GetDefaultSortOrder()
    {
        return CreateSortExpressionFromLambda([
            (todoItem => todoItem.Priority, ListSortDirection.Ascending),
            (todoItem => todoItem.LastModifiedAt, ListSortDirection.Descending)
        ]);
    }

    public override Task OnWritingAsync(TodoItem resource, WriteOperationKind writeOperation, CancellationToken cancellationToken)
    {
        if (writeOperation == WriteOperationKind.CreateResource)
        {
            resource.CreatedAt = _getUtcNow();
        }
        else if (writeOperation == WriteOperationKind.UpdateResource)
        {
            resource.LastModifiedAt = _getUtcNow();
        }

        return Task.CompletedTask;
    }
}
