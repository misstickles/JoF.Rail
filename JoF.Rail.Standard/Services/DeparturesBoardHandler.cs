namespace JoF.Rail.Standard.Handlers
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using FluentValidation;
    using JoF.Rail.Standard.Extensions;
    using JoF.Rail.Service.LiveDepartureBoards;

    public class DeparturesBoardHandler
    {
        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                // TODO: spec says exclusive, but I'm assuming that's wrong!
                this.RuleFor(m => m.AccessToken).NotNull();
                this.RuleFor(m => m.Crs).NotNull().IsValidCrsCode();
                this.RuleFor(m => m.FilterCrs).IsValidCrsCode();
                this.RuleFor(m => m.Type).IsInEnum();
                this.RuleFor(m => m.NumberRows).NotNull().InclusiveBetween(0, 10);
                this.RuleFor(m => m.TimeOffset).InclusiveBetween(-120, 120);
                this.RuleFor(m => m.TimeWindow).InclusiveBetween(-120, 120);
            }
        }

        public class Query : QueryModel, IRequest<StationBoardModel>
        {
            [StringLength(3, MinimumLength = 3)]
            [Required]
            [Display(Name = "Station")]
            public string Crs { get; set; }

            [StringLength(3)]
            [Display(Name = "Via Station")]
            public string FilterCrs { get; set; } = string.Empty;

            [Display(Name = "From / To Here")]
            public Enums.FilterType Type { get; set; } = Enums.FilterType.Departures;

            [Range(0, 10)]
            public int NumberRows { get; set; } = 10;

            [Range(-120, 120)]
            [Display(Name = "Time Offset")]
            public int TimeOffset { get; set; } = 0;

            [Range(-120, 120)]
            [Display(Name = "Time Window")]
            public int TimeWindow { get; set; } = 120;
        }

        public class QueryHandler : IRequestHandler<Query, StationBoardModel>
        {
            public async Task<StationBoardModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var endpoint = default(LDBServiceSoapClient.EndpointConfiguration);
                var svc = new LDBServiceSoapClient(endpoint);
                var board = await svc.GetDepartureBoardAsync(Mapper.Map<GetDepartureBoardRequest>(request));

                return Mapper.Map<StationBoardModel>(board);
            }
        }
    }
}