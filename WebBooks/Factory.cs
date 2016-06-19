using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBooks.DataAccess;
using WebBooks.Models;

namespace WebBooks
{
    public static class Factory
    {
        private static IBookCart _bookCart;

        public static IDataAccess GetDataAccess => new DataAccess.DataAccess();

        public static IBookCart GetBookCart => _bookCart ?? (_bookCart = new BookCart());
    }
}