namespace JoF.Rail.Standard.Models.LiveDepartureBoard.Result
{
    using System.Collections.Generic;

    public class CallingPointModel
    {
        public string Location { get; set; }

        public string Crs { get; set; }

        public string ScheduledTime { get; set; }

        public string EstimatedTime { get; set; }

        public string EstimatedTimeDelay { get; set; }

        public string ActualTime { get; set; }

        public string ActualTimeDelay { get; set; }

        public bool IsCancelled { get; set; }

        public int TrainLength { get; set; }

        public bool IsDetachedHere { get; set; }

        public IEnumerable<string> AdHocAlerts { get; set; }
    }
}
