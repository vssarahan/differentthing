using BookShop.Core.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Api.Configurations
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(
            this IServiceCollection services, IConfiguration conf)
        {
            services
                .AddDbContext<BookShopDbContext>(options =>
                    options.UseMySQL(conf.GetConnectionString("Book")));

            return services;
        }
    }
}
