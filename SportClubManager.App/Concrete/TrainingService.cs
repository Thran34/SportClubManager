using SportClubManager.App.Common;
using SportClubManager.Domain.Entity;

namespace SportClubManager.App.Concrete
{
    public class TrainingService : BaseService<Training>
    {

        public TrainingService()
        {

        }
        public TrainingService(string path)
        {
            Items = ReadItemsFromXml("TrainingSchedule", path).ToList();
        }
    }
}
