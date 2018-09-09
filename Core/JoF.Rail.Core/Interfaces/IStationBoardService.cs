namespace JoF.Rail.Core.Interfaces
{
    using System.Threading.Tasks;
    using JoF.Rail.Core.Models.LiveDepartureBoard.Result;
    using JoF.Rail.Core.Models.LiveDepartureBoard.Query;

    public interface IStationBoardService
    {
        Task<StationBoardModel> GetBoard(StationBoardQuery query);
    }
}
