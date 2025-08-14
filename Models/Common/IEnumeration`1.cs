namespace HubSpot.NET.Models
{
    public interface IEnumeration<T> : IEquatable<T>
    {
        T Value { get; }
    }
}
