namespace JoF.Rail.Core.Web.ApiControllers
{
    using System.Threading.Tasks;
    using JoF.Rail.Core.Web.Consts;
    using JoF.Rail.Standard.Interfaces;
    using JoF.Rail.Standard.Models.HistoricalPerformance;
    using JoF.Rail.Standard.Services.HistoricalPerformance;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    [Route("api/[controller]")]
    [ApiController]
    public class HistoricalPerformanceController : ControllerBase
    {
        private readonly IHistoricalPerformanceService historicalPerformanceService;

        private readonly string user;

        private readonly string password;

        public HistoricalPerformanceController(IConfiguration configuration)
        {
            this.historicalPerformanceService = new HistoricalPerformanceService();

            this.user = configuration[ConfigKey.NatRail.User];
            this.password = configuration[ConfigKey.NatRail.Key];
        }

        [HttpGet("Metrics")]
        public async Task<MetricsModel> Metrics([FromBody] MetricsQuery query)
        {
            query.User = this.user;
            query.Key = this.password;

            return await this.historicalPerformanceService.Metrics(query);
        }

        [HttpGet("Detail/{rid:alpha}")]
        public async Task<DetailModel> Detail(string rid)
        {
            return await this.historicalPerformanceService.Detail(
                new DetailQuery {
                    User = this.user,
                    Key = this.password,
                    Rid = rid
                });
        }
    }
}