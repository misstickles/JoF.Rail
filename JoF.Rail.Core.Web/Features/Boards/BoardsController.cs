namespace JoF.Rail.Core.Web.Features.Boards
{
    using System.Threading.Tasks;
    using JoF.Rail.Core.Web.Consts;
    using JoF.Rail.Standard.Enums;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    [Route("[controller]")]
    public class BoardsController : Controller
    {
        private readonly IMediator mediator;

        private readonly IConfiguration configuration;

        private readonly string accessToken;

        public BoardsController(IMediator mediator, IConfiguration configuration)
        {
            this.mediator = mediator;

            this.accessToken = configuration[ConfigKey.NatRail.AccessToken];
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(new BoardsViewModel());
        }

        [Route("Arrivals")]
        public async Task<IActionResult> Arrivals(Arrivals.Query query)
        {
            query.AccessToken = this.accessToken;
            query.Type = FilterType.Arrivals;

            var board = await this.mediator.Send(query);

            return View("Arrivals", board);
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

            return View("Arrivals", board);
        }

        [Route("Departures")]
        public async Task<IActionResult> Departures(Departures.Query query)
        {
            query.AccessToken = this.accessToken;
            query.Type = FilterType.Departures;

            var board = await this.mediator.Send(query);

            return View("Departures", board);
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

            return View("Departures", board);
        }

        [Route("Fastest")]
        public async Task<IActionResult> Fastest(Fastest.Query query)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(query.FilterCrs))
            {
                ModelState.AddModelError(nameof(query.FilterCrs), string.Empty);

                return View("Index");
            }

            query.AccessToken = this.accessToken;

            var board = await this.mediator.Send(query);

            return View("Fastest", board);
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

            return View("Fastest", board);
        }
    }
}