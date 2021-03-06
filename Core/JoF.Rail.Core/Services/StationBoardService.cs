﻿namespace JoF.Rail.Core.Services
{
    using System.Threading.Tasks;
    using AutoMapper;
    using JoF.Rail.Core.Interfaces;
    using JoF.Rail.Core.Models.LiveDepartureBoard.Query;
    using JoF.Rail.Core.Models.LiveDepartureBoard.Result;
    using LiveDepartureBoardsService;

    public class StationBoardService : IStationBoardService
    {
        public async Task<StationBoardModel> GetBoard(StationBoardQuery query)
        {
            var endpoint = default(LDBServiceSoapClient.EndpointConfiguration);
            var svc = new LDBServiceSoapClient(endpoint);
            var board = await svc.GetArrDepBoardWithDetailsAsync(Mapper.Map<GetArrDepBoardWithDetailsRequest>(query));

            // TODO: TEST PROPERLY!!  (with unit tests)

            // var board = ReadFile<GetArrDepBoardWithDetailsResponse>.GetFromJson("~/../../../Data/DepArrBoard_HHEECR_Arr_NotStopping.json");

            return Mapper.Map<StationBoardModel>(board);
        }
    }
}
