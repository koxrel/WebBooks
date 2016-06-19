using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBooks.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public List<Book> Books { get; set; }
        [Required]
        public string Credentials { get; set; }
        [Required]
        public DateTime Time { get; set; }
    }
}