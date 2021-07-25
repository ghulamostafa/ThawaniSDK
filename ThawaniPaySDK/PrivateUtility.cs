using RestSharp;
using RestSharp.Serialization.Json;

namespace ThawaniPaySDK
{
    internal class PrivateUtility
    {
        internal static readonly string uatAPIKey = "rRQ26GcsZzoEhbrP2HZvLYDbn9C9et";
        internal static readonly string uatPublicKey = "HGvTMLDssJghr9tlN9gr4DVYt0qyBy";

        internal static RestRequest PostRequest()
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("thawani-api-key", uatAPIKey);

            return restRequest;
        }

        internal static RestRequest PostRequest(string apiKey)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("thawani-api-key", apiKey);

            return restRequest;
        }

        internal static RestRequest PostRequest(object jsonBody)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("thawani-api-key", uatAPIKey);
            restRequest.AddParameter("undefined", new JsonSerializer().Serialize(jsonBody), ParameterType.RequestBody);

            return restRequest;
        }

        internal static RestRequest PostRequest(object jsonBody, string apiKey)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("thawani-api-key", apiKey);
            restRequest.AddParameter("undefined", new JsonSerializer().Serialize(jsonBody), ParameterType.RequestBody);

            return restRequest;
        }

        internal static RestRequest GetRequest()
        {
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("thawani-api-key", uatAPIKey);

            return restRequest;
        }

        internal static RestRequest GetRequest(string apiKey)
        {
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("thawani-api-key", apiKey);

            return restRequest;
        }

        internal static RestRequest DeleteRequest()
        {
            var restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("thawani-api-key", uatAPIKey);

            return restRequest;
        }

        internal static RestRequest DeleteRequest(string apiKey)
        {
            var restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("thawani-api-key", apiKey);

            return restRequest;
        }
    }
}
