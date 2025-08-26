using HubSpot.NET.Models;

namespace HubSpot.NET.Requests
{
    public class CompanyRequestBuilder : BaseRequestBuilder
    {
        public CompanyRequestBuilder(string baseUrl, BaseClient client)
            : base(baseUrl, client) { }

        public async Task<Company> RetrieveAsync(RetrieveCompanyParameters? parameters = null, CancellationToken cancellationToken = default)
        {
            string requestUrl = parameters is null ? BaseUrl : AddUrlParameters(BaseUrl, parameters);
            return await Client.GetAsync<Company>(requestUrl, cancellationToken);
        }
    }
}
