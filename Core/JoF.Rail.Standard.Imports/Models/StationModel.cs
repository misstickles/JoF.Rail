namespace JoF.Rail.Standard.Imports.Models
{
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// A class for the station data the we actually need
    /// </summary>
    [XmlRoot("Station")]
    public class StationModel
    {
        [XmlElement("CrsCode")]
        public string CrsCode { get; set; }

        [XmlElement("AlternativeIdentifiers/NationalLocationCode")]
        public string NationalLocationCode { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("SixteenCharacterName")]
        public string SixteenCharacterName { get; set; }

        [XmlElement("Latitude")]
        public double Latitude { get; set; }

        [XmlElement("Longitude")]
        public double Longitude { get; set; }

        [XmlElement("StationOperator")]
        public string StationOperator { get; set; }

        [XmlElement("TrainOperatingCompanies")]
        public List<Toc> Tocs { get; set; }

        [XmlType("TrainOperatingCompanies")]
        public class Toc
        {
            [XmlElement("TocRef")]
            public string Ref { get; set; }
        }
    }
}
