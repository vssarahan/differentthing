using Lesson7.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Domain.Repositories
{
    public interface IArtistRepository
    {
        Task<ArtistDto> GetByIdAsync(Guid id);
    }
}
