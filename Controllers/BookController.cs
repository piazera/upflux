using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using book_api.Services;
using book_api.Models;
using System.Collections.Generic;

namespace book_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly BookService _service;

        public BookController(BookService service, ILogger<BookController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("")]
        public void Create(Book book)
        {
            _service.Create(book);
        }

        [HttpGet("{id}")]
        public Book Read(int id)
        {
            return _service.Read(id);
        }

        [HttpPut("")]
        public void Upate(Book book)
        {
            _service.Update(book);
        }

        [HttpDelete("{id}")]
        public void Create(int id)
        {
            _service.Delete(id);
        }

        [HttpGet("all")]
        public IEnumerable<Book> All(string text)
        {
            return _service.Search(text);
        }
    }
}
