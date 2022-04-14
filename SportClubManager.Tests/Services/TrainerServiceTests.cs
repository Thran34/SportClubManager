using FluentAssertions;
using SportClubManager.Domain.Entity;
using Xunit;

namespace SportClubManager.Tests.Services
{
    public class TrainerServiceTests
    {
        [Fact]
        public void TrainerDetails()
        {
            //Arrange
            Trainer trainer = new Trainer(1, "Andrzej", "Jasiński", 24, "Excellent trainer");
            //Act
            System.Console.WriteLine(trainer);
            //Assert
            trainer.Id.Should().Be(1);
            trainer.Name.Should().Be("Andrzej");
            trainer.LastName.Should().Be("Jasiński");
            trainer.Age.Should().Be(24);
            trainer.Description.Should().Be("Excellent trainer");
        }
    }
}
