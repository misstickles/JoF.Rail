namespace JoF.Rail.Standard.Models.LiveDepartureBoard.Result
{
    using System.Collections.Generic;
    using JoF.Rail.Standard.Enums;

    public class CallingPointsModel
    {
        public IEnumerable<CallingPointModel> CallingPoints { get; set; }

        public ServiceType ServiceType { get; set; }

        public bool RequiresServiceChange { get; set; }

        public bool IsAssociatedCancelled { get; set; }
    }
}
