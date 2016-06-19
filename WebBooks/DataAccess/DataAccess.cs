using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using WebBooks.Entities;
using WebBooks.Models;

namespace WebBooks.DataAccess
{
    public class DataAccess : IDataAccess
    {
        readonly BookContext _db = new BookContext();

        public IEnumerable<Genre> GetGenres => _db.Genres.OrderBy(g => g.Name).ToList();

        private IQueryable<Book> GetBooksFromDb => _db.Books
            .Include(b => b.Genres)
            .Include(b => b.Authors);

        public IEnumerable<Book> GetBooks => GetBooksFromDb.ToList();

        public IEnumerable<Book> GetFirstNineByPopularity => GetBooksFromDb
            .OrderBy(b => b.Popularity)
            .ThenBy(b => b.Title)
            .Take(9)
            .ToList();

        public IEnumerable<Book> GetBooksByGenre(int id) => GetBooksFromDb
            .Where(b => b.Genres.Any(g => g.Id == id))
            .OrderBy(b => b.Popularity)
            .ThenBy(b => b.Title)
            .ToList();

        public IEnumerable<Book> SearchBooks(string query) => GetBooksFromDb
            .Where(b => b.FullTitle.Contains(query))
            .OrderBy(b => b.Popularity)
            .ThenBy(b => b.Title)
            .ToList();

        public Book GetBook(int id) => GetBooksFromDb
            .FirstOrDefault(b => b.Id == id);

        public int CheckoutBooks(IEnumerable<int> ids)
        {
            var books = GetBooksFromDb.Where(b => ids.Any(i => i == b.Id));
            if (books.Any(b => b.Quantity == 0))
                throw new ChangeConflictException();

            foreach (var book in books)
            {
                book.Quantity = --book.Quantity;
                book.Popularity = ++book.Popularity;
            }
            
            var order = new Order
            {
                Books = books.ToList(),
                Credentials = HttpContext.Current.User.Identity.GetUserName(),
                Time = DateTime.UtcNow
            };

            order = _db.Orders.Add(order);
            _db.SaveChanges();
            return order.Id;
        }

        public void Dispose() => _db.Dispose();
    }
}