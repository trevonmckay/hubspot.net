namespace HubSpot.NET.Requests
{
    public abstract class ObjectCollectionRequestBuilder : BaseRequestBuilder
    {
        protected ObjectCollectionRequestBuilder(string baseUrl, BaseClient client)
            : base(baseUrl, client) { }
    }
}
