namespace JoF.Rail.Core.Web.Features.Historical
{
    using System.Collections.Generic;
    using JoF.Rail.Standard.Models.HistoricalPerformance;

    public class MetricsViewModel
    {
        public MetricsQuery Query { get; set; }

        public MetricsModel Data { get; set; }

        public string Chart { get; set; }

        public DetailModel Detail { get; set; }

        public IEnumerable<(int code, string reason, bool isCancelled)> Reasons { get; set; }
    }
}
