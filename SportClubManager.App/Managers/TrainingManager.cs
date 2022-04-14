using SportClubManager.App.Abstract;
using SportClubManager.App.Concrete;
using SportClubManager.Domain.Common;
using SportClubManager.Domain.Entity;

namespace SportClubManager.App.Managers
{
    public class TrainingManager
    {
        PlayerManager playerManager = new PlayerManager();
        TrainerManager trainerManager = new TrainerManager();
        private readonly MenuActionService _actionService;
        private readonly TrainingService _trainingService;
        private IService<Trainer> _trainerService;
        private IService<Player> _playerService;


        public TrainingManager(TrainingService trainingService, MenuActionService actionService, IService<Trainer> trainerService, IService<Player> playerService)
        {
            _actionService = actionService;
            _trainingService = trainingService;
            _trainerService = trainerService;
            _playerService = playerService;
        }

        public void SelectOptionInTrainingMenu()
        {
            while (true)
            {
                Console.Clear();
                var trainingView = _actionService.GetMenuActionsByMenuName("TrainingMenu");
                Console.WriteLine();
                for (int i = 0; i < trainingView.Count; i++)
                {
                    Console.WriteLine($"{trainingView[i].Id} {trainingView[i].Name}");
                }
                var chosenOption = Console.ReadKey();
                if (chosenOption.KeyChar == '0')
                {
                    break;
                }
                switch (chosenOption.KeyChar)
                {
                    case '0':
                        break;
                    case '1':
                        var category = ChooseCategoryView();
                        if (category != 0)
                        {
                            TrainingsView(category);
                        }
                        GoToMenuView();
                        break;
                    case '2':
                        var chosenTraining = ChooseTrainingView();

                        if (chosenTraining != null)
                        {
                            DetailTrainingView(chosenTraining);
                        }
                        GoToMenuView();
                        break;
                    case '3':
                        AddNewTraining();
                        break;
                }
            }
        }
        private void GoToMenuView()
        {
            Console.WriteLine("Press any button to return to previous menu");
            Console.ReadKey();
        }
        private int ChooseCategoryView()
        {
            Console.Clear();
            if (!_trainerService.GetAllItems().Any())
            {
                Console.WriteLine($"There is no trainer in data base. Consider hiring new personel!");
                GoToMenuView();
                return 0;
            }
            if (!_playerService.GetAllItems().Any())
            {
                Console.WriteLine($"There is no player in data base. Consider hiring new personel!");
                GoToMenuView();
                return 0;
            }
            var trainingView = _actionService.GetMenuActionsByMenuName("Profession");
            Console.WriteLine();
            trainingView.ForEach(tV => Console.WriteLine($"{tV.Id}. {tV.Name}"));
            int category;
            while (!Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out category))
            {
                Console.WriteLine("Choose category again");
            }
            if (!new[] { 1, 2, 3, 4 }.Contains(category))
            {
                Console.WriteLine("There is no such category");
                return 0;
            }
            return category;
        }
        private List<Player> AskUserAboutPlayersView(List<Player> players)
        {
            int idOfPlayer;
            Player playerToAdd;
            while (true)
            {
                Console.WriteLine("\nTo stop adding new players press 0");
                Console.WriteLine("Actual list of players for training: ");
                players.ForEach(p => Console.WriteLine($"-{p.Name} {p.LastName}"));
                Console.WriteLine("----------------");
                Console.WriteLine("Choose player:");
                _playerService.GetAllItems().ForEach(p => Console.WriteLine($"\n{p.Id}.{p.Name} {p.LastName}"));
                int.TryParse(Console.ReadKey().KeyChar.ToString(), out idOfPlayer);
                if (idOfPlayer == 0)
                {
                    break;
                }
                playerToAdd = _playerService.GetItemById(idOfPlayer);
                if (playerToAdd == null)
                {
                    Console.WriteLine("\nThere is no such player!");
                    continue;
                }
                players.Add(playerToAdd);
                Console.Clear();
            }
            return players;
        }
        private Training ChooseTrainingView()
        {
            if (!_trainingService.Items.Any())
            {
                Console.Clear();
                Console.WriteLine("There are no trainings in database!");
                return null;
            }
            int id;
            Console.WriteLine("Choose training from list: ");
            _trainingService.Items.ForEach(t => TrainingView(t));
            var tempId = Console.ReadLine();
            Int32.TryParse(tempId, out id);
            Training chosenTraining = _trainingService.GetItemById(id);
            return chosenTraining;
        }
        private int AddNewTraining()
        {
            Console.Clear();
            int trainingCategory = ChooseCategoryView();
            if (trainingCategory == 0)
            {
                return 0;
            }
            List<Trainer> trainingTrainer = new List<Trainer>();
            AskUserAboutTrainerView(trainingTrainer);
            List<Player> trainingPlayers = new List<Player>();
            AskUserAboutPlayersView(trainingPlayers);
            if (!trainingPlayers.Any())
            {
                return 0;
            }
            string name = AskAboutName();
            var id = _trainerService.GetLastId();
            Training training = new Training { Id = id, Category = trainingCategory, Players = trainingPlayers, Trainers = trainingTrainer, Name = name };
            _trainingService.AddItem(training);
            DetailTrainingView(training);
            GoToMenuView();
            return training.Id;

        }
        private string AskAboutName()
        {
            Console.WriteLine("\nType in the name of training: ");
            string name = Console.ReadLine();
            return name;
        }
        private void DetailTrainingView(Training training)
        {
            Console.WriteLine("\n--------------------------------");
            Console.WriteLine($"Trainers selected for training: ");
            training.Trainers.ForEach(t => Console.WriteLine($"-{t.Name} {t.LastName}"));
            Console.WriteLine($"\nSport: {(Profession)training.Category}");
            Console.WriteLine("\nList of players in training: ");
            training.Players.ForEach(p => Console.WriteLine($"-{p.Name} {p.LastName}"));
        }
        private void TrainingView(Training training)
        {
            Console.WriteLine($"{training.Id} {training.Name}");
        }
        private void TrainingsView(int category)
        {
            var trainings = _trainingService.GetAllItems();
            Console.Clear();
            if (!trainings.Any())
            {
                Console.WriteLine("\nThere are no trainings in database!");
                GoToMenuView();
                return;
            }
            trainings.Where(t => t.Category == category).ToList().ForEach(t => TrainingView(t));
        }
        private List<Trainer> AskUserAboutTrainerView(List<Trainer> trainers)
        {
            int idOfTrainer;
            Trainer trainerToAdd;
            Console.WriteLine("----------------");
            Console.WriteLine("Choose trainer:");
            _trainerService.GetAllItems().ForEach(p => Console.WriteLine($"\n{p.Id}.{p.Name} {p.LastName}"));
            int.TryParse(Console.ReadKey().KeyChar.ToString(), out idOfTrainer);
            trainerToAdd = _trainerService.GetItemById(idOfTrainer);
            trainers.Add(trainerToAdd);
            Console.Clear();
            return trainers;
        }
    }
}