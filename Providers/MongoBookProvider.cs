using System;
using System.Collections.Generic;
using System.Linq;
using book_api.Models;
using MongoDB.Driver;

namespace book_api.Providers
{
    public class MongoBookProvider : IBookProvider
    {
        private readonly IMongoCollection<Book> _books;
        private readonly IMongoCollection<Loan> _loans;
        public MongoBookProvider(MongoClient client)
        {
            var database = client.GetDatabase("books");
            _books = database.GetCollection<Book>("books");
            _loans = database.GetCollection<Loan>("loans");
        }

        public Book Create(Book book)
        {
            _books.InsertOne(book);
            return book;

        }
        public Book Read(int id) => _books.Find<Book>(b => b.Id == id).FirstOrDefault();
        public void Update(Book book) => _books.ReplaceOne(b => b.Id == book.Id, book);
        public void Delete(int id) => _books.DeleteOne(b => b.Id == id);

        public Loan Register(Loan loan)
        {
            _loans.InsertOne(loan);
            return loan;

        }

        public IEnumerable<Book> Search(string text) =>
            _books.Find<Book>(b => b.Title.ToLower().Contains(text.ToLower())
                                || b.Author.ToLower().Contains(text.ToLower())).ToList();

        public bool IsVailable(int id) => _loans.CountDocuments(l => l.BookId == id && l.Returned == null) > 0;

        public IEnumerable<Book> ListByLoanCount()
        {
            var loans = _loans.Find(_ => true).ToList();
            var group = loans.GroupBy(l => l.BookId);
            var sort =  group.OrderByDescending(g => g.Count());
            var books = _books.Find(_ => true).ToList().ToDictionary(b => b.Id);
            return sort.Select(l => books[l.Key]);
        }
    }
}
