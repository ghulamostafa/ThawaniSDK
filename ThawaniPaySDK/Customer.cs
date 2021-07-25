using RestSharp;
using RestSharp.Serialization.Json;
using ThawaniPaySDK.Models.BaseModels;
using ThawaniPaySDK.Models.CustomerModels;

namespace ThawaniPaySDK
{
    public class Customer
    {
        private string apiKey = PrivateUtility.uatAPIKey;
        private URLs urls;
        public Customer()
        {
            urls = new URLs(true);
        }
        public Customer(string apiKey)
        {
            urls = new URLs(false);
            this.apiKey = apiKey;
        }

        public CustomerCreateResponseModel CreateCustomer(CustomerCreateRequestModel request)
        {
            var restClient = new RestClient(urls.Customer);
            var restRequest = PrivateUtility.PostRequest(request, apiKey);
            var json = new JsonDeserializer().Deserialize<CustomerCreateResponseModel>(restClient.Execute(restRequest));
            return json;
        }

        public BaseResponseObjectModel DeleteCustomer(string customer_id)
        {
            var restClient = new RestClient(urls.Customer + "/" + customer_id);
            var restRequest = PrivateUtility.DeleteRequest(apiKey);
            var json = new JsonDeserializer().Deserialize<BaseResponseObjectModel>(restClient.Execute(restRequest));
            return json;
        }
    }
}
