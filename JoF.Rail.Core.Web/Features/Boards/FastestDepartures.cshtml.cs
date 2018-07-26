namespace JoF.Rail.Core.Pages.Boards
{
    using System.Threading.Tasks;
    using JoF.Rail.Core.Handlers;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class FastestDepartures : PageModel
    {
        private readonly IMediator mediator;

        [BindProperty]
        public FastestDeparturesHandler.Query Query { get; set; }

        [BindProperty]
        public FastestDeparturesHandler.Result Board { get; set; }

        public FastestDepartures(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task OnGet()
        {
            var query = new FastestDeparturesHandler.Query
            {
                Crs = "HHE",
                FilterCrsList = "ECR",
                TimeOffset = 0,
                TimeWindow = 120
            };

//            var board = await this.mediator.Send(query);

        }

        public async Task OnPost()
        {
            this.Board = await this.mediator.Send(this.Query);
        }
    }
}