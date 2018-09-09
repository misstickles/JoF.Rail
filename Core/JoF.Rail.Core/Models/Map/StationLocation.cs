using System.Collections.Generic;

namespace JoF.Rail.Core.Models.Map
{
    public class StationLocation
    {
        public IEnumerable<Station> Stations { get; set; }

        public class Station
        {
            public string CrsCode { get; set; }

            public string Name { get; set; }

            public string Operator { get; set; }

            public double Latitude { get; set; }

            public double Longitude { get; set; }
        }
    }
}
