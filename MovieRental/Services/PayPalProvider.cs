namespace MovieRental.Services
{
    public class PayPalProvider : IPaymentProvider
    {
        public Task<bool> PayAsync(double price)
        {
            return Task.FromResult(true);
        }
    }
}
