using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProductPlayground.Application.Interfaces.RedisCache;
using ProductPlayground.Application.Interfaces.Tokens;
using ProductPlayground.Infrastructure.RedisCache;
using ProductPlayground.Infrastructure.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPlayground.Infrastructure
{
    public static class Registration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtConfiguration = configuration.GetSection("JWT");
            services.Configure<TokenSettings>(jwtConfiguration);
            services.AddTransient<ITokenService, TokenService>();

            services.Configure<RedisCacheSettings>(configuration.GetSection("RedisCacheSettings"));
            services.AddTransient<IRedisCacheService, RedisCacheService>();

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = jwtConfiguration.GetValue<bool>("ValidateIssuer"),
                    ValidateAudience = jwtConfiguration.GetValue<bool>("ValidateAudience"),
                    ValidateIssuerSigningKey = jwtConfiguration.GetValue<bool>("ValidateIssuerSigningKey"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.GetValue<string>("Secret"))),
                    ValidateLifetime = jwtConfiguration.GetValue<bool>("ValidateIssuerSigningKey"),
                    ValidIssuer = jwtConfiguration.GetValue<string>("ValidIssuer"),
                    ValidAudience = jwtConfiguration.GetValue<string>("ValidAudience"),
                    ClockSkew = TimeSpan.Zero
                };
            });

            // TODO This section refactorable...
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.Configuration = configuration["RedisCacheSettings:ConnectionString"];
                opt.InstanceName = configuration["RedisCacheSettings:InstanceName"];
            });
        }
    }
}
