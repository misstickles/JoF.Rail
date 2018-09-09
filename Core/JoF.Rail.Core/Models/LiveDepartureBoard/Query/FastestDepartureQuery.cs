namespace JoF.Rail.Core.Models.LiveDepartureBoard.Query
{
    using System.ComponentModel.DataAnnotations;

    public class FastestDepartureQuery : Query
    {
        [StringLength(3)]
        [Required(ErrorMessage = "Station")]
        public string Crs { get; set; }

        // TODO: this would be a list, but need to handle on front end...
        [StringLength(3, ErrorMessage = "Stuff is crap")]
        [Required(ErrorMessage = "Stopping at is required for Fastest services.")]
        public string FilterCrs { get; set; }

        [Range(-120, 120)]
        public int TimeOffset { get; set; } = 0;

        [Range(0, 120)]
        public int TimeWindow { get; set; } = 120;

        public string StationName { get; set; }

        public string FilterStationName { get; set; }
    }
}
