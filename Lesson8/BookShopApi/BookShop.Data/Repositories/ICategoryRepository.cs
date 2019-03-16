using BookShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(Guid id);
        Task<Category> GetByBookAsync(Guid id);
        Task<Category> CreateAsync(Category item);
        Task<bool> UpdateAsync(Category item);
        Task<bool> DeleteAsync(Guid id);
    }
}
