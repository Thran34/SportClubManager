using FluentAssertions;
using SportClubManager.Domain.Entity;
using Xunit;

namespace SportClubManager.Tests.Services
{
    public class PlayerServiceTests
    {
        [Fact]
        public void PlayerDetails()
        {
            //Arrange
            Player player = new Player(5, "Piotr", "Bas", 30, "Excellent footballer");
            //Act
            System.Console.WriteLine(player);
            //Assert
            player.Id.Should().Be(5);
            player.Name.Should().Be("Piotr");
            player.LastName.Should().Be("Bas");
            player.Age.Should().Be(30);
            player.Description.Should().Be("Excellent footballer");
        }
    }
}
