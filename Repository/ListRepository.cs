using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;

namespace ProvaPub.Repository
{
    public abstract class ListRepository<T> where T : class
    {
        protected DbContext _ctx;

        protected ListRepository(DbContext ctx)
        {
            _ctx = ctx;
        }

        public GenericList<T> ListItems(int page)
        {
            int position = page == 1 ? 0 : page * 10 - 10;
            var items = _ctx.Set<T>()
                .Skip(position)
                .Take(10)
                .ToList();

            return new GenericList<T>() { HasNext = false, TotalCount = 10, Items = items };
        }
    }
}
