using Lesson7.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Domain.Repositories
{
    public interface IAlbumRepository
    {
        Task<List<AlbumDto>> GetAllAsync();
        Task<AlbumDto> GetByIdAsync(Guid id);
        Task<AlbumDto> CreateAsync(AlbumDto item);
        Task<bool> UpdateAsync(AlbumDto item);
        Task<bool> DeleteAsync(Guid id);
    }
}
