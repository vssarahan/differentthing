using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Data.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
