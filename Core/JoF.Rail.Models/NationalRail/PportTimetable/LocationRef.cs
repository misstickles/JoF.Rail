namespace JoF.Rail.Models.NationalRail.PportTimetable
{
    using System.Xml.Serialization;

    public class LocationRef
    {
        [XmlAttribute("tpl")]
        public string Tpl { get; set; }

        [XmlAttribute("locname")]
        public string LocName { get; set; }

        [XmlAttribute("crs")]
        public string Crs { get; set; }

        [XmlAttribute("toc")]
        public string Toc { get; set; }
    }
}
