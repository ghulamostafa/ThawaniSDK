namespace ThawaniPaySDK.Models.PaymentIntentModels
{
    public class ConfirmPaymentIntentRequestModel
    {
        public string payment_method_id { get; set; }
        public int amount { get; set; }
    }
}
