namespace JoF.Rail.Core.Models.HistoricalPerformance
{
    using Newtonsoft.Json;

    public class Query
    {
        [JsonIgnore]
        public string Url { get; set; }

        [JsonIgnore]
        public string User { get; set; }

        [JsonIgnore]
        public string Key { get; set; }
    }
}
