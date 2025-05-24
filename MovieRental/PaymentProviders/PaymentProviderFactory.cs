using MovieRental.Services;

namespace MovieRental.PaymentProviders
{
    public static class PaymentProviderFactory
    {
        public static IPaymentProvider GetProvider(string method)
        {
            return method.ToLower() switch
            {
                "mbway" => new MbWayProvider(),
                "paypal" => new PayPalProvider(),
                _ => throw new ArgumentException($"Unsupported payment method: {method}")
            };
        }
    }
}
