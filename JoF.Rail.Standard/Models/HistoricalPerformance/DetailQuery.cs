namespace JoF.Rail.Standard.Models.HistoricalPerformance
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class DetailQuery : Query
    {
        [Required(ErrorMessage = "Required")]
        [JsonProperty(PropertyName = "rid")]
        public string Rid { get; set; }
    }
}
