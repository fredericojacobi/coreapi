using Contracts.Repositories;
using Contracts.Services;
using Entities.Context;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Repository;
using Services;

namespace Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetSection("ConnectionString:ReminderApp").Value;
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connection, opt => opt.EnableRetryOnFailure());
                options.EnableSensitiveDataLogging();
            });
        }

        public static void ConfigureWrappers(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IServiceWrapper, ServiceWrapper>();
        }
        
        public static void ConfigureControllerAndNewtonsoftJson(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(opt =>
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<Guid>>(options =>
                {
                    options.Password.RequiredLength = 4;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1.0 alpha",
                    Title = "",
                    Description = "",
                    Contact = new OpenApiContact
                    {
                        Email = "fredvjacobi@gmail.com"
                    }
                });
            });
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "corsPolicy",
                    builder =>
                    {
                        builder.WithOrigins("*");
                    });
            });
        }
    }
}