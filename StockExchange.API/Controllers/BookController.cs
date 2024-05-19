using Microsoft.AspNetCore.Mvc;
using StockExchange.Core.Interfaces;
using StockExchange.Core.Models;
using StockExchange.API.Filters;
using StockExchange.API.Contracts.Request;
using StockExchange.API.Contracts.Response;

namespace StockExchange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    { 
        private readonly ILogger _logger;
        private readonly IBookService _bookService; 

        public BookController(
            IBookService bookServer,
            ILogger logger) 
        {
            _bookService = bookServer;
            _logger = logger;
        }

        [HttpGet]
        [ServiceFilter(typeof(MyActionAttribute))]
        public async Task<ActionResult<List<BookResponse>>> Get()
        {
            _logger.LogInformation("start Getting all books at {RequestTime}", DateTime.Now);
            var books = await _bookService.Get();
            var response = books.Select(b => new BookResponse(b.Id, b.Title,
                b.Description, b.Price));
            _logger.LogInformation("End Getting all books at {RequestTime}", DateTime.Now);

            return Ok(response);
        }


        // POST api/<BookController>
        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] BookRequest request)
        {
            var (book, error) = Book.Create(
                Guid.NewGuid(),
                request.Title,
                request.Description,
                request.Price);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }
            var bookId = await _bookService.Create(book);
            return Ok(bookId);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Guid>> Update(Guid id, [FromBody] BookRequest request)
        {
            var bookId = await _bookService.Update(id, request.Title, request.Description, request.Price);
            return Ok(bookId);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var bookId = await _bookService.Delete(id);

            return Ok(bookId);
        }
    }
}
