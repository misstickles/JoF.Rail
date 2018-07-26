namespace JoF.Rail.Standard.Models.LiveDepartureBoard.Result
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class ServiceDetailsModel
    {
        public DateTime GeneratedAt { get; set; }

        public string Rsid { get; set; }

        public string ServiceType { get; set; }

        public string Location { get; set; }

        public string Crs { get; set; }

        public string Operator { get; set; }

        public string OperatorCode { get; set; }

        public bool IsCancelled { get; set; }

        public string CancellationReason { get; set; }

        public string DelayReason { get; set; }

        public string OverdueMessage { get; set; }

        public int TrainLength { get; set; }

        public bool IsDetachedHere { get; set; }

        public bool IsReverseFormation { get; set; }

        public string Platform { get; set; }

        public string ScheduledTimeArrival { get; set; }

        public int ScheduledTimeArrivalOffset { get; set; }

        public string EstimatedTimeArrival { get; set; }

        public string ActualTimeArrival { get; set; }

        public string ScheduledTimeDeparture { get; set; }

        public int ScheduledTimeDepartureOffset { get; set; }

        public string EstimatedTimeDeparture { get; set; }

        public string ActualTimeDeparture { get; set; }

        public Collection<string> AdhocAlerts { get; set; }

        public IEnumerable<CallingPointModel> PreviousCallingPoints { get; set; }

        public IEnumerable<CallingPointModel> SubsequentCallingPoints { get; set; }
    }
}
