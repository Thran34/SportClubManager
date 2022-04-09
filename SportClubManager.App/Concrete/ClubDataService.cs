using SportClubManager.Domain.Entity;
using System.Xml.Serialization;

namespace SportClubManager.App.Concrete
{
    public class ClubDataService
    {
        public ClubData clubData { get; private set; }

        public ClubDataService()
        {
            clubData = ReadClubDataFromXml();
        }
        public void SetClubData(string name, string dateOfForm, string discipline)

        {
            clubData.Name = name;
            clubData.DateOfForm = dateOfForm;
            clubData.Discipline = discipline;
        }
        public void SaveClubDataToXml()
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "ClubData";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ClubData), root);

            using (StreamWriter streamWriter = new StreamWriter(@"C:Temp\ClubData.xml"))
            {
                xmlSerializer.Serialize(streamWriter, clubData);
            }
        }

        public ClubData ReadClubDataFromXml()
        {
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "ClubData";
            root.IsNullable = true;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ClubData), root);
            if (!File.Exists(@"C:Temp\ClubData.xml"))
            {
                return new ClubData();
            }
            string xml = File.ReadAllText(@"C:Temp\ClubData.xml");
            StringReader stringReader = new StringReader(xml);
            var item = (ClubData)xmlSerializer.Deserialize(stringReader);
            return item;
        }
    }
}