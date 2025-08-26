using HubSpot.NET.Models;

namespace HubSpot.NET.Requests
{
    public class CompaniesCollectionRequestBuilder : BaseRequestBuilder
    {
        internal CompaniesCollectionRequestBuilder(string baseUrl, BaseClient client)
            : base(baseUrl, client) { }

        public CompanyRequestBuilder this[string contactId]
        {
            get
            {
                return new CompanyRequestBuilder(AppendUrlSegment(contactId), Client);
            }
        }

        public async Task<CollectionResponse<Company>> RetrieveAsync(RetrieveCompaniesParameters? parameters = null, CancellationToken cancellationToken = default)
        {
            string requestUrl = parameters is null ? BaseUrl : AddUrlParameters(BaseUrl, parameters);
            return await Client.GetAsync<CollectionResponse<Company>>(requestUrl, cancellationToken);
        }

        public async Task<Company> CreateAsync(CreateCompanyRequest createRequest, CancellationToken cancellationToken = default)
        {
            string requestUrl = BaseUrl;
            return await Client.PostJsonAsync<Company>(requestUrl, createRequest, cancellationToken);
        }

        public CompanyRequestBuilder RetrieveByUniqueId(string idPropertyName, string uniqueIdValue)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(idPropertyName);
            ArgumentException.ThrowIfNullOrWhiteSpace(uniqueIdValue);

            string requestUrl = AppendUrlSegment(uniqueIdValue);
            requestUrl = AddUrlParameter(requestUrl, "idProperty", idPropertyName);

            return new CompanyRequestBuilder(requestUrl, Client);
        }
    }
}
