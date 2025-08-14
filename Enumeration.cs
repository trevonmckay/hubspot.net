using HubSpot.NET.Models;
using System.Reflection;

namespace HubSpot.NET
{
    internal static class Enumeration
    {
        public static T FromValue<T, TValue>(TValue value)
            where T : IEnumeration<TValue>
        {
            ArgumentNullException.ThrowIfNull(value);
            
            BindingFlags constructorBindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            ConstructorInfo? constructor = typeof(T).GetConstructor(constructorBindingFlags, [typeof(TValue)]);
            return constructor is null
                ? throw new InvalidOperationException($"No constructor found for {typeof(T).Name} that accepts a single argument of type {typeof(TValue).Name}")
                : (T)constructor.Invoke([value]);
        }
    }
}
