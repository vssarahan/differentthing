using Lesson7.Core.EF;
using Lesson7.Domain.Converters;
using Lesson7.Domain.Dto;
using Lesson7.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Core.Repositories
{
    public class ArtistRepository: IArtistRepository
    {
        private readonly MusicContext _context;

        public ArtistRepository(MusicContext context)
        {
            _context = context;
        }

        public async Task<ArtistDto> GetByIdAsync(Guid id)
        {
            return ArtistConverter.Convert(
                await _context.Artists.FindAsync(id));
        }
    }
}
