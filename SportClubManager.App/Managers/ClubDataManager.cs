using SportClubManager.App.Concrete;

namespace SportClubManager.App.Managers
{
    public class ClubDataManager
    {
        private readonly ClubDataService _clubDataService;
        private readonly MenuActionService _actionService;

        public ClubDataManager(ClubDataService clubDataService, MenuActionService actionService)
        {
            _clubDataService = clubDataService;
            _actionService = actionService;
        }

        public void SetClubData(MenuActionService actionService)
        {
            Console.Clear();
            var clubDataMenu = actionService.GetMenuActionsByMenuName("ClubDataMenu");
            Console.WriteLine($"\n Your club actual data: \r\n{_clubDataService.clubData}");
            Console.WriteLine();
            for (int i = 0; i < clubDataMenu.Count; i++)
            {
                Console.WriteLine($"{clubDataMenu[i].Id}. {clubDataMenu[i].Name}");
            }
            var chosenOption = Console.ReadKey();
            Console.Clear();
            if (chosenOption.KeyChar != '1')
                return;

            Console.WriteLine("\nType in Your club name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Type in Your club date of creation:  ");
            string dateOfForm = Console.ReadLine();
            Console.WriteLine("Choose the club's discipline: ");
            string nameOfSport = Console.ReadLine();
            _clubDataService.SetClubData(name, dateOfForm, nameOfSport);

        }
    }
}
