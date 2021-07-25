namespace ThawaniPaySDK
{
    internal class URLs
    {
        private string baseURL = @"https://uatcheckout.thawani.om";
        internal URLs(bool isUAT)
        {
            baseURL = isUAT ? @"https://uatcheckout.thawani.om" : @"https://checkout.thawani.om";
        }
        internal string CheckoutSession => baseURL + @"/api/v1/checkout/session";
        internal string Payment => baseURL + @"/pay/";
        internal string RetrieveSession => baseURL + @"/api/v1/checkout/session/";
        internal string Customer => baseURL + @"/api/v1/customers";
        internal string PaymentMethods => baseURL + @"/api/v1/payment_methods";
        internal string PaymentIntent => baseURL + @"/api/v1/payment_intents";
    }
}
