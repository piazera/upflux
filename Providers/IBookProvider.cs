using System;
using System.Collections.Generic;
using book_api.Models;

namespace book_api.Providers
{
    public interface IBookProvider
    {
        Book Create(Book book);
        Book Read(int id);
        void Update(Book book);
        void Delete(int id);
        Loan Register(Loan loan);
        IEnumerable<Book> Search(string text);
        bool IsVailable(int id);
        IEnumerable<Book> ListByLoanCount();
    }
}
