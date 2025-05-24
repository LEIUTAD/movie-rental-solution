
namespace MovieRental.Services
{
        public interface IPaymentProvider
        {
            Task<bool> PayAsync(double price);
        }
}
