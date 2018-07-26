namespace JoF.Rail.Standard.Models.LiveDepartureBoard.Result
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using JoF.Rail.Standard.Enums;
    using JoF.Rail.Standard.Interfaces;

    public class DeparturesBoardModel : IEntity
    {
        public string GeneratedAt { get; set; }

        public string Location { get; set; }

        public string Crs { get; set; }

        public string FilterLocation { get; set; }

        public string FilterCrs { get; set; }

        public FilterType FilterType { get; set; }

        public Collection<string> Messages { get; set; }

        public bool HasPlatform { get; set; }

        public bool HasServices { get; set; }

        public IEnumerable<DepartureModel> Departures { get; set; }
    }
}
