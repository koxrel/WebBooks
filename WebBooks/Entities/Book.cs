using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebBooks.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [MaxLength(200)]
        [Required]
        public string Title { get; set; }

        public List<Author> Authors { get; set; }
        [MaxLength(15)]
        public string Isbn { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int Quantity { get; set; }

        public List<Genre> Genres { get; set; }

        public int Popularity { get; set; }

        public string FullTitle { get; set; }

        public List<Order> Orders { get; set; }
    }
}