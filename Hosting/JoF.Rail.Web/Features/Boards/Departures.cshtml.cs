namespace JoF.Rail.Web.Features.Boards
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using JoF.Rail.Core.Models.LiveDepartureBoard.Query;
    using JoF.Rail.Core.Models.LiveDepartureBoard.Result;
    using JoF.Rail.Core.Services;
    using JoF.Rail.Core.Validators;
    using MediatR;

    public class Departures
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

                var result = await service.GetBoard(request);

                // TODO: Map
                return new StationBoardViewModel
                {
                    Crs = result.Crs,
                    FilterCrs = result.FilterCrs,
                    FilterLocation = result.FilterLocation,
                    FilterType = result.FilterType,
                    GeneratedAt = result.GeneratedAt,
                    HasPlatform = result.HasPlatform,
                    HasServices = result.HasServices,
                    Location = result.Location,
                    Messages = result.Messages,
                    Services = result.Services
                };
            }
        }
    }
}
