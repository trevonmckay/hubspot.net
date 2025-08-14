using HubSpot.NET.Models;

namespace HubSpot.NET.Requests
{
    public class ObjectPropertyGroupsCollectionRequestBuilder : BaseRequestBuilder
    {
        internal ObjectPropertyGroupsCollectionRequestBuilder(string baseUrl, BaseClient client)
            : base(baseUrl, client) { }

        public Task CreateAsync(CreatePropertyGroupRequest createRequest, CancellationToken cancellationToken = default)
        {
            return Client.PostJsonAsync<object>(BaseUrl, createRequest, cancellationToken);
        }
    }
}
