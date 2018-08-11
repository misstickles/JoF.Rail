using System.Threading.Tasks;
using JoF.Rail.Standard.Models.HistoricalPerformance;

namespace JoF.Rail.Standard.Interfaces
{
    public interface IHistoricalPerformanceService
    {
        Task<DetailModel> Detail(DetailQuery query);

        Task<MetricsModel> Metrics(MetricsQuery query);
    }
}
