namespace HubSpot.NET.Requests
{
    public class ObjectAssociationsCollectionRequestBuilder : BaseRequestBuilder
    {
        internal ObjectAssociationsCollectionRequestBuilder(string baseUrl, BaseClient client)
            : base(baseUrl, client) { }

        public Task PutAsync(string toObjectType, string toObjectId, int assocationTypeId, CancellationToken cancellationToken = default)
        {
            var requestUrl = AppendUrlSegment(toObjectType, toObjectId, assocationTypeId.ToString());
            return Client.PutAsync(requestUrl, cancellationToken);
        }

        public Task DeleteAsync(string toObjectType, string toObjectId, int assocationTypeId, CancellationToken cancellationToken = default)
        {
            var requestUrl = AppendUrlSegment(toObjectType, toObjectId, assocationTypeId.ToString());
            return Client.DeleteAsync(requestUrl, cancellationToken);
        }
    }
}
