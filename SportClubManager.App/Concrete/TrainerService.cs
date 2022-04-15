using SportClubManager.App.Common;
using SportClubManager.Domain.Entity;

namespace SportClubManager.App.Concrete
{
    public class TrainerService : BaseService<Trainer>
    {

        public TrainerService()
        {

        }
        public TrainerService(string path)
        {
            Items = ReadItemsFromXml("Trainers", path).ToList();
        }

        public Trainer UpdateTrainerDetails(Trainer trainer, string name, string lastName, int age, string description)
        {
            trainer.Name = name;
            trainer.LastName = lastName;
            trainer.Age = age;
            trainer.Description = description;
            return trainer;
        }
    }
}
