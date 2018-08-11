namespace JoF.Rail.Standard.Services.HistoricalPerformance
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using JoF.Rail.Standard.Core.Extensions;
    using JoF.Rail.Standard.Interfaces;
    using JoF.Rail.Standard.Models.HistoricalPerformance;
    using Newtonsoft.Json;

    // TODO: tidy up!
    public class HistoricalPerformanceService : IHistoricalPerformanceService
    {
        private static HttpClient httpClient = new HttpClient();

        public async Task<DetailModel> Detail(DetailQuery query)
        {
            var byteArray = Encoding.ASCII.GetBytes($"{query.User}:{query.Key}");

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", 
                Convert.ToBase64String(byteArray));

            var request = new HttpRequestMessage(HttpMethod.Post, query.Url)
            {
                Content = new ObjectContent<DetailQuery>(
                    query,
                    new JsonMediaTypeFormatter(),
                    (MediaTypeHeaderValue)null),
            };

            var results = await httpClient.SendAsync(request);

            return (await results.Content.ReadAsStringAsync())
                .DeserialiseJson<DetailModel>();
        }

        public async Task<MetricsModel> Metrics(MetricsQuery query)
        {
            var byteArray = Encoding.ASCII.GetBytes($"{query.User}:{query.Key}");

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(byteArray));

            var content = new StringContent(query.ToJson(new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, "application/json");

            return ReadFile<MetricsModel>.GetFromJson(@"~/../../Data/HspMetrics.json");

            var results = await httpClient.PostAsync(query.Url, content);

            return (await results.Content.ReadAsStringAsync())
                .DeserialiseJson<MetricsModel>();
        }
    }
}
