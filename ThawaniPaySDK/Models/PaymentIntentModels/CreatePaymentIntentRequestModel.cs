using System.Collections.Generic;

namespace ThawaniPaySDK.Models.PaymentIntentModels
{
    public class CreatePaymentIntentRequestModel
    {
        public string payment_method_id { get; set; }
        public int amount { get; set; }
        public string client_reference_id { get; set; }
        public string return_url { get; set; }
        public Dictionary<string, string> metadata { get; set; }
    }
}
