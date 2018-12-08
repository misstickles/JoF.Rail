namespace JoF.Rail.Core.Models.HistoricalPerformance
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class MetricsModel
    {
        [JsonProperty(PropertyName = "header")]
        public HeaderClass Header { get; set; }

        [JsonProperty(PropertyName = "Services")]
        public IEnumerable<Service> Services { get; set; }

        public class HeaderClass
        {
            [JsonProperty(PropertyName = "from_location")]
            public string From { get; set; }

            [JsonProperty(PropertyName = "to_location")]
            public string To { get; set; }
        }

        public class Service
        {
            [JsonProperty(PropertyName = "serviceAttributesMetrics")]
            public ServiceAttributesMetric ServiceMetrics { get; set; }

            [JsonProperty(PropertyName = "Metrics")]
            public IEnumerable<Metric> Metrics { get; set; }

            public class ServiceAttributesMetric
            {
                [JsonProperty(PropertyName = "origin_location")]
                public string Origin { get; set; }

                [JsonProperty(PropertyName = "destination_location")]
                public string Destination { get; set; }

                [JsonProperty(PropertyName = "gbtt_ptd")]
                public string OriginDepartureTime { get; set; }

                [JsonProperty(PropertyName = "gbtt_pta")]
                public string DestinationArrivalTime { get; set; }

                [JsonProperty(PropertyName = "toc_code")]
                public string Toc { get; set; }

                [JsonProperty(PropertyName = "matched_services")]
                public int ServicesCount { get; set; }

                [JsonProperty(PropertyName = "rids")]
                public IEnumerable<string> Rids { get; set; }
            }

            public class Metric
            {
                [JsonProperty(PropertyName = "tolerance_value")]
                public int Tolerance { get; set; }

                [JsonProperty(PropertyName = "num_not_tolerance")]
                public int NotInToleranceCount { get; set; }

                [JsonProperty(PropertyName = "num_tolerance")]
                public int InToleranceCount { get; set; }

                [JsonProperty(PropertyName = "percent_tolerance")]
                public int InTolerancePercent { get; set; }

                [JsonProperty(PropertyName = "global_tolerance")]
                public bool GlobalTolerance { get; set; }
            }
        }
    }
}
