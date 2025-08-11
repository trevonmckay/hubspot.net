using Microsoft.Extensions.DependencyInjection;

namespace HubSpot.NET
{
    public static class HubSpotClientServiceCollectionExtensions
    {
        public const string HttpClientName = nameof(HubSpotClient);

        public static IHttpClientBuilder AddHubSpotClient(
            this IServiceCollection services,
            Action<HubSpotClientOptions> configureOptions,
            Action<IHttpClientBuilder>? configureBuilder = null)
        {
            services.Configure(configureOptions);

            var builder = services.AddHttpClient<HubSpotClient>(HttpClientName);

            configureBuilder?.Invoke(builder);

            return builder;
        }
    }
}
