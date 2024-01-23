using ProvaPub.Models;

namespace ProvaPub.Repository.Interfaces
{
    public interface ICustomerRepository : IListRepository<Customer>
    {
        public Task<Customer> Find(int customerId);
        public Task<int> Count(int customerId);
    }
}
