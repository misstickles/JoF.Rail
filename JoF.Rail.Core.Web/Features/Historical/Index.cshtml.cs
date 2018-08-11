﻿namespace JoF.Rail.Core.Web.Features.Historical
{
    using System.Threading;
    using System.Threading.Tasks;
    using JoF.Rail.Standard.Models.HistoricalPerformance;
    using JoF.Rail.Standard.Services.HistoricalPerformance;
    using MediatR;

    public class Index
    {
        public class QueryMetrics : MetricsQuery, IRequest<MetricsModel>
        {
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
