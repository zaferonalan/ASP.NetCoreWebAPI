using Ders_3.Data;
using Ders_3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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

		[HttpPut("{id:int}")]
		public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book) 
		{
			var entity = ApplicationContext
				.Books
				.Find(b => b.Id.Equals(id));

			if (entity is null)
			{
				return NotFound(); // 404
			}

            if (id != book.Id)
            {
				return BadRequest(); // 400
            }

			ApplicationContext.Books.Remove(entity);
			book.Id = id;
			ApplicationContext.Books.Add(book);
			return Ok(book);

        }

		[HttpDelete]
		public IActionResult GetDeleteAllBook()
		{
			ApplicationContext.Books.Clear();
			return NoContent();
		}

		[HttpDelete("{id:int}")]
		public IActionResult GetDeleteOneBook([FromRoute (Name = "id")] int id)
		{
			var entity = ApplicationContext.Books.Find(x => x.Id.Equals(id));

            if (entity is null)
            {
				return NotFound(new
				{
					statusCode = 404,
					messages = $"Book with id:{id} could not found"
				});
            }

			ApplicationContext.Books.Remove(entity);
			return NoContent();
        }

		[HttpPatch("{id:int}")]
		public IActionResult PartiallyUpdateOneBook([FromRoute(Name ="id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
		{
			var entity = ApplicationContext.Books.Find(b => b.Id.Equals(id));

            if (entity is null)
            {
				return NotFound(); // 404
            }

			bookPatch.ApplyTo(entity);
			return NoContent(); // 204
        }
	}
}
