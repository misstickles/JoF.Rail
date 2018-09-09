namespace JoF.Rail.Core.Models
{
    using System.Collections.Generic;

#pragma warning disable SA1300 // Element must begin with upper-case letter
    public class ServiceDetails
    {
        public ServiceAttributesDetailsClass ServiceAttributesDetails { get; set; }

        public class ServiceAttributesDetailsClass
        {
            public string date_of_service { get; set; }

            public string toc_code { get; set; }

            public string rid { get; set; }

            public IEnumerable<LocationClass> locations { get; set; }

            public class LocationClass
            {
                public string location { get; set; }

                public string gbtt_ptd { get; set; }

                public string gbtt_pta { get; set; }

                public string actual_td { get; set; }

                public string actual_ta { get; set; }

                public string late_canc_reason { get; set; }
            }
        }
    }
}
#pragma warning restore SA1300 // Element must begin with upper-case letter
