using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

using rjff.avmb.core.Interfaces;
using rjff.avmb.core.Notifications;
using rjff.avmb.core.Models;
using rjff.avmb.infrastructure.Context;
using rjff.avmb.infrastructure.Services;
using System.Runtime;

namespace rjff.avmb.infrastructure
{
    public static class InfraStructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextConfig(configuration)
                .AddCorsConfig()
                .AddIdentityConfig(configuration)
                .AddAstenServiceConfig(configuration);

            services.AddScoped<INotificador, Notificador>();

            return services;
        }

        public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<ApiContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
                options.LogTo(Console.WriteLine, LogLevel.Warning);
            });

            return services;
        }
        public static IServiceCollection AddCorsConfig(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Development", builder =>
                            builder
                                .AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader());

                options.AddPolicy("Production", builder =>
                            builder
                                .WithOrigins("https://localhost:9000")
                                .WithMethods("POST")
                                .AllowAnyHeader());
            });

            return services;
        }
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApiContext>();

            // Pegando o Token e gerando a chave encodada
            var JwtSettingsSection = configuration.GetSection("JwtSettings");
            services.Configure<JwtSettings>(JwtSettingsSection);

            var jwtSettings = JwtSettingsSection.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Segredo);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audiencia,
                    ValidIssuer = jwtSettings.Emissor
                };
            });

            return services;
        }

        public static IServiceCollection AddAstenServiceConfig(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<AstenServiceCredencials>(configuration.GetSection("AstenServiceCredencials"));
            services.AddTransient<IAstenService, AstenService>();

            return services;
        }
    }
}
