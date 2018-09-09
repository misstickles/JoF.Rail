namespace JoF.Rail.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [Serializable]
    [XmlRoot(Namespace = "http://nationalrail.co.uk/xml/serviceindicator", ElementName = "NSI")]
    public class NetworkOverviewModel
    {
        public NetworkOverviewModel()
        {
            this.Tocs = new List<Toc>();
        }

        [XmlElement("TOC")]
        public List<Toc> Tocs { get; set; }

        [XmlType("TOC")]
        public class Toc
        {
            [XmlElement("TocCode")]
            public string TocCode { get; set; }

            [XmlElement("TocName")]
            public string TocName { get; set; }

            [XmlElement("Status")]
            public string Status { get; set; }

            [XmlElement("StatusImage")]
            public string StatusImage { get; set; }

            [XmlElement("StatusDescription")]
            public string StatusDescription { get; set; }
        }

        [XmlType("ServiceGroup")]
        public class ServiceGroup {
            [XmlElement("GroupName")]
            public string GroupName { get; set; }

            [XmlElement("CurrentDisruption")]
            public string CurrentDisruptionId { get; set; }

            [XmlElement("CustomDetail")]
            public string CustomDetail { get; set; }

            [XmlElement("CustomURL")]
            public string CustomURL { get; set; }
        }
    }
}
