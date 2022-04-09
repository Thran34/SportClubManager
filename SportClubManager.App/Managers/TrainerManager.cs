using SportClubManager.App.Concrete;
using SportClubManager.Domain.Entity;

namespace SportClubManager.App.Managers
{
    public class TrainerManager
    {
        public List<Trainer> Trainers = new List<Trainer>();
        private readonly MenuActionService _actionService;
        private TrainerService _trainerService;
        public TrainerManager(TrainerService trainerService, MenuActionService actionService)
        {
            _actionService = actionService;
            _trainerService = trainerService;
        }

        public void SelectOptionInTrainerMenu()
        {
            while (true)
            {
                Console.Clear();
                var trainersView = _actionService.GetMenuActionsByMenuName("TrainerMenu");
                Console.WriteLine();
                for (int i = 0; i < trainersView.Count; i++)
                {
                    Console.WriteLine($"{trainersView[i].Id}. {trainersView[i].Name}");
                }
                var chosenOption = Console.ReadKey().KeyChar;
                if (chosenOption == '0') break;

                switch (chosenOption)
                {
                    case '0':
                        break;
                    case '1':
                        TrainersView(null, true);
                        GoToMenuView();
                        break;
                    case '2':
                        var category = ChooseProfessionOfTrainer();
                        TrainersView(category, true);
                        GoToMenuView();
                        break;
                    case '3':
                        TrainerDetailView();
                        GoToMenuView();
                        break;
                    case '4':
                        var id = AddNewTrainer();
                        break;
                    case '5':
                        var trainerToUpdate = TrainerDetailView();
                        if (trainerToUpdate != null)
                        {
                            AskUserAboutTrainerDetailsView(trainerToUpdate);
                        }
                        GoToMenuView();
                        break;
                    case '6':
                        var idToRemove = ChooseTrainerView();
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
        public Trainer AskUserAboutTrainerDetailsView(Trainer trainer)
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
            _trainerService.UpdateTrainerDetails(trainer, name, lastName, age, description);
            return trainer;

        }
        public void RemoveById(int id)
        {
            var trainertoRemove = _trainerService.GetItemById(id);
            if (trainertoRemove != null)
            {
                _trainerService.RemoveItem(trainertoRemove);
            }
            else
            {
                Console.WriteLine("There is no trainer with this id!");
            }
        }
        private int AddNewTrainer()
        {
            var id = _trainerService.GetLastId();
            Trainer trainerToAdd = new Trainer() { Id = id + 1 };
            var proffession = ChooseProfessionOfTrainer();
            if (proffession == 0) return 0;
            trainerToAdd.Category = proffession;
            AskUserAboutTrainerDetailsView(trainerToAdd);
            _trainerService.AddItem(trainerToAdd);
            return trainerToAdd.Id;
        }
        private Trainer TrainerDetailView()
        {
            var idToDetail = ChooseTrainerView();
            Console.Clear();
            var trainerToShow = _trainerService.GetItemById(idToDetail);
            if (idToDetail != null)
            {
                _trainerService.TrainerDetails(trainerToShow);
            }
            return trainerToShow;
        }

        private int ChooseProfessionOfTrainer()
        {
            Console.Clear();
            Console.WriteLine("Choose trainer's profession:");
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
        private bool TrainersView(int? category, bool viewInMenu)
        {
            List<Trainer> trainers;
            if (viewInMenu)
            {
                Console.Clear();
            }
            if (category != null)
            {
                trainers = _trainerService.GetAllItems().Where(p => p.Category == category).ToList();
            }
            else
            {
                trainers = _trainerService.GetAllItems();
            }
            if (trainers.Any())
            {
                foreach (var trainer in trainers)
                {
                    Console.WriteLine($"{trainer.Id}. {trainer.Name} {trainer.LastName}");
                }
            }
            else
            {
                Console.WriteLine($"There is no trainer in data base. Consider hiring new personel!");
                return false;

            }
            return true;
        }

        private int ChooseTrainerView()
        {
            Console.Clear();
            int id = 0;
            Console.WriteLine("Choose one of the following Trainers: ");
            if (TrainersView(null, false))

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
