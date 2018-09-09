namespace JoF.Rail.Models.NationalRail.PportTimetable
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [Serializable]
    [XmlRoot(Namespace="http://www.thalesgroup.com/rtti/XmlRefData/v3", ElementName= "PportTimetableRef", IsNullable =true)]
    public class PportTimetable
    {
        public PportTimetable()
        {
            this.Locations = new List<LocationRef>();
            this.Tocs = new List<TocRef>();
            this.Vias = new List<Via>();
            this.CisSources = new List<CisSource>();
        }

        [XmlElement("LocationRef")]
        public List<LocationRef> Locations { get; set; }

        [XmlElement("TocRef")]
        public List<TocRef> Tocs { get; set; }

        [XmlElement("LateRunningReasons")]
        public LateRunningReasons LateReasons { get; set; }

        [XmlElement("CancellationReasons")]
        public CancellationReasons CancelReasons { get; set; }

        [XmlElement("Via")]
        public List<Via> Vias { get; set; }

        [XmlElement("CISSource")]
        public List<CisSource> CisSources { get; set; }
    }
}
