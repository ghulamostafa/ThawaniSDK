using System;
using System.Collections.Generic;
using ThawaniPaySDK.Models.CommonModels;

namespace ThawaniPaySDK.Models.PaymentIntentModels
{
    public class RetrievePaymentIntentResponseDataModel
    {
        public string id { get; internal set; }
        public string client_reference_id { get; internal set; }
        public int amount { get; internal set; }
        public string currency { get; internal set; }
        public string payment_method { get; internal set; }
        public NextAction next_action { get; internal set; }
        public string status { get; internal set; }
        //public Dictionary<string, string> metadata { get; internal set; }
        public MetadataModel metadata { get; internal set; }
        public DateTime created_at { get; internal set; }
        public DateTime expire_at { get; internal set; }
    }
}
