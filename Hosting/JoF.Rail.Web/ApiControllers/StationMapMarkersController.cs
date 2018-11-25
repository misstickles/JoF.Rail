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
            // TODO: move join to import
            using (StreamReader sr = File.OpenText(@"~/../Data/operatorCodes.json"))
            {
                var opCodes = sr.ReadToEnd().DeserialiseJson<OperatorCodes>();

                using (StreamReader r = File.OpenText(@"~/../Data/KbStations.json"))
                {
                    var data = r.ReadToEnd();
                    var stations = data.DeserialiseJson<StationLocation>();

                    var result = stations.Stations
                        .Join(
                            opCodes.Operators,
                            stn => stn.Operator,
                            op => op.Code,
                            (stn, op) => new StationLocation.Station
                            {
                                AltIds = stn.AltIds,
                                Crs = stn.Crs,
                                Facilities = stn.Facilities,
                                Fare = stn.Fare,
                                Lat = stn.Lat,
                                Long = stn.Long,
                                Name = stn.Name,
                                Operator = op.Code,
                                OperatorName = op.Name,
                                OperatorColour = op.Colour,
                                Postcode = stn.Postcode,
                                SixtnCharName = stn.SixtnCharName,
                                Tocs = stn.Tocs
                                    .Join(
                                        opCodes.Operators,
                                        toc => toc.Toc,
                                        code => code.Code,
                                        (toc, code) => new StationLocation.Station.TocRef { Toc = toc.Toc, TocName = code.Name, Colour = code.Colour, Type = code.Type })
                            });

                    return new StationLocation { Stations = result };
                }
            }
        }
    }
}
