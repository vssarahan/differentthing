using BookShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(Guid id);
        Task<List<Book>> GetByCategoryAsync(Guid id);
        Task<Book> CreateAsync(Book item);
        Task<bool> UpdateAsync(Book item);
        Task<bool> DeleteAsync(Guid id);
    }
}
