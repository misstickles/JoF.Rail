namespace JoF.Rail.Standard.Models.HistoricalPerformance
{
    using System.ComponentModel.DataAnnotations;

    public class DetailQuery : Query
    {
        [Required(ErrorMessage = "Required")]
        public string Rid { get; set; }
    }
}
