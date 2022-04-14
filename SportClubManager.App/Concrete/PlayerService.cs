using SportClubManager.App.Common;
using SportClubManager.Domain.Common;
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
        public void PlayerDetails(Player player)
        {
            if (player == null) return;
            Console.WriteLine($"\nId: {player.Id}");
            Console.WriteLine($"Name: {player.Name}");
            Console.WriteLine($"Last name: {player.LastName}");
            Console.WriteLine($"Age: {player.Age}");
            Console.WriteLine($"Description: { player.Description}");
            Console.WriteLine($"Profession: {(Profession)player.Category}");
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
