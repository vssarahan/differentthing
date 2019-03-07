using Lesson7.Core.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson7.API.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MusicContext>(opt =>
            opt.UseSqlServer(
                configuration.GetConnectionString("Default"),
                b => b.MigrationsAssembly("Lesson7.API")));

            return services;
        }
    }
}
