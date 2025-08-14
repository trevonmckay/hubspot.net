using HubSpot.NET.Models;

namespace HubSpot.NET.Requests
{
    public class ObjectPropertiesCollectionRequestBuilder : BaseRequestBuilder
    {
        internal ObjectPropertiesCollectionRequestBuilder(string baseUrl, BaseClient client)
            : base(baseUrl, client) { }

        public ObjectPropertyGroupsCollectionRequestBuilder Groups => new(AppendUrlSegment("groups"), Client);

        public Task CreateAsync(CreatePropertyRequest createRequest, CancellationToken cancellationToken = default)
        {
            return Client.PostJsonAsync<object>(BaseUrl, createRequest, cancellationToken);
        }
    }
}
