using RestSharp;
using RestSharp.Serialization.Json;
using System;
using ThawaniPaySDK.Models.PaymentIntentModels;

namespace ThawaniPaySDK
{
    public class PaymentIntent
    {
        private string apiKey = PrivateUtility.uatAPIKey;
        private URLs urls;
        public PaymentIntent()
        {
            urls = new URLs(true);
        }

        public PaymentIntent(string apiKey)
        {
            urls = new URLs(false);
            this.apiKey = apiKey;
        }

        public CreatePaymentIntentReponseModel CreatePaymentIntent(CreatePaymentIntentRequestModel request)
        {
            if (request.metadata == null)
            {
                throw new ArgumentException("Metadata is required");
            }
            else
            {
                if (String.IsNullOrEmpty(request.metadata.customer_name))
                {
                    throw new ArgumentException("Customer name is required.");
                }
                if (String.IsNullOrEmpty(request.metadata.customer_email))
                {
                    throw new ArgumentException("Customer email is required.");
                }
                else
                {
                    var addr = new System.Net.Mail.MailAddress(request.metadata.customer_email);
                    if (addr.Address != request.metadata.customer_email)
                    {
                        throw new ArgumentException("Customer email is invalid.");
                    }
                }
                if (String.IsNullOrEmpty(request.metadata.customer_phone))
                {
                    throw new ArgumentException("Customer phone is required.");
                }
            }
            var restClient = new RestClient(urls.PaymentIntent);
            var restRequest = PrivateUtility.PostRequest(request, apiKey);
            var json = new JsonDeserializer().Deserialize<CreatePaymentIntentReponseModel>(restClient.Execute(restRequest));
            return json;
        }

        public ConfirmPaymentIntentResponseModel ConfirmPaymentIntent(ConfirmPaymentIntentRequestModel request, string payment_intent_id)
        {
            var restClient = new RestClient(urls.PaymentIntent + "/" + payment_intent_id + "/confirm");
            var restRequest = PrivateUtility.PostRequest(request, apiKey);
            var json = new JsonDeserializer().Deserialize<ConfirmPaymentIntentResponseModel>(restClient.Execute(restRequest));
            return json;
        }

        public CancelPaymentIntentResponseModel CancelPaymentIntent(string payment_intent_id)
        {
            var restClient = new RestClient(urls.PaymentIntent + "/" + payment_intent_id + "/cancel");
            var restRequest = PrivateUtility.PostRequest(apiKey);
            var json = new JsonDeserializer().Deserialize<CancelPaymentIntentResponseModel>(restClient.Execute(restRequest));
            return json;
        }

        public RetrievePaymentIntentResponseModel RetrievePaymentIntent(string payment_intent_id)
        {
            var restClient = new RestClient(urls.PaymentIntent + "/" + payment_intent_id);
            var restRequest = PrivateUtility.GetRequest(apiKey);
            var json = new JsonDeserializer().Deserialize<RetrievePaymentIntentResponseModel>(restClient.Execute(restRequest));
            return json;
        }
    }
}
