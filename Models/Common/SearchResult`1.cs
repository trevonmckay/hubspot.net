using HubSpot.NET.Models;

namespace HubSpot.NET
{
    public class SearchResult<T>
    {
        public IEnumerable<T> Results { get; internal set; } = [];

        public PageObject? Paging { get; internal set; }

        public long Total { get; internal set; }
    }
}
