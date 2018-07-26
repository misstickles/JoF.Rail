namespace JoF.Rail.Core.Web.Features.Boards
{
    using System.Threading;
    using System.Threading.Tasks;
    using JoF.Rail.Standard.Models.LiveDepartureBoard.Query;
    using JoF.Rail.Standard.Models.LiveDepartureBoard.Result;
    using JoF.Rail.Standard.Services;
    using JoF.Rail.Standard.Validators;
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
                //return await this.arrivalsDeparturesBoardService.GetBoard(request);
                return await service.GetBoard(request);
            }
        }
    }
}
