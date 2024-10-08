using Ders_3.Data;
using Ders_3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ders_3.Controllers
{
	[Route("api/books")]
	[ApiController]
	public class BookController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetAllBooks() 
		{
			var books = ApplicationContext.Books.ToList();

			return Ok(books);
		}

		[HttpGet("{id:int}")]
		public IActionResult GetBook([FromRoute(Name = "id")] int id)
		{
			var book = ApplicationContext
				.Books
				.Where(b => b.Id == id)
				.SingleOrDefault();

            if (book == null)
            {
				return NotFound(); // 404
            }

            return Ok(book);
		}

		[HttpPost]
		public IActionResult CreateOneBook([FromBody] Book book) 
		{
			try
			{
                if (book is null)
                {
					return BadRequest(); //404
                }

				ApplicationContext.Books .Add(book);
				return StatusCode(201, book);
            }
			catch (Exception ex) 
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
