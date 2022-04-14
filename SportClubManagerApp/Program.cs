using SportClubManager.App.Concrete;
using SportClubManager.App.Managers;

namespace SportClubManagerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            MenuActionService actionService = new MenuActionService();
            ClubDataService clubDataService = new ClubDataService();
            ClubDataManager clubDataManager = new ClubDataManager(clubDataService, actionService);
            TrainerService trainerService = new TrainerService(@"C:\Users\thran\Desktop\encje\\Trainers.xml");
            TrainerManager trainerManager = new TrainerManager(trainerService, actionService);
            PlayerService playerService = new PlayerService(@"C:\Users\thran\Desktop\encje\Players.xml");
            PlayerManager playerManager = new PlayerManager(playerService, actionService);
            TrainingService trainingService = new TrainingService(@"C:\Users\thran\Desktop\encje\Training.xml");
            TrainingManager trainingManager = new TrainingManager(trainingService, actionService, trainerService, playerService);

            while (true)
            {
                Console.Clear();
                var mainMenu = actionService.GetMenuActionsByMenuName("Main");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Welcome to Club Manager made by Andrzej Jasiński!");
                Console.ResetColor();
                Console.WriteLine();
                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }
                var chosenOption = Console.ReadKey().KeyChar;
                switch (chosenOption)
                {
                    case '0':
                        clubDataService.SaveClubDataToXml();
                        trainerService.SaveItemsToXml("Trainers", @"C:\Users\thran\Desktop\encje\Trainers.xml");
                        playerService.SaveItemsToXml("Players", @"C:\Users\thran\Desktop\encje\Players.xml");
                        trainingService.SaveItemsToXml("TrainingSchedule", @"C:\Users\thran\Desktop\encje\Training.xml");
                        Environment.Exit(0);
                        break;
                    case '1':
                        clubDataManager.SetClubData(actionService);
                        break;
                    case '2':
                        trainerManager.SelectOptionInTrainerMenu();
                        break;
                    case '3':
                        playerManager.SelectOptionInPlayerMenu();
                        break;
                    case '4':
                        trainingManager.SelectOptionInTrainingMenu();
                        break;
                    default:
                        Console.WriteLine("There is no such option!");
                        break;
                }
            }
        }
    }
}