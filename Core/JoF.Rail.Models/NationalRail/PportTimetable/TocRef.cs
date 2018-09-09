namespace JoF.Rail.Models.NationalRail.PportTimetable
{
    using System.Xml.Serialization;

    public class TocRef
    {
        [XmlAttribute("toc")]
        public string Toc { get; set; }

        [XmlAttribute("tocname")]
        public string TocName { get; set; }

        [XmlAttribute("url")]
        public string Url { get; set; }
    }
}
