using SportClubManager.Domain.Common;

namespace SportClubManager.Domain.Entity
{
    public class Training : BaseEntity
    {
        public List<Trainer> trainers;
        public List<Player> players;

        public string Date { get; set; }

        public string Discipline { get; set; }
    }
}