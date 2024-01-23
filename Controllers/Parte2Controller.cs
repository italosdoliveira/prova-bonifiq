using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;

namespace ProvaPub.Controllers
{
	
	[ApiController]
	[Route("[controller]")]
	public class Parte2Controller :  ControllerBase
	{
		private readonly CustomerService _customerService;
        private readonly ProductService _productService;

        /// <summary>
        /// Precisamos fazer algumas alterações:
        /// 1 - Não importa qual page é informada, sempre são retornados os mesmos resultados. Faça a correção.
        /// 2 - Altere os códigos abaixo para evitar o uso de "new", como em "new ProductService()". Utilize a Injeção de Dependência para resolver esse problema
        /// 3 - Dê uma olhada nos arquivos /Models/CustomerList e /Models/ProductList. Veja que há uma estrutura que se repete. 
        /// Como você faria pra criar uma estrutura melhor, com menos repetição de código? E quanto ao CustomerService/ProductService. Você acha que seria possível evitar a repetição de código?
        /// 
        /// </summary>
		public Parte2Controller(
			CustomerService customerService, 
			ProductService productService)
		{
			_customerService = customerService;
			_productService = productService;
		}
	
		[HttpGet("products")]
		public GenericList<Product> ListProducts(int page)
		{
			return _productService.ListWithPagination(page);
		}

		[HttpGet("customers")]
		public GenericList<Customer> ListCustomers(int page)
		{
			return _customerService.ListWithPagination(page);
		}
	}
}
