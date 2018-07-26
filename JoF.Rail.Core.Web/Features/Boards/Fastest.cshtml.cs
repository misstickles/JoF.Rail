namespace JoF.Rail.Core.Web.Features.Boards
{
    using System.Threading;
    using System.Threading.Tasks;
    using JoF.Rail.Standard.Models.LiveDepartureBoard.Query;
    using JoF.Rail.Standard.Models.LiveDepartureBoard.Result;
    using JoF.Rail.Standard.Services;
    using JoF.Rail.Standard.Validators;
    using MediatR;

    public class Fastest
    {
        public class Validator : FastestDepartureValidator
        {
        }

        public class Query : FastestDepartureQuery, IRequest<DeparturesBoardModel>
        {
        }

        public class Handler : IRequestHandler<Query, DeparturesBoardModel>
        {
            // TODO: when impl DI
            //private readonly IArrivalsDeparturesBoardService arrivalsDeparturesBoardService;

            //public QueryHandler(IArrivalsDeparturesBoardService arrivalsDeparturesBoardService)
            //{
            //    this.arrivalsDeparturesBoardService = arrivalsDeparturesBoardService;
            //}

            public async Task<DeparturesBoardModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var service = new FastestDepartureService();
                //return await this.arrivalsDeparturesBoardService.GetBoard(request);
                return await service.GetFastest(request);
            }
        }
    }
}