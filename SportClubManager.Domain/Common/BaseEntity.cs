using System.Xml.Serialization;

namespace SportClubManager.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [XmlElement("Profession")]
        public int Category { get; set; }
    }
}
