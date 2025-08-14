using System.Net.Http.Json;
using System.Text.Json;

namespace HubSpot.NET
{
    public sealed class HubSpotRequestException : Exception
    {
        private readonly HubSpotErrorResponse? _errorResponse;

        public HubSpotRequestException(HttpResponseMessage response, HubSpotErrorResponse? hubSpotErrorResponse, Exception? innerException = null)
            : base(CreateExceptionMessage(response, hubSpotErrorResponse), innerException)
        {
            Response = response;
            _errorResponse = hubSpotErrorResponse;
        }

        public string? Category => _errorResponse?.Category;

        public string? CorrelationId => _errorResponse?.CorrelationId;

        public IReadOnlyCollection<HubSpotError> Errors => (_errorResponse?.Errors ?? []).ToList().AsReadOnly();

        public string? Status => _errorResponse?.Status;

        public HttpResponseMessage Response { get; }

        public static async Task<HubSpotRequestException> CreateAsync(HttpResponseMessage response, Exception? innerException = null)
        {
            var errorResponse = await response.Content.ReadFromJsonAsync<HubSpotErrorResponse>(JsonSerializerOptions.Web);
            return new HubSpotRequestException(response, errorResponse, innerException);
        }

        private static string CreateExceptionMessage(HttpResponseMessage response, HubSpotErrorResponse? hubSpotErrorResponse)
        {
            if (!string.IsNullOrWhiteSpace(hubSpotErrorResponse?.Message))
            {
                return hubSpotErrorResponse.Message;
            }

            if (hubSpotErrorResponse is not null)
            {
                return $"HubSpot API error: {hubSpotErrorResponse.Message} (Status: {hubSpotErrorResponse.Status}, Category: {hubSpotErrorResponse.Category})";
            }

            return $"HubSpot API request failed with status code {(int)response.StatusCode} ({response.ReasonPhrase}).";
        }
    }
}
