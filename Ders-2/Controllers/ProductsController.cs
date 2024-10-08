using Ders_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ders_2.Controllers
{
	[Route("api/products")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		// Dependency Injection
		private readonly ILogger<ProductsController> _logger;

		public ProductsController(ILogger<ProductsController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IActionResult GetAllProduct()
		{
			var products = new List<Product>()
			{
				new Product { Id = 1, ProductName = "Computer"},
				new Product { Id = 2, ProductName = "Mouse"},
				new Product { Id = 3,ProductName = "Keyboard"}
			};
			_logger.LogInformation("GetAllProduct action has been called.");
			return Ok(products);
		}

		[HttpPost]
		public IActionResult GetAllProduct([FromBody] Product product)
		{
			_logger.LogWarning("Product has been created");
			return StatusCode(201);
		}
	}
}
