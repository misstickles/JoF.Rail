namespace JoF.Rail.Models.KnowledgeBase
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// A class for the station data the we actually need
    /// </summary>
    [Serializable, XmlRoot(Namespace = "http://nationalrail.co.uk/xml/station", ElementName = "StationList")]
    public class StationModel
    {
        public StationModel()
        {
            this.Stations = new List<Station>();
        }

        [XmlElement("Station")]
        public List<Station> Stations { get; set; }

        [XmlType("Station")]
        public class Station
        {
            public Station()
            {
                this.Tocs = new List<Toc>();
                this.AltIds = new List<AlternativeId>();
            }

            [XmlElement("CrsCode")]
            public string CrsCode { get; set; }

            [XmlElement("AlternativeIdentifiers")]
            public List<AlternativeId> AltIds { get; set; }

            [XmlElement("Name")]
            public string Name { get; set; }

            [XmlElement("SixteenCharacterName")]
            public string SixteenCharName { get; set; }

            [XmlElement("Latitude")]
            public double Latitude { get; set; }

            [XmlElement("Longitude")]
            public double Longitude { get; set; }

            [XmlElement("StationOperator")]
            public string Operator { get; set; }

            [XmlElement("TrainOperatingCompanies")]
            public List<Toc> Tocs { get; set; }

            [XmlType("TrainOperatingCompanies")]
            public class Toc
            {
                [XmlElement("TocRef")]
                public string Ref { get; set; }
            }

            [XmlType("AlternativeIdentifiers")]
            public class AlternativeId
            {
                [XmlElement("NationalLocationCode")]
                public string LocCode { get; set; }
            }
        }
    }
}
