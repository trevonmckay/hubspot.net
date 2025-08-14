using System.Net.Http.Json;
using System.Text.Json;

namespace HubSpot.NET
{
    public sealed class HubSpotRequestException : Exception
    {
        public HubSpotRequestException(HttpResponseMessage response, HubSpotErrorResponse? hubSpotErrorResponse, Exception? innerException = null)
            : base(CreateExceptionMessage(response, hubSpotErrorResponse), innerException)
        {
            Response = response;
            Error = hubSpotErrorResponse;
        }

        public HubSpotErrorResponse? Error { get; }

        public HttpResponseMessage Response { get; }

        public static async Task<HubSpotRequestException> CreateAsync(HttpResponseMessage response, Exception? innerException = null)
        {
            var errorResponse = await response.Content.ReadFromJsonAsync<HubSpotErrorResponse>(JsonSerializerOptions.Web);
            return new HubSpotRequestException(response, errorResponse, innerException);
        }

        private static string CreateExceptionMessage(HttpResponseMessage response, HubSpotErrorResponse? hubSpotErrorResponse)
        {
            if (hubSpotErrorResponse is not null)
            {
                return $"HubSpot API error: {hubSpotErrorResponse.Message} (Status: {hubSpotErrorResponse.Status}, Category: {hubSpotErrorResponse.Category})";
            }

            return $"HubSpot API request failed with status code {(int)response.StatusCode} ({response.ReasonPhrase}).";
        }
    }
}
