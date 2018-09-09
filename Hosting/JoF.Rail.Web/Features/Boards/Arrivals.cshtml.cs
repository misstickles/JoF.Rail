namespace JoF.Rail.Web.Features.Boards
{
    using System.Threading;
    using System.Threading.Tasks;
    using JoF.Rail.Core.Models.LiveDepartureBoard.Query;
    using JoF.Rail.Core.Models.LiveDepartureBoard.Result;
    using JoF.Rail.Core.Services;
    using JoF.Rail.Core.Validators;
    using MediatR;

    // TODO: Arrivals is exactly the same as departures - reuse??
    public class Arrivals
    {
        public class Validator : StationBoardValidator
        {
        }

        public class Query : StationBoardQuery, IRequest<StationBoardModel>
        {
        }

        public class Handler : IRequestHandler<Query, StationBoardModel>
        {
            // TODO: when impl DI
            //private readonly IArrivalsDeparturesBoardService arrivalsDeparturesBoardService;

            //public QueryHandler(IArrivalsDeparturesBoardService arrivalsDeparturesBoardService)
            //{
            //    this.arrivalsDeparturesBoardService = arrivalsDeparturesBoardService;
            //}

            public async Task<StationBoardModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var service = new StationBoardService();
                return await service.GetBoard(request);
            }
        }
    }
}
