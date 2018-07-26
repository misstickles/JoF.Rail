namespace JoF.Rail.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NetworkOverview
    {
        IEnumerable<Toc> Tocs { get; set; }

        public class Toc
        {
            public string TocCode { get; set; }

            public string TocName { get; set; }

            public string Status { get; set; }

            public string StatusImage { get; set; }

            public IEnumerable<ServiceGroup> ServiceGroups { get; set; }

            public string TwitterAccount { get; set; }

            public string AdditionalInfo { get; set; }
        }

        public class ServiceGroup {
            public string GroupName { get; set; }

            public string CurrentDisruption { get; set; }

            public string CustomDetail { get; set; }

            public string CustomURL { get; set; }
        }

    }
}
