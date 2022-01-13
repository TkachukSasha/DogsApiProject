using Dogs.Application.Dogs.Commands.CreateDog;
using Dogs.Test.Common.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Dogs.Test.Tests
{
    public class CreateDogCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateDogCommandHandler(Context);
            var name = "Neo";
            var color = "Brown";
            var tailLenght = 25;
            var weigth = 20;

            // Act
            var noteId = await handler.Handle(
                new CreateDogCommand
                {
                    Name = name,
                    Color = color,
                    TailLenght = tailLenght,
                    Weight = weigth
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Dogs.SingleOrDefaultAsync(dog =>
                    dog.Name == name && dog.Color == color &&
                    dog.TailLenght == tailLenght && dog.Weight == weigth));
        }
    }
}
