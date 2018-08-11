using Newtonsoft.Json;

namespace JoF.Rail.Standard.Models.HistoricalPerformance
{
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
