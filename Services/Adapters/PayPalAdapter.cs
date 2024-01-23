using ProvaPub.Services.Dtos;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services.Interfaces
{
    public class PayPalAdapter : IPaymentAdapter
    {
        public PaymentResponse Pay(decimal paymentValue, int customerId)
        {
            return new PaymentResponse()
            {
                IsSuccess = true,
                Message = "The payment with credit card is sucessed"
            };
        }
    }
}
