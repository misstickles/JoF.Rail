namespace JoF.Rail.Core.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

#pragma warning disable SA1300 // Element must begin with upper-case letter
    public class ServiceMetrics
    {
        public HeaderClass header { get; set; }

        public IEnumerable<ServicesClass> Services { get; set; }

        public class HeaderClass
        {
            public string from_location { get; set; }

            public string to_location { get; set; }
        }

        public class ServicesClass
        {
            public ServiceAttributesMetricsClass serviceAttributesMetrics { get; set; }

            public MetricsClass Metrics { get; set; }

            public class ServiceAttributesMetricsClass
            {
                public string origin_location { get; set; }

                public string destination_location { get; set; }

                public string gbtt_ptd { get; set; }

                public string gbtt_pta { get; set; }

                public string toc_code { get; set; }

                public string matched_services { get; set; }

                public Collection<string> rids { get; set; }
            }

            public class MetricsClass
            {
                public string tolerance_value { get; set; }

                public string num_not_tolerance { get; set; }

                public string num_tolerance { get; set; }

                public string percent_tolerance { get; set; }

                public bool global_tolerance { get; set; }
            }
        }
    }
}
#pragma warning restore SA1300 // Element must begin with upper-case letter
