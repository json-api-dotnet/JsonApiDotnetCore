using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using JsonApiDotNetCore.Serialization.Objects;
using Xunit;

namespace JsonApiDotNetCoreExampleTests.IntegrationTests.RestrictedControllers
{
    public sealed class HttpReadOnlyTests
        : IClassFixture<IntegrationTestContext<TestableStartup<RestrictionDbContext>, RestrictionDbContext>>
    {
        private readonly IntegrationTestContext<TestableStartup<RestrictionDbContext>, RestrictionDbContext> _testContext;
        private readonly RestrictionFakers _fakers = new RestrictionFakers();

        public HttpReadOnlyTests(IntegrationTestContext<TestableStartup<RestrictionDbContext>, RestrictionDbContext> testContext)
        {
            _testContext = testContext;
        }

        [Fact]
        public async Task Can_get_resources()
        {
            // Arrange
            var route = "/beds";

            // Act
            var (httpResponse, _) = await _testContext.ExecuteGetAsync<string>(route);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Cannot_create_resource()
        {
            // Arrange
            var requestBody = new
            {
                data = new
                {
                    type = "beds",
                    attributes = new
                    {
                    }
                }
            };

            var route = "/beds";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecutePostAsync<ErrorDocument>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.MethodNotAllowed);

            responseDocument.Errors.Should().HaveCount(1);
            responseDocument.Errors[0].StatusCode.Should().Be(HttpStatusCode.MethodNotAllowed);
            responseDocument.Errors[0].Title.Should().Be("The request method is not allowed.");
            responseDocument.Errors[0].Detail.Should().Be("Resource does not support POST requests.");
        }

        [Fact]
        public async Task Cannot_update_resource()
        {
            // Arrange
            var existingBed = _fakers.Bed.Generate();

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                dbContext.Beds.Add(existingBed);
                await dbContext.SaveChangesAsync();
            });

            var requestBody = new
            {
                data = new
                {
                    type = "beds",
                    id = existingBed.StringId,
                    attributes = new
                    {
                    }
                }
            };

            var route = "/beds/" + existingBed.StringId;

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecutePatchAsync<ErrorDocument>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.MethodNotAllowed);

            responseDocument.Errors.Should().HaveCount(1);
            responseDocument.Errors[0].StatusCode.Should().Be(HttpStatusCode.MethodNotAllowed);
            responseDocument.Errors[0].Title.Should().Be("The request method is not allowed.");
            responseDocument.Errors[0].Detail.Should().Be("Resource does not support PATCH requests.");
        }

        [Fact]
        public async Task Cannot_delete_resource()
        {
            // Arrange
            var existingBed = _fakers.Bed.Generate();

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                dbContext.Beds.Add(existingBed);
                await dbContext.SaveChangesAsync();
            });

            var route = "/beds/" + existingBed.StringId;

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecuteDeleteAsync<ErrorDocument>(route);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.MethodNotAllowed);

            responseDocument.Errors.Should().HaveCount(1);
            responseDocument.Errors[0].StatusCode.Should().Be(HttpStatusCode.MethodNotAllowed);
            responseDocument.Errors[0].Title.Should().Be("The request method is not allowed.");
            responseDocument.Errors[0].Detail.Should().Be("Resource does not support DELETE requests.");
        }
    }
}
