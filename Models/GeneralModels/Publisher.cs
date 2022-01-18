using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public class Publisher
    {
        public int publisherId { get; set; }

        public string name { get; set; }

        // a publisher can contain more books
        public virtual ICollection<Book> books { get; set; }

    }
}
