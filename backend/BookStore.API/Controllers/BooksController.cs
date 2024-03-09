using BookStore.API.Contracts;
using BookStore.Application.Services;
using BookStore.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using newBookStore.API.Contracts;

namespace newBookStore.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[Authorize]
	public class BooksController : ControllerBase
	{
		private readonly IBooksServices _booksServices;
		public BooksController(IBooksServices booksServices)
		{
			_booksServices = booksServices;
		}
		[HttpGet]
		public async Task<ActionResult<List<BooksResponse>>> GetBooks()
		{
			var books = await _booksServices.GetAllBooks();

			var response = books.Select(b => new BooksResponse(b.Id, b.Title, b.Description, b.Price));

			return Ok(response);
		}
		[HttpPost]
		public async Task<ActionResult<Guid>> CreateBook([FromBody] BooksRequest request)
		{
			var (book, error) = Book.Create(
				Guid.NewGuid(),
				request.Title,
				request.Description,
				request.Price);
			if(!string.IsNullOrEmpty(error)) 
			{ 
				return BadRequest(error);
			}

			var bookId = await _booksServices.CreateBook(book);
			return Ok(bookId);
		}
		[HttpPut("{id:guid}")]
		public async Task<ActionResult<Guid>> UpdateBook (Guid id, [FromBody] BooksRequest request)
		{
			var bookId = await _booksServices.UpdateBook(id, request.Title, request.Description, request.Price);
			return Ok(bookId);
		}
		[HttpDelete("{id:guid}")]
		public async Task<ActionResult<Guid>> DeleteBook(Guid id)
		{
			return Ok(await _booksServices.DeleteBook(id));	
		}
	}
}
