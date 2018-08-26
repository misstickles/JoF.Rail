namespace JoF.Rail.Core.Web.ApiControllers
{
    using System.Threading.Tasks;
    using JoF.Rail.Core.Web.Consts;
    using JoF.Rail.Standard.Interfaces;
    using JoF.Rail.Standard.Models.HistoricalPerformance;
    using JoF.Rail.Standard.Services.HistoricalPerformance;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    [Route("api/[Controller]")]
    [ApiController]
    public class HistoricalPerformanceController : ControllerBase
    {
        private readonly IHistoricalPerformanceService historicalPerformanceService;

        private readonly IConfiguration configuration;

        private readonly string user;

        private readonly string password;

        private readonly string baseUrl;

        public HistoricalPerformanceController(IConfiguration configuration)
        {
            this.historicalPerformanceService = new HistoricalPerformanceService();
            this.configuration = configuration;

            this.user = configuration[ConfigKey.NatRail.User];
            this.password = configuration[ConfigKey.NatRail.Key];
            this.baseUrl = configuration[ConfigKey.NatRail.HspBaseUrl];
        }

        public async Task<MetricsModel> Metrics([FromBody] MetricsQuery query)
        {
            query.User = this.user;
            query.Key = this.password;

            return await this.historicalPerformanceService.Metrics(query);
        }

        [HttpGet("Detail/{rid}")]
        public async Task<DetailModel> Detail(string rid)
        {
            return await this.historicalPerformanceService.Detail(
                new DetailQuery {
                    User = this.user,
                    Key = this.password,
                    Rid = rid,
                    Url = this.baseUrl + this.configuration[ConfigKey.NatRail.HspDetailsUrl]
                });
        }
    }
}