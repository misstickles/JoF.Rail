namespace JoF.Rail.Core.Web.Features.Historical
{
    using System.Threading.Tasks;
    using JoF.Rail.Core.Web.Consts;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class HistoricalController : Controller
    {
        private readonly IMediator mediator;

        private readonly IConfiguration configuration;

        private readonly string user;

        private readonly string password;

        private readonly string baseUrl;

        public HistoricalController(IMediator mediator, IConfiguration configuration)
        {
            this.mediator = mediator;
            this.configuration = configuration;

            this.user = configuration[ConfigKey.NatRail.User];
            this.password = configuration[ConfigKey.NatRail.Key];
            this.baseUrl = configuration[ConfigKey.NatRail.HspBaseUrl];
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Metrics(Index.QueryMetrics query)
        {
            query.User = this.user;
            query.Key = this.password;
            query.Url = this.baseUrl + this.configuration[ConfigKey.NatRail.HspMetricsUrl];

            var metrics = await this.mediator.Send(query);

            return View(metrics);
        }

        [HttpPost]
        public async Task<IActionResult> Detail(string rid)
        {
            var query = new Index.QueryDetails
            {
                Rid = rid,
                User = this.user,
                Key = this.password,
                Url = this.baseUrl + this.configuration[ConfigKey.NatRail.HspDetailsUrl]
            };

            var details = await this.mediator.Send(query);

            return PartialView("_Detail", details);
        }
    }
}
