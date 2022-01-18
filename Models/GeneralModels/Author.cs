using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Author
    {
        [ForeignKey("Book")]
        public int authorId { get; set; }
        public String name { get; set; }

        public DateTime yearOfBirth { get; set; }

        public DateTime yearOfDeath { get; set; }

        //public virtual ICollection<Book> books { get; set; }
    }
}
