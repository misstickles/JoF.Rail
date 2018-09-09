namespace JoF.Rail.Models.NationalRail.PportTimetable
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("LateRunningReasons")]
    public class LateRunningReasons
    {
        public LateRunningReasons()
        {
            this.LateReasons = new List<Reasons>();
        }

        [XmlElement("Reason")]
        public List<Reasons> LateReasons { get; set; }
    }

    [XmlType("CancellationReasons")]
    public class CancellationReasons
    {
        public CancellationReasons()
        {
            this.CancelReasons = new List<Reasons>();
        }

        [XmlElement("Reason")]
        public List<Reasons> CancelReasons { get; set; }
    }

    public class Reasons
    {
        [XmlAttribute("code")]
        public string Code { get; set; }

        [XmlAttribute("reasontext")]
        public string ReasonText { get; set; }
    }
}
