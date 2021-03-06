using SportClubManager.Domain.Common;
using System.Xml.Serialization;

namespace SportClubManager.Domain.Entity
{
    public class Player : BaseEntity
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("LastName")]
        public string LastName { get; set; }
        [XmlElement("Age")]
        public int Age { get; set; }
        [XmlElement("Description")]
        public string Description { get; set; }
        public Player()
        {
        }
        public Player(int id, string name, string lastName, int age, string description)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Age = age;
            Description = description;
        }
    }
}
