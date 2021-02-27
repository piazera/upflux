using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using book_api.Services;
using book_api.Models;
using System.Collections.Generic;
using System;

namespace book_api.Controllers
{
    [ApiController]
    [Route("book")]
    public class LoanController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly BookService _service;

        public LoanController(BookService service, ILogger<BookController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("{id}/loan")]
        public void Loan(int id, Loan loan)
        {
            loan.Id = _service.RandomId();
            loan.BookId = id;
            _service.Register(loan);
        }

        [HttpGet("{id}/available")]
        public bool Available(int id)
        {
            return _service.IsAvailable(id);
        }

        [HttpGet("list")]
        public IEnumerable<Book> List()
        {
            return _service.ListByLoanCount();
        }
    }
}
