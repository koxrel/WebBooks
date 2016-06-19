using System.Collections.Generic;
using WebBooks.Entities;

namespace WebBooks.Models
{
    public interface IBookCart
    {
        List<Book> BookItems { get; }
        void AddItem(int itemId);
        int Checkout();
        void Clear();
        void RemoveItem(int itemId);
    }
}