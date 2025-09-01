using HubSpot.NET.Requests;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace HubSpot.NET
{
    public static class HubSpotExtensions
    {
        public static TRequest AddPropertyIfNotNullOrWhitespace<TRequest>(this TRequest createObjectRequest, [NotNull] string propertyName, string? value)
            where TRequest : CreateObjectRequest
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(propertyName);

            createObjectRequest.Properties ??= new Dictionary<string, object>();
            if (!string.IsNullOrWhiteSpace(value))
            {
                createObjectRequest.Properties.Add(propertyName, value);
            }

            return createObjectRequest;
        }

        public static TRequest AddPropertyIfNotNullOrWhitespace<TRequest, T>(this TRequest createObjectRequest, [NotNull] string propertyName, T source, Expression<Func<T, string?>> sourceMemberExpression)
            where TRequest : CreateObjectRequest
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(propertyName);

            var getter = sourceMemberExpression.Compile();
            string? sourcePropValue = getter(source);

            return AddPropertyIfNotNullOrWhitespace<TRequest>(createObjectRequest, propertyName, sourcePropValue);
        }

        public static TRequest AddPropertyIfNotNull<TRequest>(this TRequest createObjectRequest, [NotNull] string propertyName, object? value)
            where TRequest : CreateObjectRequest
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(propertyName);

            createObjectRequest.Properties ??= new Dictionary<string, object>();
            if (value is not null)
            {
                createObjectRequest.Properties.Add(propertyName, value);
            }

            return createObjectRequest;
        }

        public static TRequest AddPropertyIfNotNull<TRequest, T>(this TRequest createObjectRequest, [NotNull] string propertyName, T source, Expression<Func<T, object?>> sourceMemberExpression)
            where TRequest : CreateObjectRequest
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(propertyName);

            var getter = sourceMemberExpression.Compile();
            object? sourcePropValue = getter(source);

            return AddPropertyIfNotNull<TRequest>(createObjectRequest, propertyName, sourcePropValue);
        }
    }
}
