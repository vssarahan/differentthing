using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Configurations
{
    public static class ConfigureJwt
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = true;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidIssuer = configuration.GetSection("Issuer").ToString(),
                            ValidateAudience = true,
                            ValidAudience = configuration.GetSection("Audience").ToString(),
                            ValidateLifetime = true,
                            IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.ASCII.GetBytes(configuration.GetSection("Key").ToString())),
                            ValidateIssuerSigningKey = true,
                        };

                        options.Events = new JwtBearerEvents
                        {
                            OnMessageReceived = context =>
                            {
                                var token = context.Request.Query["access_token"];

                                var path = context.Request.Path;

                                if ((!string.IsNullOrEmpty(token)) && 
                                path.StartsWithSegments("/authchat"))
                                {
                                    context.Token = token;
                                }

                                return Task.CompletedTask;
                            }
                        };
                    });

            return services;
        }

    }
}
