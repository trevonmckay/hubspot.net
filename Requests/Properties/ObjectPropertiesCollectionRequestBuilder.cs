using HubSpot.NET.Models;

namespace HubSpot.NET.Requests
{
    public class ObjectPropertiesCollectionRequestBuilder : BaseRequestBuilder
    {
        internal ObjectPropertiesCollectionRequestBuilder(string baseUrl, BaseClient client)
            : base(baseUrl, client) { }

        public ObjectPropertyGroupsCollectionRequestBuilder Groups => new(AppendUrlSegment("groups"), Client);

        public async Task<CollectionResponse<ObjectProperty>> GetAsync(GetPropertiesRequestParameters? parameters = null, CancellationToken cancellationToken = default)
        {
            string requestUrl = parameters is null ? BaseUrl : AddUrlParameters(BaseUrl, parameters);
            return await Client.GetAsync<CollectionResponse<ObjectProperty>>(requestUrl, cancellationToken);
        }

        public Task<CollectionResponse<ObjectProperty>> GetAsync(Action<GetPropertiesRequestParameters> parameterBuilder, CancellationToken cancellationToken = default)
        {
            GetPropertiesRequestParameters parameters = new();
            parameterBuilder?.Invoke(parameters);

            return GetAsync(parameters, cancellationToken);
        }

        public Task CreateAsync(CreatePropertyRequest createRequest, CancellationToken cancellationToken = default)
        {
            return Client.PostJsonAsync<object>(BaseUrl, createRequest, cancellationToken);
        }
    }
}
