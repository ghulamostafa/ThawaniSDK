using RestSharp;
using RestSharp.Serialization.Json;
using System;
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
            if (request.metadata == null)
            {
                throw new ArgumentException("Metadata is required");
            }
            else
            {
                if(String.IsNullOrEmpty(request.metadata.customer_name))
                {
                    throw new ArgumentException("Customer name is required.");
                }
                if(String.IsNullOrEmpty(request.metadata.customer_email))
                {
                    throw new ArgumentException("Customer email is required.");
                }
                else
                {
                    var addr = new System.Net.Mail.MailAddress(request.metadata.customer_email);
                    if(addr.Address != request.metadata.customer_email)
                    {
                        throw new ArgumentException("Customer email is invalid.");
                    }
                }
                if(String.IsNullOrEmpty(request.metadata.customer_phone))
                {
                    throw new ArgumentException("Customer phone is required.");
                }
            }
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
