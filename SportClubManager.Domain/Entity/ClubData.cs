using SportClubManager.Domain.Common;
using System.Xml.Serialization;

namespace SportClubManager.Domain.Entity
{
    public class ClubData : BaseEntity
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("DateOfForm")]
        public string DateOfForm { get; set; }
        [XmlElement("Discipline")]
        public string Discipline { get; set; }
        public ClubData()
        {

        }
        public ClubData(string name, string dateOfForm, string discipline)
        {
            Name = name;
            DateOfForm = dateOfForm;
            Discipline = discipline;
        }

        public override string ToString()
        {
            return "Name - " + Name + "\r\nDiscipline - " + Discipline + "\r\nDate of form - " +
                DateOfForm;
        }



    }
}
