namespace HubSpot.NET.Requests
{
    public class VisitorIdentificationRequestBuilder : BaseRequestBuilder
    {
        internal VisitorIdentificationRequestBuilder(string baseUrl, BaseClient client)
            : base(baseUrl, client) { }

        public async Task<VisitorIdentificationTokenResponse> CreateAsync(CreateVisitorIdentificationTokenRequest createRequest, CancellationToken cancellationToken = default)
        {
            string requestUrl = AppendUrlSegment("create");
            return await Client.PostJsonAsync<VisitorIdentificationTokenResponse>(requestUrl, createRequest, cancellationToken);
        }
    }
}
