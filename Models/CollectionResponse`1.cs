namespace HubSpot.NET.Models
{
    public class CollectionResponse<T>
    {
        public IEnumerable<T> Results { get; internal set; } = Enumerable.Empty<T>();

        public PageObject? Paging { get; internal set; }
    }

    public class PageObject
    {
        public PageDetails? Next { get; internal set; }
    }

    public class PageDetails
    {
        public string? Link { get; internal set; }

        public string? After { get; internal set; }
    }
}
