using SportClubManager.App.Common;
using SportClubManager.Domain.Common;
using SportClubManager.Domain.Entity;

namespace SportClubManager.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }
        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach (var menuAction in Items)
            {
                if (menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }
        private void Initialize()
        {
            AddItem(new MenuAction(0, "SAVE and exit", "Main"));
            AddItem(new MenuAction(1, "Club Data", "Main"));
            AddItem(new MenuAction(2, "Trainers", "Main"));
            AddItem(new MenuAction(3, "Players", "Main"));
            AddItem(new MenuAction(4, "Trainings", "Main"));


            AddItem(new MenuAction(0, "Back to previous menu", "ClubDataMenu"));
            AddItem(new MenuAction(1, "Update club data", "ClubDataMenu"));

            AddItem(new MenuAction(0, "Back to previous menu", "TrainerMenu"));
            AddItem(new MenuAction(1, "View all trainers", "TrainerMenu"));
            AddItem(new MenuAction(2, "View all trainers from selected category", "TrainerMenu"));
            AddItem(new MenuAction(3, "View details of chosen trainer", "TrainerMenu"));
            AddItem(new MenuAction(4, "Add trainer", "TrainerMenu"));
            AddItem(new MenuAction(5, "Update trainer details", "TrainerMenu"));
            AddItem(new MenuAction(6, "Delete trainer", "TrainerMenu"));

            AddItem(new MenuAction(0, "Back to previous menu", "PlayerMenu"));
            AddItem(new MenuAction(1, "View all players", "PlayerMenu"));
            AddItem(new MenuAction(2, "View all players from selected category", "PlayerMenu"));
            AddItem(new MenuAction(3, "View details of chosen player", "PlayerMenu"));
            AddItem(new MenuAction(4, "Add player", "PlayerMenu"));
            AddItem(new MenuAction(5, "Update player details", "PlayerMenu"));
            AddItem(new MenuAction(6, "Delete player", "PlayerMenu"));







            for (int i = 1; i <= 4; i++)
            {
                AddItem(new MenuAction(i, ((NameofSport)i).ToString(), "Profession"));
            }
        }
    }
}
