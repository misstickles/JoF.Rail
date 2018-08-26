namespace JoF.Rail.Core.Web.Features.Historical
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using JoF.Rail.Core.Web.ApiControllers;
    using JoF.Rail.Standard.Models.HistoricalPerformance;
    using JoF.Rail.Standard.Services.HistoricalPerformance;
    using MediatR;

    public class Index
    {
        public class QueryMetrics : MetricsQuery, IRequest<MetricsModel>
        {
            public string From { get; set; }

            public string To { get; set; }
        }

        public class QueryDetails : DetailQuery, IRequest<DetailModel>
        {
        }

        public class HandlerMetrics : IRequestHandler<QueryMetrics, MetricsModel>
        {
            public async Task<MetricsModel> Handle(QueryMetrics request, CancellationToken cancellationToken)
            {
                var service = new HistoricalPerformanceService();
                return await service.Metrics(request);
            }
        }

        public class HandlerDetails : IRequestHandler<QueryDetails, DetailModel>
        {
            public async Task<DetailModel> Handle(QueryDetails request, CancellationToken cancellationToken)
            {
                var service = new HistoricalPerformanceService();
                return await service.Detail(request);
            }
        }
    }
}
