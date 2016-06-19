using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;
using WebBooks.Entities;

namespace WebBooks.Models
{
    public class BookCart : IBookCart
    {
        public List<Book> BookItems { get; private set; } = new List<Book>();

        public void AddItem(int itemId)
        {
            if (BookItems.All(b => b.Id != itemId))
                using (var db = Factory.GetDataAccess)
                    BookItems.Add(db.GetBook(itemId));
        }

        public void RemoveItem(int itemId)
        {
            BookItems.RemoveAll(b => b.Id == itemId);
        }

        public int Checkout()
        {
            int transaction;
            using (var db = Factory.GetDataAccess)
            {
                transaction = db.CheckoutBooks(BookItems.Select(b => b.Id));
            }

            Clear();
            return transaction;
        }

        public void Clear()
        {
            BookItems = new List<Book>();
        }
    }
}