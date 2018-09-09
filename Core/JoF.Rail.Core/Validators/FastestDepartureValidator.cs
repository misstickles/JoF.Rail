namespace JoF.Rail.Core.Validators
{
    using FluentValidation;
    using JoF.Rail.Core.Extensions;
    using JoF.Rail.Core.Models.LiveDepartureBoard.Query;

    public class FastestDepartureValidator : AbstractValidator<FastestDepartureQuery>
    {
        public FastestDepartureValidator()
        {
            // TODO: spec says exclusive, but I'm assuming that's wrong!
            this.RuleFor(m => m.AccessToken).NotNull();
            this.RuleFor(m => m.Crs).NotEmpty().IsValidCrsCode();
            this.RuleFor(m => m.FilterCrs).NotEmpty().IsValidCrsCode();
            this.RuleFor(m => m.TimeOffset).InclusiveBetween(-120, 120);
            this.RuleFor(m => m.TimeWindow).InclusiveBetween(-120, 120);
        }
    }
}
