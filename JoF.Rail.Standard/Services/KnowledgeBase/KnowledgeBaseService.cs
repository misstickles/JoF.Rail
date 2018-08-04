namespace JoF.Rail.Standard.Services.KnowledgeBase
{
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using JoF.Rail.Standard.Core.Extensions;
    using JoF.Rail.Standard.Interfaces;
    using JoF.Rail.Standard.Models.KnowledgeBase;

    public class KnowledgeBaseService<T> : IKnowledgeBaseService<T>
        where T : class
    {
        private static HttpClient httpClient = new HttpClient();

        public async Task<T> Get(KnowledgeBaseQuery query)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, query.Url);
            request.Headers.Add("Accept", "application/xhtml+xml");
            request.Headers.Add("X-Auth-Token", query.Token);

            var response = await httpClient.SendAsync(request);

            return (await response.Content.ReadAsStringAsync())
                .DeserialiseXml<T>();
        }

        // TODO: REMOVE
        private T GetFromXml()
        {
            using (StreamReader r = File.OpenText(@"E:\Git\JoF.Rail\Data\KbStations.xml"))
            {
                var xml = r.ReadToEnd();
                return xml.DeserialiseXml<T>();
            }
        }

    }
}
