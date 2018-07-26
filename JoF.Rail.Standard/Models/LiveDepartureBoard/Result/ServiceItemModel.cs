namespace JoF.Rail.Standard.Models.LiveDepartureBoard.Result
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using JoF.Rail.Standard.Enums;

    public class ServiceItemModel
    {
        public IEnumerable<ServiceLocationModel> Origins { get; set; }

        public IEnumerable<ServiceLocationModel> Destinations { get; set; }

        public IEnumerable<ServiceLocationModel> CurrentOrigins { get; set; }

        public IEnumerable<ServiceLocationModel> CurrentDestinations { get; set; }

        // added to check for change in origins
        public bool HasChangedOrigin { get; set; }

        // added to check for change in destinations
        public bool HasChangedDestination { get; set; }

        public string ScheduledTimeArrival { get; set; }

        public string EstimatedTimeArrival { get; set; }

        public string EstimatedTimeArrivalDelay { get; set; }

        public string ScheduledTimeDeparture { get; set; }

        public string EstimatedTimeDeparture { get; set; }

        public string EstimatedTimeDepartureDelay { get; set; }

        public string Platform { get; set; }

        public string Operator { get; set; }

        public string OperatorCode { get; set; }

        public bool IsCircularRoute { get; set; }

        public bool IsCancelled { get; set; }

        public bool IsFilterLocationCancelled { get; set; }

        public ServiceType ServiceType { get; set; }

        public ushort TrainLength { get; set; }

        public bool IsDetachedHere { get; set; }

        public bool IsReverseFormation { get; set; }

        public string CancellationReason { get; set; }

        public string DelayReason { get; set; }

        public string ServiceId { get; set; }

        public Guid Guid { get; set; }

        public Collection<string> AdhocAlerts { get; set; }

        public IEnumerable<CallingPointsModel> PreviousCallingPoints { get; set; }

        public IEnumerable<CallingPointsModel> SubsequentCallingPoints { get; set; }

        public FormationModel Formation { get; set; }
    }
}
