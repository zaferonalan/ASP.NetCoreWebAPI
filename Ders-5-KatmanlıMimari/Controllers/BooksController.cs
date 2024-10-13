using Ders_5_KatmanlıMimari.Repositories;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Ders_5_KatmanlıMimari.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private readonly RepositoryContext _Context;

		public BooksController( RepositoryContext context)
		{
			_Context = context;
		}


		[HttpGet]
		public IActionResult GetAllBoks()
		{
			var books = _Context.Books.ToList();
			return Ok(books);
		}

		[HttpGet("{id:int}")]
		public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
		{
			try
			{
				var book = _Context.Books.Where(x => x.Id.Equals(id)).SingleOrDefault();

				if (book is null)
				{
					return NotFound();
				}

				return Ok(book);
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}

		[HttpPost]
		public IActionResult CreateOneBook([FromBody] Book book)
		{
			try
			{
				if (book is null)
				{
					return BadRequest(); // 400
				}

				_Context.Books.Add(book);
				_Context.SaveChanges();

				return StatusCode(201, book);

			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}


		[HttpPut("{id:int}")]
		public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
		{
			try
			{
				var entity = _Context.Books.Where(x => x.Id.Equals(id)).SingleOrDefault();

				if (entity is null)
				{
					return NotFound(); // 404
				}

				if (id != book.Id)
				{
					return BadRequest(); // 400
				}

				entity.Title = book.Title;
				entity.Price = book.Price;

				_Context.SaveChanges();
				return Ok(book);
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}


		[HttpDelete("{id:int}")]
		public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
		{
			try
			{
				var entity = _Context.Books.Where(x => x.Id.Equals(id)).SingleOrDefault();

				if (entity is null)
				{
					return NotFound(new
					{
						statusCode = 400,
						message = $"Book with id:{id} could not found"
					}); // 404
				}

				_Context.Remove(entity);
				_Context.SaveChanges();

				return NoContent();

			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}

		[HttpPatch("{id:int}")]
		public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
		{
			try
			{
				var entity = _Context.Books.Where(x => x.Id.Equals(id)).SingleOrDefault();

				if (entity is null)
				{
					return NotFound();
				}

				bookPatch.ApplyTo(entity);
				_Context.SaveChanges();

				return NoContent(); // 204
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
		}
	}

}

