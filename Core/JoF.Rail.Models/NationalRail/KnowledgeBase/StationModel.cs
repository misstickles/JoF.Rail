namespace JoF.Rail.Models.KnowledgeBase
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// A class for the station data the we actually need
    /// </summary>
    [Serializable]
    [XmlRoot(ElementName = "Stations")]
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
                this.Tocs = new List<OperatingCompanies>();
                this.AltIds = new List<AlternativeId>();
            }

            [XmlElement("AltIds")]
            public List<AlternativeId> AltIds { get; set; }

            [XmlElement("CrsCode")]
            public string Crs { get; set; }

            [XmlElement("Facilities")]
            public StationFacilities Facilities { get; set; }

            [XmlElement("Fare")]
            public Fares Fare { get; set; }

            [XmlElement("Latitude")]
            public double Lat { get; set; }

            [XmlElement("Longitude")]
            public double Long { get; set; }

            [XmlElement("Name")]
            public string Name { get; set; }

            [XmlElement("Operator")]
            public string Operator { get; set; }

            [XmlElement("Postcode")]
            public string Postcode { get; set; }

            [XmlElement("SixteenCharName")]
            public string SixtnCharName { get; set; }

            [XmlElement("Tocs")]
            public List<OperatingCompanies> Tocs { get; set; }

            [XmlType("Tocs")]
            public class OperatingCompanies
            {
                [XmlElement("Toc")]
                public string Toc { get; set; }
            }

            [XmlType("AltIds")]
            public class AlternativeId
            {
                [XmlElement("LocCode")]
                public string LocCode { get; set; }
            }

            [XmlType("Facilities")]
            public class StationFacilities
            {
                [XmlElement("Atm")]
                public string Atm { get; set; }

                [XmlElement("Toilet")]
                public string Toilet { get; set; }
            }

            [XmlType("Fare")]
            public class Fares
            {
                [XmlElement("Oyster")]
                public string Oyster { get; set; }

                [XmlElement("TktMachine")]
                public string TktMachine { get; set; }

                [XmlElement("TktOffice")]
                public string TktOffice { get; set; }
            }
        }
    }
}
