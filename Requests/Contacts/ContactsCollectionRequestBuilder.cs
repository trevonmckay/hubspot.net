namespace HubSpot.NET.Requests
{
    using HubSpot.NET.Models;

    public class ContactsCollectionRequestBuilder : BaseRequestBuilder
    {
        public ContactsCollectionRequestBuilder(string baseUrl, BaseClient client)
            : base(baseUrl, client) { }

        public ContactRequestBuilder this[string contactId]
        {
            get
            {
                return new ContactRequestBuilder(AppendUrlSegment(contactId), Client);
            }
        }

        public async Task<CollectionResponse<Contact>> GetAsync(GetContactsParameters? parameters = null, CancellationToken cancellationToken = default)
        {
            string requestUrl = parameters is null ? BaseUrl : AddUrlParameters(BaseUrl, parameters);
            return await Client.GetAsync<CollectionResponse<Contact>>(requestUrl, cancellationToken);
        }

        public Task<CollectionResponse<Contact>> GetAsync(Action<GetContactsParameters> parameterBuilder, CancellationToken cancellationToken = default)
        {
            GetContactsParameters parameters = new();
            parameterBuilder?.Invoke(parameters);

            return GetAsync(parameters, cancellationToken);
        }

        public async Task<Contact> CreateAsync(CreateContactRequest createRequest, CancellationToken cancellationToken = default)
        {
            string requestUrl = BaseUrl;
            return await Client.PostJsonAsync<Contact>(requestUrl, createRequest, cancellationToken);
        }

        public async Task<SearchResult<Contact>> SearchAsync(SearchContactsRequest searchRequest, CancellationToken cancellationToken = default)
        {
            string requestUrl = AppendUrlSegment("search");
            return await Client.PostJsonAsync<SearchResult<Contact>>(requestUrl, searchRequest, cancellationToken);
        }
    }
}
