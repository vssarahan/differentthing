using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Data.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
    }
}
