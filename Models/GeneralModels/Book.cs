using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Book
    {

        public Book()
        {
            this.categories = new HashSet<Category>();
        }

        public int bookId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int stock { get; set; }

        //One-to-Many relation
        public int authorId { get; set; }
        public Author author { get; set; }

        //One-to-Many relation
        public int publisherId { get; set; }

        public Publisher publisher { get; set; }

        //Many-to-Many relation
        public virtual ICollection<Category> categories { get; set; }


    }
}
