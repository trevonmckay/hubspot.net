using HubSpot.NET.Models;

namespace HubSpot.NET.Requests
{
    public class PipelineCollectionRequestBuilder : BaseRequestBuilder
    {
        public PipelineCollectionRequestBuilder(string baseUrl, BaseClient client)
            : base(baseUrl, client) { }

        public PipelineRequestBuilder this[string pipelineId] => new($"{BaseUrl}/{pipelineId}", Client);

        public async Task<CollectionResponse<Pipeline>> RetrieveAllAsync(CancellationToken cancellationToken = default)
        {
            string requestUrl = BaseUrl;
            return await Client.GetAsync<CollectionResponse<Pipeline>>(requestUrl, cancellationToken);
        }

        public async Task<Pipeline> CreateAsync(CreatePipelineRequest createRequest, CancellationToken cancellationToken = default)
        {
            string requestUrl = BaseUrl;
            return await Client.PostJsonAsync<Pipeline>(requestUrl, createRequest, cancellationToken);
        }
    }
}
