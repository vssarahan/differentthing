using Lesson7.Domain.Dto;
using Lesson7.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson7.Domain.Converters
{
    public static class ArtistConverter
    {
        public static Artist Convert(
            ArtistDto artist)
        {
            return new Artist
            {
                Name = artist.Name,
                Id = artist.Id
            };
        }

        public static ArtistDto Convert(
            Artist artist)
        {
            return new ArtistDto
            {
                Name = artist.Name,
                Id = artist.Id
            };
        }
    }
}
