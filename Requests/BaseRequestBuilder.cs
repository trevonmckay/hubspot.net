namespace HubSpot.NET.Requests
{
    public class BaseRequestBuilder
    {
        protected BaseRequestBuilder(string baseUrl, BaseClient client)
        {
            BaseUrl = baseUrl;
            Client = client;
        }

        protected string BaseUrl { get; }

        protected BaseClient Client { get; }

        protected string AppendUrlSegment(params IEnumerable<string> segments)
        {
            string pathToAppend = string.Join('/', segments.Select(segment => segment.Trim('/')));
            return BaseUrl.TrimEnd('/') + "/" + pathToAppend;
        }
    }
}
