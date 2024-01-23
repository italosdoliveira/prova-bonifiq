using ProvaPub.Models;

namespace ProvaPub.Repository.Interfaces
{
    public interface IListRepository<T>
    {
        public GenericList<T> ListItems(int page);
    }
}
