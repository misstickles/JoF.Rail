namespace JoF.Rail.Standard.Models.LiveDepartureBoard.Query
{
    using System.ComponentModel.DataAnnotations;

    public class StationBoardQuery : Query
    {
        [StringLength(3, MinimumLength = 3)]
        [Required(ErrorMessage = "Station is required")]
        [Display(Name = "Station")]
        public string Crs { get; set; }

        [StringLength(3, ErrorMessage = "Board Query Length invalid")]
        [Display(Name = "Stopping at")]
        public string FilterCrs { get; set; }

        [Display(Name = "From / To Here")]
        public Enums.FilterType Type { get; set; } = Enums.FilterType.Departures;

        [Range(0, 10)]
        public int NumberRows { get; set; } = 10;

        [Range(-120, 120)]
        [Display(Name = "Time Offset", Prompt = "0")]
        public int TimeOffset { get; set; } = 0;

        [Range(0, 120)]
        [Display(Name = "Time Window")]
        public int TimeWindow { get; set; } = 120;

        public string StationName { get; set; }

        public string FilterStationName { get; set; }
    }
}
