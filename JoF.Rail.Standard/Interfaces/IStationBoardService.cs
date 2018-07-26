namespace JoF.Rail.Standard.Interfaces
{
    using System.Threading.Tasks;
    using JoF.Rail.Standard.Models.LiveDepartureBoard.Result;
    using JoF.Rail.Standard.Models.LiveDepartureBoard.Query;

    public interface IStationBoardService
    {
        Task<StationBoardModel> GetBoard(StationBoardQuery query);
    }
}
