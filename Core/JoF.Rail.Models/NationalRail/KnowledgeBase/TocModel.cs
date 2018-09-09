namespace JoF.Rail.Models.NationalRail.KnowledgeBase
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// A class for the station data the we actually need
    /// </summary>
    [Serializable]
    [XmlRoot(Namespace = "http://nationalrail.co.uk/xml/station", ElementName = "TrainOperatingCompanyList")]
    public class TocModel
    {
        public TocModel()
        {
            this.Tocs = new List<Toc>();
        }

        [XmlElement("TrainOperatingCompany")]
        public List<Toc> Tocs { get; set; }

        [XmlType("TrainOperatingCompany")]
        public class Toc
        {
            [XmlElement("AtocCode")]
            public string AtocCode { get; set; }

            [XmlElement("AtocMember")]
            public bool IsAtocMember { get; set; }

            [XmlElement("StationOperator")]
            public bool IsStationOperator { get; set; }

            [XmlElement("Name")]
            public string Name { get; set; }

            [XmlElement("LegalName")]
            public string LegalName { get; set; }

            [XmlElement("Logo")]
            public string Logo { get; set; }

            [XmlElement("NetworkMap")]
            public string NetworkMap { get; set; }

            public OperatingPeriod Period { get; set; }

            [XmlElement("CompanyWebsite")]
            public string Website { get; set; }

            [XmlType("OperatingPeriod")]
            public class OperatingPeriod
            {
            }
        }
    }
}
