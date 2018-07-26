namespace JoF.Rail.Standard.Models.LiveDepartureBoard.Result
{
    using JoF.Rail.Standard.Enums;

    public class CoachModel
    {
        public CoachClass Class { get; set; }

        public int Loading { get; set; }

        public string Number { get; set; }

        public ToiletAvailabilityModel Toilet { get; set; }
    }
}
