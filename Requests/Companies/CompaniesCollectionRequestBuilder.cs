using HubSpot.NET.Models;

namespace HubSpot.NET.Requests
{
    public class CompaniesCollectionRequestBuilder : BaseRequestBuilder
    {
        internal CompaniesCollectionRequestBuilder(string baseUrl, BaseClient client)
            : base(baseUrl, client) { }

        public async Task<Company> CreateAsync(CreateCompanyRequest createRequest, CancellationToken cancellationToken = default)
        {
            string requestUrl = BaseUrl;
            return await Client.PostJsonAsync<Company>(requestUrl, createRequest, cancellationToken);
        }
    }
}
