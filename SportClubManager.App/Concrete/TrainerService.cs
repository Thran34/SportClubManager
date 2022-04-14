using SportClubManager.App.Common;
using SportClubManager.Domain.Common;
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
        public void TrainerDetails(Trainer trainer)
        {
            if (trainer == null) return;
            Console.WriteLine($"\nId: {trainer.Id}");
            Console.WriteLine($"Name: {trainer.Name}");
            Console.WriteLine($"Last name: {trainer.LastName}");
            Console.WriteLine($"Age: {trainer.Age}");
            Console.WriteLine($"Description: { trainer.Description}");
            Console.WriteLine($"Profession: {(Profession)trainer.Category}");
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
