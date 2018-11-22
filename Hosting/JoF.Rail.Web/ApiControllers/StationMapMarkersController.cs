namespace JoF.Rail.Web.ApiControllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using JoF.Rail.Core.Extensions;
    using JoF.Rail.Core.Models;
    using JoF.Rail.Core.Models.Map;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json.Linq;

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
            using (StreamReader sr = File.OpenText(@"~/../Data/operatorCodes.json"))
            {
                // TODO: JObject is a bit lazy...
                var opCodes = sr.ReadToEnd().DeserialiseJson<OperatorCodes>();

                using (StreamReader r = File.OpenText(@"~/../Data/KbStations.json"))
                {
                    var data = r.ReadToEnd();
                    var stations = data.DeserialiseJson<StationLocation>();

                    var join = stations.Stations
                        .Join(
                            opCodes.Operators,
                            stn => stn.Operator,
                            op => op.Code,
                            (stn, op) => new StationLocation.Station { Name = stn.Name, Operator = op.Name, Latitude = stn.Latitude, Longitude = stn.Longitude, CrsCode = stn.CrsCode });

                    return new StationLocation { Stations = join };
                }
            }
        }
    }
}
