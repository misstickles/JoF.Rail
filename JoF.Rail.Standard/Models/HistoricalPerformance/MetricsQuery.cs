namespace JoF.Rail.Standard.Models.HistoricalPerformance
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class MetricsQuery : Query
    {
        private static DateTime now = DateTime.Now;

        [JsonProperty(PropertyName = "from_loc")]
        [StringLength(3, MinimumLength = 3)]
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Between")]
        public string CrsFrom { get; set; } = "HHE";

        [JsonProperty(PropertyName = "to_loc")]
        [StringLength(3, MinimumLength = 3)]
        [Required(ErrorMessage = "Required")]
        [Display(Name = "And")]
        public string CrsTo { get; set; } = "ECR";

        [JsonProperty(PropertyName = "from_date")]
        [Required(ErrorMessage = "Required")]
        public string FromDate { get; set; } = now.AddMonths(-1).ToString("yyyy-MM-dd");

        [JsonProperty(PropertyName = "to_date")]
        [Required(ErrorMessage = "Required")]
        public string ToDate { get; set; } = now.ToString("yyyy-MM-dd");

        [JsonProperty(PropertyName = "from_time")]
        [Required(ErrorMessage = "Required")]
        public string FromTime { get; set; } = now.AddHours(-1).ToString("HHmm");

        [JsonProperty(PropertyName = "to_time")]
        [Required(ErrorMessage = "Required")]
        public string ToTime { get; set; } = now.ToString("HHmm");

        [JsonProperty(PropertyName = "days")]
        [Required(ErrorMessage = "Required")]
        public string Days { get; set; } = Enums.DayTypes.WEEKDAY.ToString();

        [JsonProperty(PropertyName = "tolerance")]
        public int[] Tolerances { get; set; } = new[] { 5, 10 };

        [JsonProperty(PropertyName = "toc_filter")]
        public string[] TocFilter { get; set; }
    }
}
