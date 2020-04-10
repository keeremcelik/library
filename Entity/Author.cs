using System;
using System.Collections.Generic;

namespace Entity
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool isApproved { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
