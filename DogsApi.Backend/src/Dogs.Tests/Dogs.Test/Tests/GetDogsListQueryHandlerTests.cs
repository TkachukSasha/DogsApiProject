using Dogs.Application.Dogs.Queries.GetDogsList;
using Dogs.Infrastructure.Data;
using Dogs.Test.Common.Helpers;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Dogs.Test.Tests
{
    [Collection("QueryCollection")]
    public class GetDogsListQueryHandlerTests
    {
        private readonly DogsDbContext Context;

        public GetDogsListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
        }

        [Fact]
        public async Task GetNoteListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetDogsListQueryHandler(Context);

            // Act
            var result = await handler.Handle(
                new GetDogsListQuery { }, CancellationToken.None);

            // Assert
            result.Length.Equals(2);
        }
    }
}
