namespace JoF.Rail.Standard.Interfaces
{
    using System.Threading.Tasks;
    using JoF.Rail.Standard.Models.LiveDepartureBoard.Query;
    using JoF.Rail.Standard.Models.LiveDepartureBoard.Result;

    public interface IFastestDepartureService
    {
        Task<DeparturesBoardModel> GetFastest(FastestDepartureQuery query);
    }
}
