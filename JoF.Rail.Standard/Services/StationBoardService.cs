namespace JoF.Rail.Standard.Services
{
    using System.IO;
    using System.Threading.Tasks;
    using AutoMapper;
    using JoF.Rail.Standard.Interfaces;
    using JoF.Rail.Standard.Models.LiveDepartureBoard.Query;
    using JoF.Rail.Standard.Models.LiveDepartureBoard.Result;
    using LiveDepartureBoardsService;
    using Newtonsoft.Json;

    public class StationBoardService : IStationBoardService
    {
        public async Task<StationBoardModel> GetBoard(StationBoardQuery query)
        {
            var endpoint = default(LDBServiceSoapClient.EndpointConfiguration);
            var svc = new LDBServiceSoapClient(endpoint);
            var board = await svc.GetArrDepBoardWithDetailsAsync(Mapper.Map<GetArrDepBoardWithDetailsRequest>(query));

            // TODO: TEST PROPERLY!!  (with unit tests)
            //var board = GetFromJson();

            return Mapper.Map<StationBoardModel>(board);
        }

        // TODO: REMOVE
        private GetArrDepBoardWithDetailsResponse GetFromJson()
        {
            //            using (StreamReader r = File.OpenText("~/../../Data/DepArrBoard_TBD_Arr_BusAndTrain2.json"))
            using (StreamReader r = File.OpenText("~/../../Data/DepArrBoard_HHEECR_Arr_NotStopping.json"))
            {
                var json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<GetArrDepBoardWithDetailsResponse>(json);
            }
        }
    }
}
