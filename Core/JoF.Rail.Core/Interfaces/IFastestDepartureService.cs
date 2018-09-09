namespace JoF.Rail.Core.Interfaces
{
    using System.Threading.Tasks;
    using JoF.Rail.Core.Models.LiveDepartureBoard.Query;
    using JoF.Rail.Core.Models.LiveDepartureBoard.Result;

    public interface IFastestDepartureService
    {
        Task<DeparturesBoardModel> GetFastest(FastestDepartureQuery query);
    }
}
