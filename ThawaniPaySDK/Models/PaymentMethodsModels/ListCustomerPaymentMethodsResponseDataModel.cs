namespace ThawaniPaySDK.Models.PaymentMethodsModels
{
    public class ListCustomerPaymentMethodsResponseDataModel
    {
        public string id { get; internal set; }
        public int bin { get; internal set; }
        public string masked_card { get; internal set; }
        public int expiry_month { get; internal set; }
        public int expiry_year { get; internal set; }
        public string nickname { get; internal set; }
        public string brand { get; internal set; }
        public string card_type { get; internal set; }
    }
}
