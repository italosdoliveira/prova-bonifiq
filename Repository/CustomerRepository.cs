using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository.Interfaces;

namespace ProvaPub.Repository
{
    public class CustomerRepository : ListRepository<Customer>, ICustomerRepository
    {
        protected readonly DbContext _ctx;

        public CustomerRepository(DbContext ctx) : base(ctx)
        {
        }

        public async Task<Customer> Find(int customerId)
        {
            return await _ctx.Set<Customer>().FindAsync(customerId);
        }

        public async Task<int> Count(int customerId)
        {
            return await _ctx.Set<Customer>().CountAsync(s => s.Id == customerId && s.Orders.Any());
        }
    }
}
