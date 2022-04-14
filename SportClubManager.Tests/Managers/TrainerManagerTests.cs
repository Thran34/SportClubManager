using FluentAssertions;
using SportClubManager.App.Concrete;
using SportClubManager.Domain.Common;
using SportClubManager.Domain.Entity;
using Xunit;

namespace SportClubManager.Tests.Managers
{
    public class TrainerManagerTests
    {
        [Fact]
        public void RemoveTrainer()
        {
            TrainerService trainerService = new TrainerService();
            var id = 3;
            Trainer trainerToAdd = new Trainer() { Id = id + 1 };
            var proffession = (int)Profession.Football;
            trainerToAdd.Category = proffession;

            trainerService.AddItem(trainerToAdd);
            var trainertoRemove = trainerService.GetItemById(id + 1);
            if (trainertoRemove != null)
            {
                trainerService.RemoveItem(trainertoRemove);
            }
            trainerToAdd.Id.Should().Be(4);
            trainerService.Items.Should().BeEmpty();
        }
    }
}