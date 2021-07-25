using System.Collections.Generic;
using System.Text.Json.Serialization;
using ThawaniPaySDK.Models.CommonModels;

namespace ThawaniPaySDK.Models.CheckoutModels
{
    public class CheckoutSessionCreateRequestModel
    {
        [JsonPropertyName("client_reference_id")]
        public string client_reference_id { get; set; }
        [JsonPropertyName("mode")]
        public string mode { get; set; } = "payment";
        [JsonPropertyName("products")]
        public List<ProductModel> products { get; set; }
        [JsonPropertyName("customer_id")]
        public string customer_id { get; set; }
        [JsonPropertyName("success_url")]
        public string success_url { get; set; }
        [JsonPropertyName("cancel_url")]
        public string cancel_url { get; set; }
        [JsonPropertyName("save_card_on_success")]
        public bool save_card_on_success { get; set; }
        [JsonPropertyName("plan_id")]
        public string plan_id { get; set; }
        [JsonPropertyName("metadata")]
        //public Dictionary<string, string> metadata { get; set; }
        public MetadataModel metadata { get; set; }
    }
}
