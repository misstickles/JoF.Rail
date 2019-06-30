namespace JoF.Rail.Core.Services.KnowledgeBase
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using JoF.Rail.Core.Extensions;
    using JoF.Rail.Core.Interfaces;
    using JoF.Rail.Core.Models.KnowledgeBase;

    public class KnowledgeBaseService<T> : IKnowledgeBaseService<T>
        where T : class
    {
        private static HttpClient httpClient = new HttpClient();

        public async Task<T> Get(KnowledgeBaseQuery query)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, query.Url);
            request.Headers.Add("X-Auth-Token", query.Token);

            // return ReadFile<T>.GetFromXml(@"~/../Data/KbStations.xml");

            var response = await httpClient.SendAsync(request);

            return (await response.Content.ReadAsStringAsync())
                .DeserialiseXml<T>();
        }
    }
}
