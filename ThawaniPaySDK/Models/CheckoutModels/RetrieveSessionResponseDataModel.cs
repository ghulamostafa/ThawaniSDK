using System;
using System.Collections.Generic;
using ThawaniPaySDK.Models.CommonModels;

namespace ThawaniPaySDK.Models.CheckoutModels
{
    public class RetrieveSessionResponseDataModel
    {
        public string session_id { get; internal set; }
        public string client_reference_id { get; internal set; }
        public string customer_id { get; internal set; }
        public List<ProductModel> products { get; internal set; }
        public int total_amount { get; internal set; }
        public string currency { get; internal set; }
        public string success_url { get; internal set; }
        public string cancel_url { get; internal set; }
        public string payment_status { get; internal set; }
        public string mode { get; internal set; }
        public string invoice { get; internal set; }
        public Dictionary<string, string> metadata { get; internal set; }
        public DateTime created_at { get; internal set; }
        public DateTime expire_at { get; internal set; }
        public object subscription { get; internal set; }
    }
}
