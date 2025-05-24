namespace MovieRental.Services
{
    public class MbWayProvider : IPaymentProvider
    {
        public Task<bool> PayAsync(double price)
        {
            return Task.FromResult(true);
        }
    }
}
