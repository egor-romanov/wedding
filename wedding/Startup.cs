using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Swagger;
using PrimaryStorage;
using wedding.Services;
using Microsoft.OpenApi.Models;

namespace wedding
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();

            services.AddTransient<IDbInitializer, DbInitializer>();

            // Registers the Swagger generator, defining one or more Swagger documents.
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Natasha & Egor Wedding",
                    Description = "Wedding API Swagger",
                    Contact = new OpenApiContact {Email = "romanov.egor@gmail.com", Name = "Egor Romanov"}
                });
            });

            services.AddEntityFrameworkNpgsql().AddDbContextPool<PrimaryStorageDb>(
                options => options.UseNpgsql(Configuration.GetConnectionString("PrimaryStorage"), o => o.SetPostgresVersion(9, 6)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSwagger().UseSwaggerUI(
                    options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Wedding API v1"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
