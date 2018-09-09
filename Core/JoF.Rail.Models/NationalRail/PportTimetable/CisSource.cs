namespace JoF.Rail.Models.NationalRail.PportTimetable
{
    using System.Xml.Serialization;

    public class CisSource
    {
        [XmlAttribute("code")]
        public string Code { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
