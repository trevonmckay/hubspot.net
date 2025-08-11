namespace HubSpot.NET.Requests.Contacts
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

        public async Task<Contact> CreateAsync(CreateContactRequest createRequest, CancellationToken cancellationToken = default)
        {
            string requestUrl = this.BaseUrl;
            return await Client.PostJsonAsync<Contact>(requestUrl, createRequest, cancellationToken);
        }

        public async Task<SearchResult<Contact>> SearchAsync(SearchContactsRequest searchRequest, CancellationToken cancellationToken = default)
        {
            string requestUrl = this.AppendUrlSegment("search");
            return await Client.PostJsonAsync<SearchResult<Contact>>(requestUrl, searchRequest, cancellationToken);
        }
    }
}
