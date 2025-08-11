using HubSpot.NET.Models;

namespace HubSpot.NET.Requests.Contacts
{
    public class ContactRequestBuilder : BaseRequestBuilder
    {
        public ContactRequestBuilder(string baseUrl, BaseClient client)
            : base(baseUrl, client) { }

        public Task<Contact> GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
