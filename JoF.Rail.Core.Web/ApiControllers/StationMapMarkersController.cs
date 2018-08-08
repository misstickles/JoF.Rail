﻿namespace JoF.Rail.Core.Web.ApiControllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using JoF.Rail.Standard.Core.Extensions;
    using JoF.Rail.Standard.Models.Map;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/StationMapMarkers")]
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

            using (StreamReader r = File.OpenText(@"E:\Git\JoF.Rail\Data\KbStations.xml"))
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
            using (StreamReader r = File.OpenText(@"E:\Git\JoF.Rail\JoF.Rail.Core.Web\Data\NatRailStations.json"))
            {
                var data = r.ReadToEnd();
                return data.DeserialiseJson<StationLocation>();
            }
        }
    }
}
