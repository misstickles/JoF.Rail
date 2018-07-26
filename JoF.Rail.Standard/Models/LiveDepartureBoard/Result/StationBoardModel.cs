namespace JoF.Rail.Standard.Models.LiveDepartureBoard.Result
{
    using System.Collections.Generic;
    using JoF.Rail.Standard.Enums;
    using JoF.Rail.Standard.Interfaces;

    public class StationBoardModel : IEntity
    {
        public string GeneratedAt { get; set; }

        public string Location { get; set; }

        // computer reservation system
        public string Crs { get; set; }

        public string FilterLocation { get; set; }

        public string FilterCrs { get; set; }

        public FilterType FilterType { get; set; }

        public IEnumerable<string> Messages { get; set; }

        public bool HasPlatform { get; set; }

        public bool HasServices { get; set; }

        public IEnumerable<ServiceItemModel> Services { get; set; }
    }
}