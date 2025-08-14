using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace HubSpot.NET
{
    public class BaseClient
    {
        private static readonly JsonSerializerOptions _serializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        private readonly HttpClient _httpClient;

        public BaseClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                throw await HubSpotRequestException.CreateAsync(response);
            }

            return response;
        }

        public async Task<T> PostJsonAsync<T>(string requestUrl, object serializableObject, CancellationToken cancellationToken = default)
        {
            HttpRequestMessage request = new(HttpMethod.Post, requestUrl)
            {
                Content = CreateRequestContent(serializableObject),
            };

            var response = await SendAsync(request, cancellationToken);
            return await DeserializeResponse<T>(response);
        }

        private static StringContent CreateRequestContent(object serializableObject)
        {
            string json = JsonSerializer.Serialize(serializableObject, _serializerOptions);
            StringContent httpContent = new(json, Encoding.UTF8, "application/json");

            return httpContent;
        }

        private static async Task<T> DeserializeResponse<T>(HttpResponseMessage response)
        {
            var responseObject = await response.Content.ReadFromJsonAsync<T>(_serializerOptions);
            return responseObject!;
        }
    }
}
