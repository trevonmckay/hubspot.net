using HubSpot.NET.Models;

namespace HubSpot.NET.Requests
{
    public class EmailCollectionRequestBuilder : BaseRequestBuilder
    {
        public EmailCollectionRequestBuilder(string baseUrl, BaseClient client)
            : base(baseUrl, client) { }

        public Task<CreatedResource> CreateAsync(CreateObjectRequest createRequest, CancellationToken cancellationToken = default)
        {
            return Client.PostJsonAsync<CreatedResource>(BaseUrl, createRequest, cancellationToken);
        }
    }
}
