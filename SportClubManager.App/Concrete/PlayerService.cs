using SportClubManager.App.Common;
using SportClubManager.Domain.Entity;

namespace SportClubManager.App.Concrete
{
    public class PlayerService : BaseService<Player>
    {
        public PlayerService()
        {

        }
        public PlayerService(string path)
        {

            Items = ReadItemsFromXml("Players", path).ToList();

        }

        public Player UpdatePlayerDetails(Player player, string name, string lastName, int age, string description)
        {
            player.Name = name;
            player.LastName = lastName;
            player.Age = age;
            player.Description = description;
            return player;
        }
    }
}
