namespace JoF.Rail.Core.Models.LiveDepartureBoard.Result
{
    using System.Collections.Generic;
    using JoF.Rail.Core.Enums;

    public class CallingPointsModel
    {
        public IEnumerable<CallingPointModel> CallingPoints { get; set; }

        public ServiceType ServiceType { get; set; }

        public bool RequiresServiceChange { get; set; }

        public bool IsAssociatedCancelled { get; set; }
    }
}
