namespace JoF.Rail.Web.ApiControllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using JoF.Rail.Core.Extensions;
    using JoF.Rail.Core.Models.Map;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[Controller]")]
    [ApiController]
    public class StationMapMarkersController
    {
        // TODO: create type for station codes (CRS)
        // TODO: use List, not , delimited
        // TODO: create ReadJsonFile method
        [HttpGet]
        public async Task<IEnumerable<StationLocation>> Get(string[] stationCodes)
        {
            IEnumerable<StationLocation> stations;

            using (StreamReader r = File.OpenText(@"~/../Data/KbStations.xml"))
            {
                var data = r.ReadToEnd();
                stations = data.DeserialiseJson<IEnumerable<StationLocation>>();
            }

            return null;
//            return stations.Where(s => stationCodes.Contains(s.Stations.CrsCode));
        }

        [HttpGet("All")]
        public async Task<StationLocation> All()
        {
            using (StreamReader r = File.OpenText(@"~/../Data/KbStations.json"))
            {
                var data = r.ReadToEnd();
                return data.DeserialiseJson<StationLocation>();
            }
        }
    }
}
