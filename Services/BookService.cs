using System;
using System.Collections.Generic;
using book_api.Models;
using book_api.Providers;

namespace book_api.Services
{
    public class BookService
    {
        private readonly IBookProvider _provider;
        private readonly Random _randall;
        public BookService(IBookProvider provider)
        {
            _provider = provider;
            _randall = new Random();
        }

        public void Create(Book book) {
            _provider.Create(book);
        }

        public Book Read(int id) {
            return _provider.Read(id);
        }

        public void Update(Book book) {
            _provider.Update(book);
        }

        public void Delete(int id) {
            _provider.Delete(id);
        }

        public void Register(Loan loan)
        {
            _provider.Register(loan);
        }

        public IEnumerable<Book> Search(string text)
        {
            return _provider.Search(text);
        }

        public bool IsAvailable(int id)
        {
            return _provider.IsVailable(id);
        }
        
        public IEnumerable<Book> ListByLoanCount()
        {
            return _provider.ListByLoanCount();
        }           

        public int RandomId() => _randall.Next();
    }
}
