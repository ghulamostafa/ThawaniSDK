# ThawaniSDK (.NET)

You can download the package from Nuget by [clicking here](https://www.nuget.org/packages/ThawaniPaySDK/).

The error codes can be found on [Thawani Docs](https://docs.thawani.om/docs/thawani-ecommerce-api/docs/Error-codes.md).

## For creating a Payment Session:

```c#
var checkout = new ThawaniPaySDK.Checkout();
//If you have your API Keys and want to use the Production instead of UAT
var checkout = new ThawaniPaySDK.Checkout("apiKey", "publicKey");
var products = new List<ThawaniPaySDK.Models.CommonModels.ProductModel>()
{
    new ThawaniPaySDK.Models.CommonModels.ProductModel()
    {
        name = "Product 1",
        quantity = 1,
        unit_amount = 100
    }
};

var sessionModel = new ThawaniPaySDK.Models.CheckoutModels.CheckoutSessionCreateRequestModel()
{
    success_url = "https://domain.com/success/",
    cancel_url = "https://domain.com/cancel/",
    mode = "payment",
    client_reference_id = "",
    customer_id = "", //If you have a customer id, the customer can save their cards. We will see how you can initiate a payment intent using a saved card
    products = products,
    metadata = new Dictionary<string, string>(),
};

var sessionInfo = checkout.CreateSession(sessionModel);
var url = checkout.GeneratePaymentURL(sessionInfo.data.session_id);
```

The payment status of the Checkout Session, one of **paid**, **unpaid**, or **cancelled**. You can use this value to decide when to fulfill your customer’s order.

## For creating a Customer (This is required before you can make Payment Intents):
```c#
var customer = new ThawaniPaySDK.Customer();
var customerCreateModel = customer.CreateCustomer(new ThawaniPaySDK.Models.CustomerModels.CustomerCreateRequestModel()
{
    client_customer_id = "",
    //A unique Identification from you, it could be an Email or a UserId.
    //It would later be used for retrieval of the Customer Info
});

var customerDeleteModel = customer.DeleteCustomer("customer_id");
//The above will delete customer

var paymentMethods = new ThawaniPaySDK.PaymentMethods();
var customerPaymentMethods = paymentMethods.ListCustomerPaymentMethods("customer_id");
//This above will list out all of the cards with their Masked Numbers, NickName, Brand and an Id (Payment Method Id)

var paymentMethodDeletedModel = paymentMethods.DeleteCustomerPaymentMethod("payment_method_id");
//The above will delete Payment Method
```

## For creating a Payment Intent:

```c#
var paymentIntent = new ThawaniPaySDK.PaymentIntent();
//If you have your API Keys and want to use the Production instead of UAT
var paymentIntent = new ThawaniPaySDK.PaymentIntent("apiKey", "publicKey");
var paymentIntentModel = paymentIntent.CreatePaymentIntent(new ThawaniPaySDK.Models.PaymentIntentModels.CreatePaymentIntentRequestModel()
{
    amount = 100,
    client_reference_id = "", //The Customer Id
    metadata = new Dictionary<string, string>(),
    payment_method_id = "", //The Card Id saved at Thawani
    return_url = "https://domain.com/returnURL"
});

var paymentIntentConfirmModel = paymentIntent.ConfirmPaymentIntent(new ThawaniPaySDK.Models.PaymentIntentModels.ConfirmPaymentIntentRequestModel()
{
    amount = 100,
    payment_method_id = "", //The Card Id saved at Thawani
},
paymentIntentModel.data.id);

var paymentIntentURL = paymentIntentConfirmModel.data.next_action.url;

var paymentIntentRetrieveModel = paymentIntent.RetrievePaymentIntent(paymentIntentModel.data.id);
```

Status of this PaymentIntent, one of **requires_payment_method**, **requires_confirmation**, **requires_action**, **cancelled**, or **succeeded**

For further details, you can check [Thawani's official docs page](https://docs.thawani.om/).
