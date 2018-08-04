namespace JoF.Rail.Standard.Services.KnowledgeBase
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using JoF.Rail.Standard.Core.Extensions;
    using JoF.Rail.Standard.Models.KnowledgeBase;

    public static class KnowledgeBaseToken
    {
        private static HttpClient httpClient = new HttpClient();

        public static async Task<TokenModel> Get(TokenQuery query)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, query.Url)
            {
                Content = new FormUrlEncodedContent(
                    new Dictionary<string, string>
                    {
                        { "username", query.User },
                        { "password", query.Key }
                    }),
            };

            var token = await httpClient.SendAsync(request);

            return (await token.Content.ReadAsStringAsync())
                .DeserialiseJson<TokenModel>();
        }
    }
}
