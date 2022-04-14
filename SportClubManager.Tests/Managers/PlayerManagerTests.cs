using FluentAssertions;
using SportClubManager.App.Concrete;
using SportClubManager.Domain.Common;
using SportClubManager.Domain.Entity;
using Xunit;

namespace SportClubManager.Tests.Managers
{
    public class PlayerManagerTests
    {
        [Fact]
        public void AddNewPlayer()
        {
            PlayerService playerService = new PlayerService();
            var id = 5;
            Player playerToAdd = new Player() { Id = id + 1 };
            var profession = (int)Profession.Football;
            playerToAdd.Category = profession;
            playerService.AddItem(playerToAdd);

            playerToAdd.Id.Should().Be(6);
            playerService.GetAllItems().Should().Contain(playerToAdd);
            profession.Should().Be(3);
        }
    }
}
