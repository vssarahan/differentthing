using BookShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Core.EF
{
    public class BookShopDbContext: DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> opt): base(opt)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
