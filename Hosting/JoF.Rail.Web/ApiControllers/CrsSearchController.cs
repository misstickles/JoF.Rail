namespace JoF.Rail.Web.ApiControllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using JoF.Rail.Web.Data;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/CrsSearch")]
    [ApiController]
    public class CrsSearchController : ControllerBase
    {
        private readonly IReadOnlyDictionary<string, string> stations;

        public CrsSearchController()
        {
            this.stations = CrsStations.Names;
        }

        [HttpGet]
        public async Task<JsonResult> Get(string term)
        {
            var results = this.stations.Where(k => k.Key.Contains(term.ToUpper()) || k.Value.ToUpper().Contains(term.ToUpper()));
            return new JsonResult(results);
        }
    }
}