namespace JoF.Rail.Core.Validators
{
    using FluentValidation;
    using JoF.Rail.Core.Extensions;
    using JoF.Rail.Core.Models.LiveDepartureBoard.Query;

    public class StationBoardValidator : AbstractValidator<StationBoardQuery>
    {
        public StationBoardValidator()
        {
            // TODO: spec says exclusive, but I'm assuming that's wrong!
            // TODO: setting up validation twice??  Once in Query and once in Validator
            this.RuleFor(m => m.AccessToken).NotNull();
            this.RuleFor(m => m.Crs).IsValidCrsCode();
            this.RuleFor(m => m.FilterCrs).IsValidCrsCode();
            this.RuleFor(m => m.Type).IsInEnum();
            this.RuleFor(m => m.NumberRows).NotNull().InclusiveBetween(0, 10);
            this.RuleFor(m => m.TimeOffset).InclusiveBetween(-120, 119);
            this.RuleFor(m => m.TimeWindow).InclusiveBetween(0, 120);
        }
    }
}
