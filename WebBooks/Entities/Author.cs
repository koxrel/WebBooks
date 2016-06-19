using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBooks.Entities
{
    public class Author
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string MiddleName { get; set; }
        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}