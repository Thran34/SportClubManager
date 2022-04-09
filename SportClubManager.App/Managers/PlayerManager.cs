using SportClubManager.App.Concrete;
using SportClubManager.Domain.Entity;

namespace SportClubManager.App.Managers
{
    public class PlayerManager
    {
        public List<Player> Players = new List<Player>();
        private readonly MenuActionService _actionService;
        private PlayerService _playerService;
        public PlayerManager(PlayerService playerService, MenuActionService actionService)
        {
            _actionService = actionService;
            _playerService = playerService;
        }

        public void SelectOptionInPlayerMenu()
        {
            while (true)
            {
                Console.Clear();
                var playerView = _actionService.GetMenuActionsByMenuName("PlayerMenu");
                Console.WriteLine();
                for (int i = 0; i < playerView.Count; i++)
                {
                    Console.WriteLine($"{playerView[i].Id}. {playerView[i].Name}");
                }
                var chosenOption = Console.ReadKey().KeyChar;
                if (chosenOption == '0') break;

                switch (chosenOption)
                {
                    case '0':
                        break;
                    case '1':
                        PlayersView(null, true);
                        GoToMenuView();
                        break;
                    case '2':
                        var category = ChooseProfessionOfPlayer();
                        PlayersView(category, true);
                        GoToMenuView();
                        break;
                    case '3':
                        PlayersDetailView();
                        GoToMenuView();
                        break;
                    case '4':
                        var id = AddNewPlayer();
                        break;
                    case '5':
                        var playerToUpdate = PlayersDetailView();
                        if (playerToUpdate != null)
                        {
                            AskUserAboutPlayerDetailsView(playerToUpdate);
                        }
                        GoToMenuView();
                        break;
                    case '6':
                        var idToRemove = ChoosePlayerView();
                        if (idToRemove != 0)
                        {
                            RemoveById(idToRemove);
                            Console.Clear();
                        }
                        GoToMenuView();
                        break;
                }
            }
        }
        public Player AskUserAboutPlayerDetailsView(Player player)
        {
            Console.Clear();
            int age;
            string name, lastName, description;
            Console.WriteLine("Type in trainer name: ");
            name = Console.ReadLine();
            Console.WriteLine("Type in trainer last name: ");
            lastName = Console.ReadLine();
            Console.WriteLine("Type in trainer age: ");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("Type in trainer description: ");
            description = Console.ReadLine();
            _playerService.UpdatePlayerDetails(player, name, lastName, age, description);
            return player;

        }
        public void RemoveById(int id)
        {
            var playerToRemove = _playerService.GetItemById(id);
            if (playerToRemove != null)
            {
                _playerService.RemoveItem(playerToRemove);
            }
            else
            {
                Console.WriteLine("There is no player with this id!");
            }
        }
        private int AddNewPlayer()
        {
            var id = _playerService.GetLastId();
            Player playerToAdd = new Player() { Id = id + 1 };
            var proffession = ChooseProfessionOfPlayer();
            if (proffession == 0) return 0;
            playerToAdd.Category = proffession;
            AskUserAboutPlayerDetailsView(playerToAdd);
            _playerService.AddItem(playerToAdd);
            return playerToAdd.Id;
        }
        private Player PlayersDetailView()
        {
            var idToDetail = ChoosePlayerView();
            Console.Clear();
            var playerToShow = _playerService.GetItemById(idToDetail);
            if (idToDetail != null)
            {
                _playerService.PlayerDetails(playerToShow);
            }
            return playerToShow;
        }

        private int ChooseProfessionOfPlayer()
        {
            Console.Clear();
            Console.WriteLine("Choose Player's profession:");
            int profession;
            var professionView = _actionService.GetMenuActionsByMenuName("Profession");
            Console.WriteLine();
            for (int i = 0; i < professionView.Count; i++)
            {
                Console.WriteLine($"{professionView[i].Id }. {professionView[i].Name}");
            }
            profession = int.Parse(Console.ReadLine());
            return profession;
        }
        private bool PlayersView(int? category, bool viewInMenu)
        {
            List<Player> players;
            if (viewInMenu)
            {
                Console.Clear();
            }
            if (category != null)
            {
                players = _playerService.GetAllItems().Where(p => p.Category == category).ToList();
            }
            else
            {
                players = _playerService.GetAllItems();
            }
            if (players.Any())
            {
                foreach (var player in players)
                {
                    Console.WriteLine($"{player.Id}. {player.Name} {player.LastName}");
                }
            }
            else
            {
                Console.WriteLine($"There is no player in data base. Consider hiring new personel!");
                return false;

            }
            return true;
        }

        private int ChoosePlayerView()
        {
            Console.Clear();
            int id = 0;
            Console.WriteLine("Choose one of the following players: ");
            if (PlayersView(null, false))

            {
                var tempId = Console.ReadLine();
                Int32.TryParse(tempId, out id);
            }
            return id;

        }
        private void GoToMenuView()
        {
            Console.WriteLine("Press any button to get back to previous menu");
            Console.ReadKey();
        }
    }
}