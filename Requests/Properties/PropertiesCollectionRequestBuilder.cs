namespace HubSpot.NET.Requests
{
    public class PropertiesCollectionRequestBuilder : BaseRequestBuilder
    {
        public PropertiesCollectionRequestBuilder(string baseUrl, BaseClient client)
            : base(baseUrl, client) { }

        /// <summary>
        /// Gets a request builder for a specific object type's properties.
        /// </summary>
        /// <param name="objectType">The type of the object (e.g., "contacts", "companies").</param>
        /// <returns>A request builder for the specified object's properties.</returns>
        public ObjectPropertiesCollectionRequestBuilder this[string objectType]
        {
            get
            {
                return new ObjectPropertiesCollectionRequestBuilder(AppendUrlSegment(objectType), Client);
            }
        }
    }
}
