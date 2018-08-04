namespace JoF.Rail.Core.Web.Features.NetworkOverview
{
    using System.Threading;
    using System.Threading.Tasks;
    using JoF.Rail.Standard.Models;
    using JoF.Rail.Standard.Models.KnowledgeBase;
    using JoF.Rail.Standard.Services.KnowledgeBase;
    using MediatR;

    public class Index
    {
        public class Token : TokenQuery, IRequest<TokenModel>
        {
        }

        public class Query : KnowledgeBaseQuery, IRequest<NetworkOverviewModel>
        {
        }

        public class HandleToken : IRequestHandler<Token, TokenModel>
        {
            public async Task<TokenModel> Handle(Token request, CancellationToken cancellationToken)
            {
                var token = await KnowledgeBaseToken.Get(request);

                return token;
            }
        }

        public class HandleRequest : IRequestHandler<Query, NetworkOverviewModel>
        {
            public async Task<NetworkOverviewModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var service = new KnowledgeBaseService<NetworkOverviewModel>();
                return await service.Get(request);
            }
        }
    }
}
