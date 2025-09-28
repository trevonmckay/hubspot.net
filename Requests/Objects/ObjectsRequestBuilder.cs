namespace HubSpot.NET.Requests
{
    public class ObjectsRequestBuilder : BaseRequestBuilder
    {
        internal ObjectsRequestBuilder(string baseUrl, BaseClient client)
            : base(baseUrl, client) { }

        public CrmObjectCollectionRequestBuilder Carts => new(AppendUrlSegment("carts"), Client);

        public OrderCollectionRequestBuilder Orders => new(AppendUrlSegment("orders"), Client);
    }
}
