using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Repository.Interfaces;

namespace ProvaPub.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;

        public CustomerService(
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        public GenericList<Customer> ListWithPagination(int page) 
        {
            return _customerRepository.ListItems(page);    
        }

        public bool CanPurchase(int customerId, decimal purchaseValue)
        {
            if (customerId <= 0) throw new ArgumentOutOfRangeException(nameof(customerId));

            if (purchaseValue <= 0) throw new ArgumentOutOfRangeException(nameof(purchaseValue));

            bool customerExists = this.CustomerExists(customerId);
            if (customerExists)
            {
                bool hasTwoOrMoreOrders = this.HasOneOrMoreOrders(customerId);
                if (hasTwoOrMoreOrders)
                {
                    bool greaterThanHundred = this.PurchaseValuesIsGreaterThanHundred(customerId, purchaseValue);
                    if (greaterThanHundred)
                        return false;
                }

                return false;
            }

            return true;
        }

        public bool CustomerExists(int customerId)
        {
            //Business Rule: Non registered Customers cannot purchase
            var customer = _customerRepository.Find(customerId).Result;
            if (customer == null) throw new InvalidOperationException($"Customer Id {customerId} does not exists");

            return true;
        }

        public bool HasOneOrMoreOrders(int customerId)
        {
            //Business Rule: A customer can purchase only a single time per month
            var baseDate = DateTime.UtcNow.AddMonths(-1);
            var ordersInThisMonth = _orderRepository.Count(customerId, baseDate).Result;
            
            return ordersInThisMonth > 0;
        }

        public bool PurchaseValuesIsGreaterThanHundred(int customerId, decimal purchaseValue)
        {
            //Business Rule: A customer that never bought before can make a first purchase of maximum 100,00
            var haveBoughtBefore = _customerRepository.Count(customerId).Result;

            return haveBoughtBefore == 0 && purchaseValue > 100;
        }

    }
}
