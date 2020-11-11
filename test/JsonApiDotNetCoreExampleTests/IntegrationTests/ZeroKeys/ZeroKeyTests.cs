using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Serialization.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace JsonApiDotNetCoreExampleTests.IntegrationTests.ZeroKeys
{
    public sealed class ZeroKeyTests : IClassFixture<IntegrationTestContext<TestableStartup<ZeroKeyDbContext>, ZeroKeyDbContext>>
    {
        private readonly IntegrationTestContext<TestableStartup<ZeroKeyDbContext>, ZeroKeyDbContext> _testContext;
        private readonly ZeroKeyFakers _fakers = new ZeroKeyFakers();

        public ZeroKeyTests(IntegrationTestContext<TestableStartup<ZeroKeyDbContext>, ZeroKeyDbContext> testContext)
        {
            _testContext = testContext;

            var options = (JsonApiOptions)testContext.Factory.Services.GetRequiredService<IJsonApiOptions>();
            options.UseRelativeLinks = true;
            options.AllowClientGeneratedIds = true;
        }

        [Fact]
        public async Task Can_filter_by_zero_ID_on_primary_resources()
        {
            // Arrange
            var games = _fakers.Game.Generate(2);
            games[0].Id = 0;

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                await dbContext.ClearTableAsync<Game>();
                dbContext.Games.AddRange(games);
                await dbContext.SaveChangesAsync();
            });

            var route = "/games?filter=equals(id,'0')";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.OK);

            responseDocument.ManyData.Should().HaveCount(1);
            responseDocument.ManyData[0].Id.Should().Be("0");
            responseDocument.ManyData[0].Links.Self.Should().Be("/games/0");
        }

        [Fact]
        public async Task Can_filter_by_empty_string_ID_on_primary_resources()
        {
            // Arrange
            var players = _fakers.Player.Generate(2);
            players[0].Id = string.Empty;

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                await dbContext.ClearTableAsync<Player>();
                dbContext.Players.AddRange(players);
                await dbContext.SaveChangesAsync();
            });

            var route = "/players?filter=equals(id,'')";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.OK);

            responseDocument.ManyData.Should().HaveCount(1);
            responseDocument.ManyData[0].Id.Should().Be("");
            responseDocument.ManyData[0].Links.Self.Should().Be("/players/");
        }

        [Fact]
        public async Task Can_get_primary_resource_by_zero_ID_with_include()
        {
            // Arrange
            var game = _fakers.Game.Generate();
            game.Id = 0;
            game.ActivePlayers = _fakers.Player.Generate(1);

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                await dbContext.ClearTableAsync<Game>();
                dbContext.Games.Add(game);
                await dbContext.SaveChangesAsync();
            });

            var route = "/games/0?include=activePlayers";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecuteGetAsync<Document>(route);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.OK);

            responseDocument.SingleData.Should().NotBeNull();
            responseDocument.SingleData.Id.Should().Be("0");
            responseDocument.SingleData.Links.Self.Should().Be("/games/0");

            responseDocument.Included.Should().HaveCount(1);
            responseDocument.Included[0].Id.Should().Be(game.ActivePlayers.ElementAt(0).StringId);
        }

        [Fact]
        public async Task Can_create_resource_with_zero_ID()
        {
            // Arrange
            var newTitle = _fakers.Game.Generate().Title;

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                await dbContext.ClearTableAsync<Game>();
            });

            var requestBody = new
            {
                data = new
                {
                    type = "games",
                    id = "0",
                    attributes = new
                    {
                        title = newTitle
                    }
                }
            };

            var route = "/games";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecutePostAsync<Document>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.Created);

            httpResponse.Headers.Location.Should().Be("/games/0");

            responseDocument.SingleData.Should().NotBeNull();
            responseDocument.SingleData.Id.Should().Be("0");

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                var gameInDatabase = await dbContext.Games
                    .FirstAsync(game => game.Id == 0);

                gameInDatabase.Should().NotBeNull();
            });
        }

        [Fact]
        public async Task Can_update_resource_with_zero_ID()
        {
            // Arrange
            var existingGame = _fakers.Game.Generate();
            existingGame.Id = 0;
            
            var newTitle = _fakers.Game.Generate().Title;

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                await dbContext.ClearTableAsync<Game>();
                dbContext.Games.Add(existingGame);
                await dbContext.SaveChangesAsync();
            });

            var requestBody = new
            {
                data = new
                {
                    type = "games",
                    id = "0",
                    attributes = new
                    {
                        title = newTitle
                    }
                }
            };

            var route = "/games/0";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecutePatchAsync<Document>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.OK);

            responseDocument.SingleData.Should().NotBeNull();
            responseDocument.SingleData.Id.Should().Be("0");
            responseDocument.SingleData.Attributes["title"].Should().Be(newTitle);

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                var gameInDatabase = await dbContext.Games
                    .FirstAsync(game => game.Id == 0);

                gameInDatabase.Should().NotBeNull();
                gameInDatabase.Title.Should().Be(newTitle);
            });
        }

        [Fact(Skip = "TODO: Fix bug to make this test succeed.")]
        public async Task Can_clear_ToOne_relationship_with_zero_ID()
        {
            // Arrange
            var existingPlayer = _fakers.Player.Generate();
            existingPlayer.ActiveGame = _fakers.Game.Generate();
            existingPlayer.ActiveGame.Id = 0;

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                await dbContext.ClearTableAsync<Game>();
                dbContext.Players.Add(existingPlayer);
                await dbContext.SaveChangesAsync();
            });

            var requestBody = new
            {
                data = (object)null
            };

            var route = $"/players/{existingPlayer.StringId}/relationships/activeGame";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecutePatchAsync<string>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.NoContent);

            responseDocument.Should().BeEmpty();

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                var playerInDatabase = await dbContext.Players
                    .Include(player => player.ActiveGame)
                    .FirstAsync(player => player.Id == existingPlayer.Id);

                playerInDatabase.Should().NotBeNull();
                playerInDatabase.ActiveGame.Should().BeNull();
            });
        }

        [Fact]
        public async Task Can_replace_ToOne_relationship_with_zero_ID()
        {
            // Arrange
            var existingPlayer = _fakers.Player.Generate();
            existingPlayer.ActiveGame = _fakers.Game.Generate();

            var existingGame = _fakers.Game.Generate();
            existingGame.Id = 0;

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                await dbContext.ClearTableAsync<Game>();
                dbContext.AddRange(existingPlayer, existingGame);
                await dbContext.SaveChangesAsync();
            });

            var requestBody = new
            {
                data = new
                {
                    type = "games",
                    id = "0"
                }
            };

            var route = $"/players/{existingPlayer.StringId}/relationships/activeGame";

            // Act
            var (httpResponse, responseDocument) = await _testContext.ExecutePatchAsync<string>(route, requestBody);

            // Assert
            httpResponse.Should().HaveStatusCode(HttpStatusCode.NoContent);

            responseDocument.Should().BeEmpty();

            await _testContext.RunOnDatabaseAsync(async dbContext =>
            {
                var playerInDatabase = await dbContext.Players
                    .Include(player => player.ActiveGame)
                    .FirstAsync(player => player.Id == existingPlayer.Id);

                playerInDatabase.Should().NotBeNull();
                playerInDatabase.ActiveGame.Id.Should().Be(0);
            });
        }
    }
}
