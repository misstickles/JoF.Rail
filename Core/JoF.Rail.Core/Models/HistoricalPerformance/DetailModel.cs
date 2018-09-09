using System.Collections.Generic;
using Newtonsoft.Json;

namespace JoF.Rail.Core.Models.HistoricalPerformance
{
    public class DetailModel
    {
        [JsonProperty(PropertyName = "serviceAttributesDetails")]
        public Details Detail { get; set; }

        public class Details
        {
            [JsonProperty(PropertyName = "date_of_service")]
            public string DateOfService { get; set; }

            [JsonProperty(PropertyName = "toc_code")]
            public string Toc { get; set; }

            [JsonProperty(PropertyName = "rid")]
            public string Rid { get; set; }

            [JsonProperty(PropertyName = "locations")]
            public IEnumerable<LocationClass> Locations { get; set; }

            public class LocationClass
            {
                [JsonProperty(PropertyName = "location")]
                public string Location { get; set; }

                [JsonProperty(PropertyName = "gbtt_ptd")]
                public string TimeDeparturePublic { get; set; }

                [JsonProperty(PropertyName = "gbtt_pta")]
                public string TimeArrivalPublic { get; set; }

                [JsonProperty(PropertyName = "actual_td")]
                public string TimeDepartureActual { get; set; }

                [JsonProperty(PropertyName = "actual_ta")]
                public string TimeArrivalActual { get; set; }

                [JsonProperty(PropertyName = "late_canc_reason")]
                public string LateCode { get; set; }
            }
        }

    }
}
