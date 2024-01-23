using ProvaPub.Models;
using ProvaPub.Services.Adapters;
using ProvaPub.Services.Dtos;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services
{
    public class OrderService
	{
		public Dictionary<string, IPaymentAdapter> paymentMethods;

        public OrderService()
        {
			paymentMethods = new Dictionary<string, IPaymentAdapter>
			{
				{ "pix", new PixAdapter()},
				{ "creditcard", new CreditCardAdapter()},
				{ "paypal", new PayPalAdapter()}
			};
        }

        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
		{
			try
			{
				PaymentResponse result = this.paymentMethods[paymentMethod].Pay(paymentValue, customerId);

                return await Task.FromResult(new Order()
                {
					CustomerId = customerId,
                    Value = paymentValue
                });
            }
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
            }
		}
	}
}
