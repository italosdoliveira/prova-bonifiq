using ProvaPub.Services.Dtos;

namespace ProvaPub.Services.Interfaces
{
    public interface IPaymentAdapter
    {
        public PaymentResponse Pay(decimal paymentValue, int customerId);
    }
}
