using System;
using Entities.Context;
using Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FirstApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureControllerAndNewtonsoftJson();
            services.ConfigureSqlContext(Configuration);
            services.ConfigureWrappers();
            services.AddAutoMapper(typeof(Startup));
            //services.ConfigureAuthentication(Configuration);
            services.ConfigureIdentity();
            services.ConfigureSwagger();
            services.ConfigureCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory,
            AppDbContext context)
        {
            context.Database.EnsureCreated();
            context.Database.Migrate();
        
            // loggerFactory.AddFile($"Logs/{DateTime.Now.ToString("yyyyMMddHHmmss")}.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(opt =>
                {
                    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    opt.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseCors("corsPolicy");
            
            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}