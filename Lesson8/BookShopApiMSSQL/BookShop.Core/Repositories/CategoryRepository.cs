using BookShop.Core.EF;
using BookShop.Data.Entities;
using BookShop.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Core.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly BookShopDbContext _context;
        private readonly IBookRepository _bookRepo;
        
        public CategoryRepository(BookShopDbContext context, IBookRepository bookRepo)
        {
            _context = context;
            _bookRepo = bookRepo;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            return await _context.Categories
                .Include(x => x.Books)
                .FirstAsync(c => c.Id == id);
        }

        public async Task<Category> GetByBookAsync(Guid id)
        {
            Book book = await _bookRepo.GetByIdAsync(id);
            if (book == null)
                throw new ApplicationException();
            return await _context.Categories
                .Include(x => x.Books)
                .FirstAsync(c => c.Id == book.CategoryId); 
        }

        public async Task<Category> CreateAsync(Category item)
        {
            var result = await _context.Categories.AddAsync(item);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> UpdateAsync(Category item)
        {
            _context.Categories.Update(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Category category = await _context.Categories.FindAsync(id);
            if (category == null)
                return false;
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
