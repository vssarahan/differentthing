using Lesson7.Core.Repositories;
using Lesson7.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson7.API.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            services
                .AddTransient<IAlbumRepository, AlbumRepository>()
                .AddTransient<IArtistRepository, ArtistRepository>();

            return services;
        }
    }
}
