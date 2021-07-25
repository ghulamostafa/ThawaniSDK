using RestSharp;
using RestSharp.Serialization.Json;
using ThawaniPaySDK.Models.CheckoutModels;

namespace ThawaniPaySDK
{
    public class Checkout
    {
        private string apiKey = PrivateUtility.uatAPIKey;
        private string publicKey = PrivateUtility.uatPublicKey;
        private URLs urls;
        private string secretKey = "";

        public Checkout()
        {
            urls = new URLs(true);
        }
        public Checkout(string apiKey, string publicKey)
        {
            urls = new URLs(false);
            this.apiKey = apiKey;
            this.publicKey = publicKey;
        }

        public CheckoutSessionCreateResponseModel CreateSession(CheckoutSessionCreateRequestModel request)
        {
            var restClient = new RestClient(urls.CheckoutSession);
            var restRequest = PrivateUtility.PostRequest(request, apiKey);
            var json = new JsonDeserializer().Deserialize<CheckoutSessionCreateResponseModel>(restClient.Execute(restRequest));
            return json;
        }

        public string GeneratePaymentURL(string SessionId)
        {
            return urls.Payment + SessionId + "?key=" + publicKey;
        }

        public RetrieveSessionResponseModel RetrieveSession(string sessionId)
        {
            var restClient = new RestClient(urls.RetrieveSession + sessionId);
            var restRequest = PrivateUtility.GetRequest(apiKey);
            var json = new JsonDeserializer().Deserialize<RetrieveSessionResponseModel>(restClient.Execute(restRequest));
            return json;
        }
    }
}
