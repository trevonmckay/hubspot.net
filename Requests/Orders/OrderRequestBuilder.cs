using HubSpot.NET.Models;

namespace HubSpot.NET.Requests
{
    public class OrderRequestBuilder : BaseRequestBuilder
    {
        internal OrderRequestBuilder(string baseUrl, BaseClient client)
            : base(baseUrl, client) { }

        public Task<CrmObject> ReadAsync(CancellationToken cancellationToken = default)
        {
            return Client.GetAsync<CrmObject>(BaseUrl, cancellationToken);
        }

        public Task<CrmObject> UpdateAsync(PatchObjectRequest patchRequest, CancellationToken cancellationToken = default)
        {
            return Client.PatchJsonAsync<CrmObject>(BaseUrl, patchRequest, cancellationToken);
        }

        public Task ArchiveAsync(CancellationToken cancellationToken = default)
        {
            return Client.DeleteAsync(BaseUrl, cancellationToken);
        }
    }
}
