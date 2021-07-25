using RestSharp;
using RestSharp.Serialization.Json;
using ThawaniPaySDK.Models.BaseModels;
using ThawaniPaySDK.Models.PaymentMethodsModels;

namespace ThawaniPaySDK
{
    public class PaymentMethods
    {
        private string apiKey = PrivateUtility.uatAPIKey;
        private URLs urls;
        public PaymentMethods()
        {
            urls = new URLs(true);
        }
        public PaymentMethods(string apiKey)
        {
            urls = new URLs(false);
            this.apiKey = apiKey;
        }

        public ListCustomerPaymentMethodsResponseModel ListCustomerPaymentMethods(string customer_id)
        {
            var restClient = new RestClient(urls.PaymentMethods + "?customer_id" + customer_id);
            var restRequest = PrivateUtility.GetRequest(apiKey);
            var json = new JsonDeserializer().Deserialize<ListCustomerPaymentMethodsResponseModel>(restClient.Execute(restRequest));
            return json;
        }

        public BaseResponseObjectModel DeleteCustomerPaymentMethod(string payment_method_id)
        {
            var restClient = new RestClient(urls.PaymentMethods + "/" + payment_method_id);
            var restRequest = PrivateUtility.DeleteRequest(apiKey);
            var json = new JsonDeserializer().Deserialize<BaseResponseObjectModel>(restClient.Execute(restRequest));
            return json;
        }
    }
}
