using FluentAssertions;
using SportClubManager.App.Concrete;
using Xunit;

namespace SportClubManager.Tests.Services
{
    public class MenuActionServiceTests
    {
        [Fact]
        public void MenuActionShouldBeNullOrEmpty()
        {
            //Arrange
            MenuActionService actionService = new MenuActionService();
            //Act
            var menuAction = actionService.GetMenuActionsByMenuName("nullMenu");
            //Assert
            menuAction.Should().BeNullOrEmpty();
        }

        [Fact]
        public void MenuActionShouldBeNotNull()
        {
            //Arrange
            MenuActionService actionService = new MenuActionService();
            //Act
            var menuAction = actionService.GetMenuActionsByMenuName("Main");
            //Assert
            menuAction.Count.Should().Be(5);
        }
    }
}

