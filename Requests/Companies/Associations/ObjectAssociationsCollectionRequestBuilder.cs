using HubSpot.NET.Models;

namespace HubSpot.NET.Requests
{
    public class ObjectAssociationsCollectionRequestBuilder : BaseRequestBuilder
    {
        internal ObjectAssociationsCollectionRequestBuilder(string baseUrl, BaseClient client)
            : base(baseUrl, client) { }

        public Task PutAsync(string toObjectType, string toObjectId, AssociationCategory associationCategory, int assocationTypeId, CancellationToken cancellationToken = default)
        {
            var requestUrl = AppendUrlSegment(toObjectType, toObjectId, assocationTypeId.ToString());
            return Client.PutJsonAsync<CrmObject>(requestUrl, new { associationCategory, assocationTypeId }, cancellationToken);
        }

        public Task PutAsync(string toObjectType, string toObjectId, AssociationCategory associationCategory, AssociationTypeId assocationTypeId, CancellationToken cancellationToken = default)
        {
            return PutAsync(toObjectType, toObjectId, associationCategory, (int)assocationTypeId, cancellationToken);
        }

        public Task PutAsync(string toObjectType, string toObjectId, int assocationTypeId, CancellationToken cancellationToken = default)
        {
            return PutAsync(toObjectType, toObjectId, AssociationCategory.HubSpotDefined, assocationTypeId, cancellationToken);
        }

        public Task PutAsync(string toObjectType, string toObjectId, AssociationTypeId assocationTypeId, CancellationToken cancellationToken = default)
        {
            return PutAsync(toObjectType, toObjectId, AssociationCategory.HubSpotDefined, (int)assocationTypeId, cancellationToken);
        }

        public Task DeleteAsync(string toObjectType, string toObjectId, int assocationTypeId, CancellationToken cancellationToken = default)
        {
            var requestUrl = AppendUrlSegment(toObjectType, toObjectId, assocationTypeId.ToString());
            return Client.DeleteAsync(requestUrl, cancellationToken);
        }

        public Task DeleteAsync(string toObjectType, string toObjectId, AssociationTypeId assocationTypeId, CancellationToken cancellationToken = default)
        {
            return DeleteAsync(toObjectType, toObjectId, (int)assocationTypeId, cancellationToken);
        }
    }
}
