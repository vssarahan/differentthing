using BookShop.Core.EF;
using BookShop.Data.Entities;
using BookShop.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Core.Repositories
{
    public class BookRepository: IBookRepository
    {
        private readonly BookShopDbContext _context; 

        public BookRepository(BookShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(Guid id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<List<Book>> GetByCategoryAsync(Guid id)
        {
            return await _context.Books.Where(b => b.CategoryId == id).ToListAsync();
        }

        public async Task<Book> CreateAsync(Book item)
        {
            var result = await _context.Books.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> UpdateAsync(Book item)
        {
            _context.Books.Update(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Book book = await _context.Books.FindAsync(id);
            if (book == null)
                return false;
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
