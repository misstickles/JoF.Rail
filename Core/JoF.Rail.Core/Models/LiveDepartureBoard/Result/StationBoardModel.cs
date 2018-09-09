namespace JoF.Rail.Core.Models.LiveDepartureBoard.Result
{
    using System.Collections.Generic;
    using JoF.Rail.Core.Enums;
    using JoF.Rail.Core.Interfaces;

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