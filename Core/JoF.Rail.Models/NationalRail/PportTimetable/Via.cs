namespace JoF.Rail.Models.NationalRail.PportTimetable
{
    using System.Xml.Serialization;

    public class Via
    {
        [XmlAttribute("at")]
        public string At { get; set; }

        [XmlAttribute("dest")]
        public string Dest { get; set; }

        [XmlAttribute("Loc1")]
        public string Loc1 { get; set; }

        [XmlAttribute("viatext")]
        public string ViaText { get; set; }

        [XmlAttribute("loc2")]
        public string Loc2 { get; set; }
    }
}
