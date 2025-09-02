using System.Collections;
using System.Text.Json.Serialization;

namespace HubSpot.NET.Models
{
    [JsonConverter(typeof(CollectionResponseJsonConverter))]
    public class CollectionResponse<T> : IEnumerable<T>
    {
        public IEnumerable<T> Results { get; set; } = Enumerable.Empty<T>();

        public PageObject? Paging { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return Results.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Results).GetEnumerator();
        }
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
