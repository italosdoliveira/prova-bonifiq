namespace ProvaPub.Repository.Interfaces
{
    public interface IOrderRepository
    {
        public Task<int> Count(int customerId, DateTime baseDate);
    }
}
