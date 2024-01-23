using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository.Interfaces;

namespace ProvaPub.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContext _ctx;

        public OrderRepository(DbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<int> Count(int customerId, DateTime baseDate)
        {
            return await _ctx.Set<Order>().CountAsync(s => s.CustomerId == customerId && s.OrderDate >= baseDate);
        }
    }
}
