using HubSpot.NET.Requests.Contacts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace HubSpot.NET
{
    public class HubSpotClient
    {
        private static readonly Uri _defaultBaseUri = new("https://api.hubapi.com");

        private readonly BaseClient _client;

        public HubSpotClient(HttpClient httpClient, HubSpotClientOptions clientOptions)
        {
            httpClient.BaseAddress ??= _defaultBaseUri;
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {clientOptions.AccessToken}");

            _client = new(httpClient);
        }

        [ActivatorUtilitiesConstructor]
        public HubSpotClient(HttpClient httpClient, IOptions<HubSpotClientOptions> clientOptionsAccessor)
            : this(httpClient, clientOptionsAccessor.Value) { }

        public HubSpotClient(HubSpotClientOptions clientOptions, HttpMessageHandler? httpMessageHandler = null)
            : this(BuildHttpClient(clientOptions, httpMessageHandler), clientOptions) { }

        public ContactsCollectionRequestBuilder Contacts => new("/crm/v3/objects/contacts", _client);

        private static HttpClient BuildHttpClient(HubSpotClientOptions clientOptions, HttpMessageHandler? httpPipeline = null)
        {
            HttpClient httpClient = httpPipeline is not null ? new HttpClient(httpPipeline) : new();
            return httpClient;
        }
    }
}
