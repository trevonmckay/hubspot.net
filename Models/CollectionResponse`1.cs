namespace HubSpot.NET.Models
{
    public class CollectionResponse<T>
    {
        public IEnumerable<T> Results { get; set; } = Enumerable.Empty<T>();

        public PageObject? Paging { get; set; }
    }

    public class PageObject
    {
        public PageDetails? Next { get; set; }
    }

    public class PageDetails
    {
        public string? Link { get; set; }

        public string? After { get; set; }
    }
}
