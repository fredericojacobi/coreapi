using System;
using System.Text;
using Contracts;
using Entities;
using Entities.Context;
using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository;

namespace FirstApp.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetSection("ConnectionString:ReminderApp").Value;
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connection, opt => opt.EnableRetryOnFailure());
            });
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        /*
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration Configuration)
        {
            var key = Encoding.ASCII.GetBytes(Configuration["Authentication:Token"]);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }
        */
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
                    Title = "Prática de Banco de Dados",
                    Description = "Gerenciamento de empresas com: Usuários, Empresas, Filiais, Eventos, Locais (Cidades), Pontos Eletrônicos e Lembretes.",
                    Contact = new OpenApiContact
                    {
                        Email = "fredvjacobi@gmail.com"
                    }
                });
            });
        }
    }
}