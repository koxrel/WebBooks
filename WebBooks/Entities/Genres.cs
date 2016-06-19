using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBooks.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}