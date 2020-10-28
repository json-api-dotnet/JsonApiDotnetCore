using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using JsonApiDotNetCore.Serialization.Objects;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Xunit;

namespace JsonApiDotNetCoreExampleTests.IntegrationTests.Writing.Deleting
{
    public sealed class DeleteResourceTests
        : IClassFixture<IntegrationTestContext<TestableStartup<WriteDbContext>, WriteDbContext>>
    {
        private readonly IntegrationTestContext<TestableStartup<WriteDbContext>, WriteDbContext> _testContext;
        private readonly WriteFakers _fakers = new WriteFakers();

        public DeleteResourceTests(IntegrationTestContext<TestableStartup<WriteDbContext>, WriteDbContext> testContext)
        {
            _testContext = testContext;
        }

        [Fact]
        public async Task Can_delete_existing_resource()
        {
            // Arrange
            var existingWorkItem = _fakers.WorkItem.Generate();

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                dbContext.WorkItems.Add(existingWorkItem);
                await dbContext.SaveChangesAsync();
            });

            var route = "/workItems/" + existingWorkItem.StringId;

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecuteDeleteAsync<string>(route);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.NoContent);

            responseDocument.Should().BeEmpty();

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                var workItemsInDatabase = await dbContext.WorkItems
                    .Where(workItem => workItem.Id == existingWorkItem.Id)
                    .ToListAsync();

                workItemsInDatabase.Should().BeEmpty();
            });
        }

        // TODO: Should this really fail?
        // spec says: "A server SHOULD return a 404 Not Found status code if a deletion request fails due to the resource not existing.
        // Given the technical implementation, the deletion requests does not have to "fail". Deleting from a table where record.id = X where the X does not exist in the table is not a failure. 
        [Fact]
        public async Task Cannot_delete_missing_resource()
        {
            // Arrange
            var route = "/workItems/99999999";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecuteDeleteAsync<ErrorDocument>(route);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.NotFound);

            responseDocument.Errors.Should().HaveCount(1);
            responseDocument.Errors[0].StatusCode.Should().Be(HttpStatusCode.NotFound);
            responseDocument.Errors[0].Title.Should().Be("The requested resource does not exist.");
            responseDocument.Errors[0].Detail.Should().Be("Resource of type 'workItems' with ID '99999999' does not exist.");
        }

        [Fact]
        public async Task Can_delete_resource_with_OneToOne_relationship_from_dependent_side()
        {
            // Arrange
            var existingColor = _fakers.RgbColor.Generate();
            existingColor.Group = _fakers.WorkItemGroup.Generate();

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                dbContext.RgbColors.Add(existingColor);
                await dbContext.SaveChangesAsync();
            });

            var route = "/rgbColors/" + existingColor.StringId;

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecuteDeleteAsync<string>(route);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.NoContent);

            responseDocument.Should().BeEmpty();

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                var colorsInDatabase = await dbContext.RgbColors
                    .Where(color => color.Id == existingColor.Id)
                    .ToListAsync();

                colorsInDatabase.Should().BeEmpty();

                var groupsInDatabase = await dbContext.Groups
                    .Where(group => group.Id == existingColor.Group.Id)
                    .ToListAsync();

                groupsInDatabase.Should().HaveCount(1);
                groupsInDatabase[0].Color.Should().BeNull();
            });
        }

        // TODO: How do we want JADNC to deal with this?
        // I think this should only fail if the relationships are required in the models. Otherwise we should be able to work around the constraint violation.
        // If we can delete from dependent side, why shouldn't we be able to delete from principal side? This leaks implementation details.
        // In any case we shouldn't return 500.
        [Fact]
        public async Task Cannot_delete_existing_resource_with_OneToOne_relationship_from_principal_side()
        {
            // Arrange
            var existingGroup = _fakers.WorkItemGroup.Generate();
            existingGroup.Color = _fakers.RgbColor.Generate();

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                dbContext.Groups.Add(existingGroup);
                await dbContext.SaveChangesAsync();
            });

            var route = "/workItemGroups/" + existingGroup.StringId;

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecuteDeleteAsync<ErrorDocument>(route);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.InternalServerError);

            responseDocument.Errors.Should().HaveCount(1);
            responseDocument.Errors[0].StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            responseDocument.Errors[0].Title.Should().Be("An unhandled error occurred while processing this request.");
            responseDocument.Errors[0].Detail.Should().Be("Failed to persist changes in the underlying data store.");

            var stackTrace = JsonConvert.SerializeObject(responseDocument.Errors[0].Meta.Data["stackTrace"], Formatting.Indented);
            stackTrace.Should().Contain("violates foreign key constraint");
        }

        // TODO: How do we want JADNC to deal with this?
        // I think this should only fail if the relationships are required in the models. Otherwise we should be able to work around the constraint violation.
        // In any case we shouldn't return 500.
        [Fact]
        public async Task Cannot_delete_existing_resource_with_HasMany_relationship()
        {
            // Arrange
            var existingWorkItem = _fakers.WorkItem.Generate();
            existingWorkItem.Subscribers = _fakers.UserAccount.Generate(2).ToHashSet();

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                dbContext.WorkItems.Add(existingWorkItem);
                await dbContext.SaveChangesAsync();
            });

            var route = "/workItems/" + existingWorkItem.StringId;

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecuteDeleteAsync<ErrorDocument>(route);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.InternalServerError);

            responseDocument.Errors.Should().HaveCount(1);
            responseDocument.Errors[0].StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            responseDocument.Errors[0].Title.Should().Be("An unhandled error occurred while processing this request.");
            responseDocument.Errors[0].Detail.Should().Be("Failed to persist changes in the underlying data store.");

            var stackTrace = JsonConvert.SerializeObject(responseDocument.Errors[0].Meta.Data["stackTrace"], Formatting.Indented);
            stackTrace.Should().Contain("violates foreign key constraint");
        }

        [Fact]
        public async Task Can_delete_resource_with_HasManyThrough_relationship()
        {
            // Arrange
            var existingWorkItemTag = new WorkItemTag
            {
                Item = _fakers.WorkItem.Generate(),
                Tag = _fakers.WorkTags.Generate()
            };

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                dbContext.WorkItemTags.Add(existingWorkItemTag);
                await dbContext.SaveChangesAsync();
            });

            var route = "/workItems/" + existingWorkItemTag.Item.StringId;

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecuteDeleteAsync<string>(route);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.NoContent);

            responseDocument.Should().BeEmpty();

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                var workItemsInDatabase = await dbContext.WorkItems
                    .Where(workItem => workItem.Id == existingWorkItemTag.Item.Id)
                    .ToListAsync();

                workItemsInDatabase.Should().BeEmpty();

                var workItemTagsInDatabase = await dbContext.WorkItemTags
                    .Where(workItemTag => workItemTag.Item.Id == existingWorkItemTag.Item.Id)
                    .ToListAsync();

                workItemTagsInDatabase.Should().BeEmpty();
            });
        }
    }
}