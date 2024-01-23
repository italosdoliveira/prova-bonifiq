using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Repository.Interfaces;

namespace ProvaPub.Services
{
    public class ProductService 
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public GenericList<Product> ListWithPagination(int page) {
            return _productRepository.ListItems(page);
        }
    }
}
