namespace HubSpot.NET.Models
{
    /// <summary>
    /// Represents a HubSpot object type used in API calls.
    /// Provides built-in types and helpers for custom object definitions.
    /// </summary>
    public readonly struct HubSpotObjectType : IEquatable<HubSpotObjectType>, IEquatable<string>
    {
        private readonly string _value;

        // Core HubSpot object types
        public static readonly HubSpotObjectType Cart = new("cart");

        public static readonly HubSpotObjectType Contact = new("contacts");

        public static readonly HubSpotObjectType Company = new("companies");

        public static readonly HubSpotObjectType Deal = new("deals");
        
        public static readonly HubSpotObjectType Ticket = new("tickets");
        
        public static readonly HubSpotObjectType Product = new("product");
        
        public static readonly HubSpotObjectType LineItem = new("line_item");
        
        public static readonly HubSpotObjectType Quote = new("quotes");
        
        public static readonly HubSpotObjectType Call = new("calls");
        
        public static readonly HubSpotObjectType Email = new("emails");
        
        public static readonly HubSpotObjectType Meeting = new("meetings");
        
        public static readonly HubSpotObjectType Note = new("notes");

        public static readonly HubSpotObjectType Order = new("order");

        public static readonly HubSpotObjectType Owner = new("owners");
        
        public static readonly HubSpotObjectType Task = new("tasks");

        // Common meta objects
        public static readonly HubSpotObjectType Pipeline = new("pipelines");

        public static readonly HubSpotObjectType Property = new("properties");

        private HubSpotObjectType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public override string ToString() => _value;

        /// <summary>
        /// Creates a HubSpot custom object type.
        /// By default, automatically prefixes the custom object name with 'p_'.
        /// </summary>
        /// <param name="name">The custom object name (without prefix).</param>
        /// <param name="includePrefix">Whether to include the 'p_' prefix. Defaults to true.</param>
        /// <returns>A new HubSpotObjectType representing the custom object.</returns>
        public static HubSpotObjectType Custom(string name, bool includePrefix = true)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Custom object name cannot be null or empty.", nameof(name));
            }

            return new HubSpotObjectType(includePrefix ? $"p_{name}" : name);
        }

        public bool Equals(string? other)
        {
            return string.Equals(_value, other, StringComparison.OrdinalIgnoreCase);
        }

        public bool Equals(HubSpotObjectType other)
        {
            return Equals(other._value);
        }

        // Equality operators for convenience
        public override bool Equals(object? obj)
        {
            if (obj is string str)
            {
                return Equals(str);
            }
            else if (obj is HubSpotObjectType otherType)
            {
                return Equals(otherType);
            }

            return false;
        }

        public override int GetHashCode()
        {
            HashCode hashCode = new();
            hashCode.Add(_value, StringComparer.OrdinalIgnoreCase);

            return hashCode.ToHashCode();
        }

        // Implicit conversion to string for seamless API path usage
        public static implicit operator string(HubSpotObjectType type) => type._value;

        public static bool operator ==(HubSpotObjectType left, HubSpotObjectType right) => left.Equals(right);

        public static bool operator !=(HubSpotObjectType left, HubSpotObjectType right) => !left.Equals(right);
    }
}
