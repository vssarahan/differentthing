using Lesson7.Core.EF;
using Lesson7.Domain.Converters;
using Lesson7.Domain.Dto;
using Lesson7.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7.Core.Repositories
{
    public class AlbumRepository: IAlbumRepository
    {
        private readonly MusicContext _context;
        private readonly IArtistRepository _artistRepo;

        public AlbumRepository(MusicContext context, IArtistRepository
            artistRepo)
        {
            _context = context;
            _artistRepo = artistRepo;
        }

        public async Task<List<AlbumDto>> GetAllAsync()
        {
            return AlbumConverter.Convert(
                await _context.Albums.ToListAsync());
        }

        public async Task<AlbumDto> GetByIdAsync(Guid id)
        {
            var album = AlbumConverter.Convert(
                await _context.Albums.FindAsync(id));
            album.ArtistName = _artistRepo.GetByIdAsync(id)
                .Result.Name;
            return album;
        }

        public async Task<AlbumDto> CreateAsync(AlbumDto item)
        {
            var result = _context.Albums.Add(
                AlbumConverter.Convert(item));
            await _context.SaveChangesAsync();
            return AlbumConverter.Convert(result.Entity);
        }

        public async Task<bool> UpdateAsync(AlbumDto item)
        {
            if (item == null)
                return false;
            _context.Albums.Update(AlbumConverter.Convert(item));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var album = await _context
                .Albums
                .FindAsync(id);
            if (album == null)
                return false;
            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
