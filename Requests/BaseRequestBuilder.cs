using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Web;

namespace HubSpot.NET.Requests
{
    public class BaseRequestBuilder
    {
        protected BaseRequestBuilder(string baseUrl, BaseClient client)
        {
            BaseUrl = baseUrl;
            Client = client;
        }

        protected string BaseUrl { get; }

        protected BaseClient Client { get; }

        protected string AppendUrlSegment(params IEnumerable<string> segments)
        {
            string pathToAppend = string.Join('/', segments.Select(segment => segment.Trim('/')));
            return BaseUrl.TrimEnd('/') + "/" + pathToAppend;
        }

        protected static (string url, string queryString) SplitUrlAndQueryString(string url)
        {
            var urlParts = url.Split('?');
            string baseUrl = urlParts[0];
            string queryString = urlParts.Length > 1 ? urlParts[1] : string.Empty;
            return (baseUrl, queryString);
        }

        protected static string AddUrlParameter(string url, string paramName, object? value)
        {
            var (baseUrl, queryString) = SplitUrlAndQueryString(url);

            NameValueCollection valueCollection = HttpUtility.ParseQueryString(queryString);
            valueCollection.Add(paramName, value?.ToString());

            return baseUrl + CreateQueryString(valueCollection);
        }

        protected static string AddUrlParameters(string url, object someObj, JsonNamingPolicy? propNamingPolicy = null)
        {
            var appliedPropertyNamingPolicy = propNamingPolicy ?? JsonNamingPolicy.KebabCaseLower;
            var (baseUrl, queryString) = SplitUrlAndQueryString(url);

            NameValueCollection nameValueCollection = HttpUtility.ParseQueryString(queryString);
            var objProps = someObj.GetType().GetProperties();
            foreach (var prop in objProps)
            {
                var value = prop.GetValue(someObj);
                if (value is not null)
                {
                    nameValueCollection.Add(appliedPropertyNamingPolicy.ConvertName(prop.Name), value.ToString());
                }
            }

            return baseUrl + CreateQueryString(nameValueCollection);
        }

        protected static string CreateQueryString(NameValueCollection nvc)
        {
            if (nvc.AllKeys.Length == 0)
            {
                return string.Empty;
            }

            StringBuilder sb = new();
            foreach (string? key in nvc.AllKeys)
            {
                string[] values = nvc.GetValues(key) ?? Array.Empty<string>();
                foreach (string value in values)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append('&');
                    }
                    sb.Append(WebUtility.UrlEncode(key));
                    sb.Append('=');
                    sb.Append(WebUtility.UrlEncode(value));
                }
            }

            return "?" + sb.ToString();
        }
    }
}
