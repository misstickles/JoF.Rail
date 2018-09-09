namespace JoF.Rail.Core.Services
{
    using System.Threading.Tasks;
    using AutoMapper;
    using JoF.Rail.Core.Interfaces;
    using JoF.Rail.Core.Models.LiveDepartureBoard.Query;
    using JoF.Rail.Core.Models.LiveDepartureBoard.Result;
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
