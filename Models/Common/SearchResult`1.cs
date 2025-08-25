using HubSpot.NET.Models;

namespace HubSpot.NET
{
    public class SearchResult<T>
    {
        public IEnumerable<T> Results { get; set; } = [];

        public PageObject? Paging { get; set; }

        public long Total { get; set; }
    }
}
