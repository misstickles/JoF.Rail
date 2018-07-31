namespace JoF.Rail.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [Serializable, XmlRoot(Namespace = "http://nationalrail.co.uk/xml/serviceindicator", ElementName = "NSI")]
    public class NetworkOverviewModel
    {
        public NetworkOverviewModel()
        {
            Tocs = new List<Toc>();
        }

        [XmlElement("TOC")]
        public List<Toc> Tocs { get; set; }

        [XmlType("TOC")]
        public class Toc
        {
            //public Toc()
            //{
            //    ServiceGroups = new List<ServiceGroup>();
            //}

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

            //[XmlElement("ServiceGroup")]
            //public List<ServiceGroup> ServiceGroups { get; set; }

            //[XmlElement("TwitterAccount")]
            //public string TwitterAccount { get; set; }

            //[XmlElement("AdditionalInfo")]
            //public string AdditionalInfo { get; set; }
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
