using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository.Interfaces;

namespace ProvaPub.Repository
{
    public class ProductRepository : ListRepository<Product>, IProductRepository
    {
        protected readonly DbContext _ctx;

        public ProductRepository(DbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
    }
}
