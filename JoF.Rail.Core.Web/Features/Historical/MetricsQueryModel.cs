namespace JoF.Rail.Core.Web.Features.Historical
{
    public class MetricsQueryModel : Index.QueryMetrics
    {
        public string From { get; set; }

        public string To { get; set; }
    }
}
