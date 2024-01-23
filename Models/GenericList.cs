namespace ProvaPub.Models
{
    public class GenericList<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
        public bool HasNext { get; set; }
    }
}
