using SportClubManager.Domain.Common;
using System.Xml.Serialization;

namespace SportClubManager.Domain.Entity
{
    public class Training : BaseEntity
    {
        [XmlElement("Trainer")]
        public List<Trainer> Trainers;
        [XmlElement("Players")]
        public List<Player> Players;
        [XmlElement("Name")]
        public string Name { get; set; }
        public Training()
        {

        }
    }
}