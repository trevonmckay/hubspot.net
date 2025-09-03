using HubSpot.NET.Models;

namespace HubSpot.NET.Requests
{
    public class EmailCollectionRequestBuilder : ObjectCollectionRequestBuilder
    {
        public EmailCollectionRequestBuilder(string baseUrl, BaseClient client)
            : base(baseUrl, client) { }

        public Task CreateAsync(CreateObjectRequest createRequest, CancellationToken cancellationToken = default)
        {
            return Client.PostJsonAsync<CrmObject>(BaseUrl, createRequest, cancellationToken);
        }
    }
}
