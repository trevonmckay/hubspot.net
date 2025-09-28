using HubSpot.NET.Models;

namespace HubSpot.NET.Requests
{
    public class OrderCollectionRequestBuilder : BaseRequestBuilder
    {
        internal OrderCollectionRequestBuilder(string baseUrl, BaseClient client)
            : base(baseUrl, client) { }

        public Task<CollectionResponse<CrmObject>> ListAsync(CancellationToken cancellationToken = default)
        {
            return Client.GetAsync<CollectionResponse<CrmObject>>(BaseUrl, cancellationToken);
        }

        public OrderRequestBuilder this[string orderId] => new(AppendUrlSegment(orderId), Client);

        public Task<CreatedResource> CreateAsync(CreateObjectRequest createRequest, CancellationToken cancellationToken = default)
        {
            return Client.PostJsonAsync<CreatedResource>(BaseUrl, createRequest, cancellationToken);
        }

        public Task<SearchResult<CrmObject>> SearchAsync(SearchObjectsRequest searchRequest, CancellationToken cancellationToken = default)
        {
            string requestUrl = AppendUrlSegment("search");
            return Client.PostJsonAsync<SearchResult<CrmObject>>(requestUrl, searchRequest, cancellationToken);
        }
    }
}
