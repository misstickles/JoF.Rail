namespace JoF.Rail.Core.Profiles
{
    using System;
    using AutoMapper;
    using JoF.Rail.Core.Extensions;
    using JoF.Rail.Core.Models.LiveDepartureBoard.Query;
    using JoF.Rail.Core.Models.LiveDepartureBoard.Result;
    using LiveDepartureBoardsService;
    using FilterType = JoF.Rail.Core.Enums.FilterType;
    using ServiceType = JoF.Rail.Core.Enums.ServiceType;

    public class LiveDeparturesMappingProfile : Profile
    {
        public LiveDeparturesMappingProfile()
        {
            this.CreateMap<CallingPoint1, CallingPointModel>(MemberList.Destination)
                .ForMember(dest => dest.ActualTime, opt => opt.MapFrom(src => src.at))
                .ForMember(dest => dest.ActualTimeDelay, opt => opt.MapFrom(src => src.at.ToTimeDelay(src.st)))
                .ForMember(dest => dest.AdHocAlerts, opt => opt.MapFrom(src => src.adhocAlerts))
                .ForMember(dest => dest.Crs, opt => opt.MapFrom(src => src.crs))
                .ForMember(dest => dest.EstimatedTime, opt => opt.MapFrom(src => src.et))
                .ForMember(dest => dest.EstimatedTimeDelay, opt => opt.MapFrom(src => src.et.ToTimeDelay(src.st)))
                .ForMember(dest => dest.IsCancelled, opt => opt.MapFrom(src => src.isCancelled))
                .ForMember(dest => dest.IsDetachedHere, opt => opt.MapFrom(src => src.detachFront))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.locationName))
                .ForMember(dest => dest.ScheduledTime, opt => opt.MapFrom(src => src.st))
                .ForMember(dest => dest.TrainLength, opt => opt.MapFrom(src => src.length));

            this.CreateMap<ArrayOfCallingPoints1, CallingPointsModel>(MemberList.Destination)
                .ForMember(dest => dest.IsAssociatedCancelled, opt => opt.MapFrom(src => src.assocIsCancelled))
                .ForMember(dest => dest.CallingPoints, opt => opt.MapFrom(src => src.callingPoint))
                .ForMember(dest => dest.RequiresServiceChange, opt => opt.MapFrom(src => src.serviceChangeRequired))
                .ForMember(dest => dest.ServiceType, opt => opt.MapFrom(src => src.serviceType.ToDescription().ToEnum<ServiceType>()));

            this.CreateMap<ServiceLocation, ServiceLocationModel>(MemberList.Destination)
                .ForMember(dest => dest.AssociationIsCancelled, opt => opt.MapFrom(src => src.assocIsCancelled))
                .ForMember(dest => dest.Crs, opt => opt.MapFrom(src => src.crs))
                .ForMember(dest => dest.FutureChangeTo, opt => opt.MapFrom(src => src.futureChangeTo))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.locationName))
                .ForMember(dest => dest.Via, opt => opt.MapFrom(src => src.via));

            this.CreateMap<FormationData, FormationModel>(MemberList.Destination)
                .ForMember(dest => dest.AverageLoading, opt => opt.MapFrom(src => src.avgLoading))
                .ForMember(dest => dest.Coaches, opt => opt.MapFrom(src => src.coaches));

            this.CreateMap<ServiceItemWithCallingPoints1, ServiceItemModel>(MemberList.Destination)
                .ForMember(dest => dest.AdhocAlerts, opt => opt.MapFrom(src => src.adhocAlerts))
                .ForMember(dest => dest.CancellationReason, opt => opt.MapFrom(src => src.cancelReason))
                .ForMember(dest => dest.CurrentDestinations, opt => opt.MapFrom(src => src.currentDestinations))
                .ForMember(dest => dest.CurrentOrigins, opt => opt.MapFrom(src => src.currentOrigins))
                .ForMember(dest => dest.DelayReason, opt => opt.MapFrom(src => src.delayReason))
                .ForMember(dest => dest.Destinations, opt => opt.MapFrom(src => src.destination))
                .ForMember(dest => dest.EstimatedTimeArrival, opt => opt.MapFrom(src => src.eta))
                .ForMember(dest => dest.EstimatedTimeArrivalDelay, opt => opt.MapFrom(src => src.eta.ToTimeDelay(src.sta)))
                .ForMember(dest => dest.EstimatedTimeDeparture, opt => opt.MapFrom(src => src.etd))
                .ForMember(dest => dest.EstimatedTimeDepartureDelay, opt => opt.MapFrom(src => src.etd.ToTimeDelay(src.std)))
                .ForMember(dest => dest.Formation, opt => opt.MapFrom(src => src.formation))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => RandomNumber()))
                .ForMember(dest => dest.IsCancelled, opt => opt.MapFrom(src => src.isCancelled))
                .ForMember(dest => dest.HasChangedDestination, opt => opt.MapFrom(src => src.currentDestinations.Length > 0))
                .ForMember(dest => dest.HasChangedOrigin, opt => opt.MapFrom(src => src.currentOrigins.Length > 0))
                .ForMember(dest => dest.IsCircularRoute, opt => opt.MapFrom(src => src.isCircularRoute))
                .ForMember(dest => dest.IsDetachedHere, opt => opt.MapFrom(src => src.detachFront))
                .ForMember(dest => dest.IsFilterLocationCancelled, opt => opt.MapFrom(src => src.filterLocationCancelled))
                .ForMember(dest => dest.IsReverseFormation, opt => opt.MapFrom(src => src.isReverseFormation))
                .ForMember(dest => dest.Operator, opt => opt.MapFrom(src => src.@operator))
                .ForMember(dest => dest.OperatorCode, opt => opt.MapFrom(src => src.operatorCode))
                .ForMember(dest => dest.Origins, opt => opt.MapFrom(src => src.origin))
                .ForMember(dest => dest.Platform, opt => opt.MapFrom(src => src.platform))
                .ForMember(dest => dest.PreviousCallingPoints, opt => opt.MapFrom(src => src.previousCallingPoints))
                .ForMember(dest => dest.ScheduledTimeArrival, opt => opt.MapFrom(src => src.sta))
                .ForMember(dest => dest.ScheduledTimeDeparture, opt => opt.MapFrom(src => src.std))
                .ForMember(dest => dest.ServiceId, opt => opt.MapFrom(src => src.serviceID))
                .ForMember(dest => dest.ServiceType, opt => opt.MapFrom(src => src.serviceType.ToDescription().ToEnum<ServiceType>()))
                .ForMember(dest => dest.SubsequentCallingPoints, opt => opt.MapFrom(src => src.subsequentCallingPoints))
                .ForMember(dest => dest.TrainLength, opt => opt.MapFrom(src => src.length));

            this.CreateMap<NRCCMessage, string>(MemberList.None)
                .ConvertUsing(src => src.Value);

            this.CreateMap<LiveDepartureBoardsService.GetArrDepBoardWithDetailsResponse, StationBoardModel>(MemberList.Destination)
                .ForMember(dest => dest.Crs, opt => opt.MapFrom(src => src.GetStationBoardResult.crs))
                .ForMember(dest => dest.FilterCrs, opt => opt.MapFrom(src => src.GetStationBoardResult.filtercrs))
                .ForMember(dest => dest.FilterLocation, opt => opt.MapFrom(src => src.GetStationBoardResult.filterLocationName))
                .ForMember(dest => dest.FilterType, opt => opt.MapFrom(src => src.GetStationBoardResult.filterType.ToDescription().ToEnum<FilterType>()))
                .ForMember(dest => dest.GeneratedAt, opt => opt.MapFrom(src => src.GetStationBoardResult.generatedAt.ToString("dd MMM yyyy HH:mm:ss")))
                .ForMember(dest => dest.HasPlatform, opt => opt.MapFrom(src => src.GetStationBoardResult.platformAvailable))
                .ForMember(dest => dest.HasServices, opt => opt.MapFrom(src => src.GetStationBoardResult.areServicesAvailable))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.GetStationBoardResult.locationName))
                .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.GetStationBoardResult.nrccMessages))
                .ForMember(dest => dest.Services, opt => opt.MapFrom(src => MergeServices(src.GetStationBoardResult)));

            this.CreateMap<DepartureItemWithCallingPoints1, DepartureModel>(MemberList.Destination)
                .ForMember(dest => dest.Crs, opt => opt.MapFrom(src => src.crs))
                .ForMember(dest => dest.Service, opt => opt.MapFrom(src => src.service));

            // TODO: date string in config
            this.CreateMap<GetFastestDeparturesWithDetailsResponse, DeparturesBoardModel>(MemberList.Destination)
                .ForMember(dest => dest.Crs, opt => opt.MapFrom(src => src.DeparturesBoard.crs))
                .ForMember(dest => dest.Departures, opt => opt.MapFrom(src => src.DeparturesBoard.departures))
                .ForMember(dest => dest.FilterCrs, opt => opt.MapFrom(src => src.DeparturesBoard.filtercrs))
                .ForMember(dest => dest.FilterLocation, opt => opt.MapFrom(src => src.DeparturesBoard.filterLocationName))
                .ForMember(dest => dest.FilterType, opt => opt.MapFrom(src => src.DeparturesBoard.filterType.ToDescription().ToEnum<FilterType>()))
                .ForMember(dest => dest.GeneratedAt, opt => opt.MapFrom(src => src.DeparturesBoard.generatedAt.ToString("dd MMM yyyy HH:mm:ss")))
                .ForMember(dest => dest.HasPlatform, opt => opt.MapFrom(src => src.DeparturesBoard.platformAvailable))
                .ForMember(dest => dest.HasServices, opt => opt.MapFrom(src => src.DeparturesBoard.areServicesAvailable))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.DeparturesBoard.locationName))
                .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.DeparturesBoard.nrccMessages));

            this.CreateMap<string, string[]>(MemberList.None)
                .ConvertUsing(src => src.Split(','));

            this.CreateMap<StationBoardQuery, GetArrDepBoardWithDetailsRequest>(MemberList.Source)
                .ForPath(dest => dest.AccessToken.TokenValue, opt => opt.MapFrom(src => src.AccessToken))
                .ForMember(dest => dest.crs, opt => opt.MapFrom(src => src.Crs.ToUpper()))
                .ForMember(dest => dest.filterCrs, opt => opt.MapFrom(src => src.FilterCrs.ToUpper()))
                .ForMember(dest => dest.filterType, opt => opt.MapFrom(src => src.Type.ToDescription()))
                .ForMember(dest => dest.numRows, opt => opt.MapFrom(src => src.NumberRows))
                .ForMember(dest => dest.timeOffset, opt => opt.MapFrom(src => src.TimeOffset))
                .ForMember(dest => dest.timeWindow, opt => opt.MapFrom(src => src.TimeWindow))
                .ForSourceMember(src => src.StationName, opt => opt.Ignore())
                .ForSourceMember(src => src.FilterStationName, opt => opt.Ignore());

            this.CreateMap<FastestDepartureQuery, GetFastestDeparturesWithDetailsRequest>(MemberList.Source)
                .ForPath(dest => dest.AccessToken.TokenValue, opt => opt.MapFrom(src => src.AccessToken))
                .ForMember(dest => dest.crs, opt => opt.MapFrom(src => src.Crs.ToUpper()))
                .ForMember(dest => dest.filterList, opt => opt.MapFrom(src => src.FilterCrs.ToUpper()))
                .ForMember(dest => dest.timeOffset, opt => opt.MapFrom(src => src.TimeOffset))
                .ForMember(dest => dest.timeWindow, opt => opt.MapFrom(src => src.TimeWindow))
                .ForSourceMember(src => src.StationName, opt => opt.Ignore())
                .ForSourceMember(src => src.FilterStationName, opt => opt.Ignore());
        }

        private static ServiceItemWithCallingPoints1[] MergeServices(StationBoardWithDetails1 board)
        {
            // TODO: we're not dealing with big numbers (10), but this is pretty pants...
            var trains = board.trainServices ?? new ServiceItemWithCallingPoints1[0];
            var busses = board.busServices ?? new ServiceItemWithCallingPoints1[0];
            var ferries = board.ferryServices ?? new ServiceItemWithCallingPoints1[0];

            var length = 0 + trains.Length + busses.Length + ferries.Length;

            var array = new ServiceItemWithCallingPoints1[length];
            trains.CopyTo(array, 0);
            busses.CopyTo(array, trains.Length);
            ferries.CopyTo(array, trains.Length + busses.Length);

            return array;
        }

        private static string RandomNumber()
        {
            var rand = new Random(DateTime.Now.Millisecond);

            return $"a{Guid.NewGuid()}"; // (char)rand.Next(65, 90)}{rand.Next(0, 10000)}";
        }
    }
}
