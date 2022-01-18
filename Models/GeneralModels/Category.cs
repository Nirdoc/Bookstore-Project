using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Category
    {

        public Category()
        {
            this.books = new HashSet<Book>();
        }

        public int categoryId { get; set; }

        public string name { get; set; }

        public virtual ICollection<Book> books { get; set; }
    }
}
