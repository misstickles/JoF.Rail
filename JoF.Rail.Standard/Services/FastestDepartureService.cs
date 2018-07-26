namespace JoF.Rail.Standard.Services
{
    using System.Threading.Tasks;
    using AutoMapper;
    using JoF.Rail.Standard.Interfaces;
    using JoF.Rail.Standard.Models.LiveDepartureBoard.Query;
    using JoF.Rail.Standard.Models.LiveDepartureBoard.Result;
    using LiveDepartureBoardsService;

    public class FastestDepartureService : IFastestDepartureService
    {
        public async Task<DeparturesBoardModel> GetFastest(FastestDepartureQuery query)
        {
            var endpoint = default(LDBServiceSoapClient.EndpointConfiguration);
            var svc = new LDBServiceSoapClient(endpoint);
            var board = await svc.GetFastestDeparturesWithDetailsAsync(Mapper.Map<GetFastestDeparturesWithDetailsRequest>(query));

            return Mapper.Map<DeparturesBoardModel>(board);
        }
    }
}
