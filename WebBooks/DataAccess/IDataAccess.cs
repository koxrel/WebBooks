using System;
using System.Collections.Generic;
using WebBooks.Entities;

namespace WebBooks.DataAccess
{
    public interface IDataAccess : IDisposable
    {
        IEnumerable<Book> GetBooks { get; }
        IEnumerable<Genre> GetGenres { get; }
        IEnumerable<Book> GetFirstNineByPopularity { get; }
        IEnumerable<Book> SearchBooks(string query);
        int CheckoutBooks(IEnumerable<int> ids);
        Book GetBook(int id);
        IEnumerable<Book> GetBooksByGenre(int id);
    }
}