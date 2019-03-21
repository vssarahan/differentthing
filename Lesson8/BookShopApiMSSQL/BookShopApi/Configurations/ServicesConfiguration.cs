using BookShop.Core.Repositories;
using BookShop.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Api.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            services
                .AddTransient<ICategoryRepository, CategoryRepository>()
                .AddTransient<IBookRepository, BookRepository>();
                

            return services;
        }

        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services) =>
           services.AddCors(options =>
           {
               options.AddPolicy("AllowAll", new Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder()
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowAnyOrigin()
                   .AllowCredentials()
                   .Build());
           });
    }
}
