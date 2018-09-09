namespace JoF.Rail.Core.Interfaces
{
    using System.Threading.Tasks;
    using JoF.Rail.Core.Models.HistoricalPerformance;

    public interface IHistoricalPerformanceService
    {
        Task<DetailModel> Detail(DetailQuery query);

        Task<MetricsModel> Metrics(MetricsQuery query);
    }
}
