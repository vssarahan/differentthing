using Lesson7.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson7.Domain.Dto
{
    public class ArtistDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<AlbumDto> Albums { get; set; }
            = new List<AlbumDto>();
    }
}
