using HubSpot.NET.Models;

namespace HubSpot.NET.Requests
{
    public class PipelineObjectsCollectionRequestBuilder : BaseRequestBuilder
    {
        public PipelineObjectsCollectionRequestBuilder(string baseUrl, BaseClient client)
            : base(baseUrl, client) { }

        public PipelineCollectionRequestBuilder this[string objectType] => new(AppendUrlSegment(objectType), Client);
    }
}
