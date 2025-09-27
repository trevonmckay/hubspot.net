using HubSpot.NET.Requests;
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

        public CompaniesCollectionRequestBuilder Companies => new("/crm/v3/objects/companies", _client);

        public ContactsCollectionRequestBuilder Contacts => new("/crm/v3/objects/contacts", _client);

        public EmailCollectionRequestBuilder Emails => new("/crm/v3/objects/emails", _client);

        public PropertiesCollectionRequestBuilder Properties => new("/crm/v3/properties", _client);

        public PipelineObjectsCollectionRequestBuilder Pipelines => new("/crm/v3/pipelines", _client);

        public VisitorIdentificationRequestBuilder VisitorIdentification => new("/visitor-identification/v3/tokens", _client);

        private static HttpClient BuildHttpClient(HubSpotClientOptions clientOptions, HttpMessageHandler? httpPipeline = null)
        {
            HttpClient httpClient = httpPipeline is not null ? new HttpClient(httpPipeline) : new();
            return httpClient;
        }
    }
}
