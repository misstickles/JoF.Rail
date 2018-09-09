namespace JoF.Rail.Core.Models.LiveDepartureBoard.Result
{
    using JoF.Rail.Core.Enums;

    public class CoachModel
    {
        public CoachClass Class { get; set; }

        public int Loading { get; set; }

        public string Number { get; set; }

        public ToiletAvailabilityModel Toilet { get; set; }
    }
}
