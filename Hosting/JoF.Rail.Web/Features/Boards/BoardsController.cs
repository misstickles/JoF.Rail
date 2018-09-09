namespace JoF.Rail.Web.Features.Boards
{
    using System.Threading.Tasks;
    using JoF.Rail.Core.Enums;
    using JoF.Rail.Web.Consts;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    [Route("[controller]")]
    public class BoardsController : Controller
    {
        private readonly IMediator mediator;

        private readonly string accessToken;

        public BoardsController(IMediator mediator, IConfiguration configuration)
        {
            this.mediator = mediator;

            this.accessToken = configuration[ConfigKey.NatRail.AccessToken];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return this.View(new BoardsViewModel());
        }

        [Route("Arrivals")]
        public async Task<IActionResult> Arrivals(Arrivals.Query query)
        {
            query.AccessToken = this.accessToken;
            query.Type = FilterType.Arrivals;

            var board = await this.mediator.Send(query);

            return this.View("Arrivals", board);
        }

        [HttpGet]
        [Route("Arrivals/{crs:alpha:minLength(3):maxLength(3)}/{filterCrs:alpha:minLength(3):maxLength(3)?}")]
        public async Task<IActionResult> Arrivals(string crs, string filterCrs)
        {
            var board = await this.mediator.Send(new Arrivals.Query
            {
                AccessToken = this.accessToken,
                Crs = crs,
                FilterCrs = filterCrs,
                Type = FilterType.Arrivals
            });

            return this.View("Arrivals", board);
        }

        [Route("Departures")]
        public async Task<IActionResult> Departures(Departures.Query query)
        {
            query.AccessToken = this.accessToken;
            query.Type = FilterType.Departures;

            var board = await this.mediator.Send(query);

            return this.View("Departures", board);
        }

        [HttpGet]
        [Route("Departures/{crs:alpha:minLength(3):maxLength(3)}/{filterCrs:alpha:minLength(3):maxLength(3)?}")]
        public async Task<IActionResult> Departures(string crs, string filterCrs)
        {
            var board = await this.mediator.Send(new Departures.Query
            {
                AccessToken = this.accessToken,
                Crs = crs,
                FilterCrs = filterCrs,
                Type = FilterType.Departures
            });

            return this.View("Departures", board);
        }

        [Route("Fastest")]
        public async Task<IActionResult> Fastest(Fastest.Query query)
        {
            if (!this.ModelState.IsValid || string.IsNullOrEmpty(query.FilterCrs))
            {
                this.ModelState.AddModelError(nameof(query.FilterCrs), string.Empty);

                return this.View("Index");
            }

            query.AccessToken = this.accessToken;

            var board = await this.mediator.Send(query);

            return this.View("Fastest", board);
        }

        [HttpGet]
        [Route("Fastest/{crs:alpha:minLength(3):maxLength(3)}/{filterCrs:alpha:minLength(3):maxLength(3)}")]
        public async Task<IActionResult> Fastest(string crs, string filterCrs)
        {
            var board = await this.mediator.Send(new Fastest.Query
            {
                AccessToken = this.accessToken,
                Crs = crs,
                FilterCrs = filterCrs
            });

            return this.View("Fastest", board);
        }
    }
}