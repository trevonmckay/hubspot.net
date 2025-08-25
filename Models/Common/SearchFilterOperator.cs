using HubSpot.NET.Models;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace HubSpot.NET
{
    [JsonConverter(typeof(EnumerationJsonConverter))]
    public readonly struct SearchFilterOperator : IEnumeration<string>
    {
        private readonly string _value;

        public static readonly SearchFilterOperator Eq = new("EQ");

        public static readonly SearchFilterOperator NotEq = new("NEQ");

        public static readonly SearchFilterOperator LT = new("LT");

        public static readonly SearchFilterOperator LTE = new("LTE");

        public static readonly SearchFilterOperator GT = new("GT");

        public static readonly SearchFilterOperator GTE = new("GTE");

        public static readonly SearchFilterOperator Between = new("BETWEEN");

        public static readonly SearchFilterOperator In = new("IN");

        public static readonly SearchFilterOperator NotIn = new("NOT_IN");

        public static readonly SearchFilterOperator HasProperty = new("HAS_PROPERTY");

        public static readonly SearchFilterOperator NotHasProperty = new("NOT_HAS_PROPERTY");

        public static readonly SearchFilterOperator ContainsToken = new("CONTAINS_TOKEN");

        public static readonly SearchFilterOperator NotContainsToken = new("NOT_CONTAINS_TOKEN");

        string IEnumeration<string>.Value => _value;

        private SearchFilterOperator(string value)
        {
            _value = value;
        }

        public bool Equals(string? other)
        {
            return _value is not null && _value.Equals(other);
        }

        public bool Equals(SearchFilterOperator other)
        {
            return Equals((object)other._value);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is string value)
            {
                return Equals((object)value);
            }
            else if (obj is SearchFilterOperator other)
            {
                return Equals((object)other._value);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override string ToString()
        {
            return _value;
        }

        public static implicit operator string(SearchFilterOperator @operator)
        {
            return @operator._value;
        }
    }
}
