using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBooks.Entities;
using WebBooks.Models;

namespace WebBooks.Controllers
{
    public class BookController : Controller
    {
        public ActionResult Main()
        {
            try
            {
                using (var db = Factory.GetDataAccess)
                {
                    ViewBag.Books = db.GetFirstNineByPopularity;
                    ViewBag.Genres = db.GetGenres;
                }
                return View();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View("Error");
            }
        }

        public ActionResult Genre(int id)
        {
            using (var db = Factory.GetDataAccess)
            {
                var books = db.GetBooksByGenre(id);
                if (books.Any())
                    ViewBag.Books = books;
                else
                    ViewBag.Books = null;
                ViewBag.Genres = db.GetGenres;
            }
            return View("Main");
        }

        public ActionResult Detail(int id)
        {
            try
            {
                Book book;
                using (var db = Factory.GetDataAccess)
                {
                    book = db.GetBook(id);
                    ViewBag.Genres = db.GetGenres;
                }
                ViewBag.Authors = string.Join(", ", book.Authors.Select(a => a.FirstName + " " + a.LastName));

                return View(book);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View("Error");
            }
            
        }

        public ActionResult AddToCart(int id)
        {
            try
            {
                Factory.GetBookCart.AddItem(id);
                return PartialView("_CartItems");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return PartialView("_Error");
            }
        }

        public ActionResult RemoveFromCart(int id)
        {
            try
            {
                Factory.GetBookCart.RemoveItem(id);
                return PartialView("_CartForRemoval");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return PartialView("_Error");
            }

        }

        public ActionResult Cart()
        {
            return View();
        }

        [Authorize]
        public ActionResult Checkout()
        {
            try
            {
                ViewBag.Transaction = Factory.GetBookCart.Checkout();
                return View("CheckoutSuccess");
            }
            catch (ChangeConflictException)
            {
                Factory.GetBookCart.Clear();
                return View("CheckoutFail");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Search(string id)
        {
            try
            {
                using (var db = Factory.GetDataAccess)
                {
                    var books = db.SearchBooks(id.ToLower());
                    if (books.Any())
                        ViewBag.Books = books;
                    else
                        ViewBag.Books = null;

                    ViewBag.Genres = db.GetGenres;
                }
                return View("Main");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return View("Error");
            }
        }
    }
}