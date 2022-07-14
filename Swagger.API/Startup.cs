using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swagger.API.Models;
using System;
using System.IO;
using System.Reflection;

namespace Swagger.API
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
            services.AddDbContext<SwaggerDBContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings"]);
            });

            services.AddSwaggerGen(gen =>
            {
                gen.SwaggerDoc("productV1", new OpenApiInfo
                {
                    Version = "V1",
                    Title = "Product API",
                    Description = "Ürün Ekleme/Silme/Güncelleme API",
                    Contact = new OpenApiContact
                    {
                        Name = "Burak YILDIZ",
                        Email = "burak@mail.com",
                        Url = new Uri("https://example.com/contact")
                    }
                });
                var xmlFile = $"{ Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                gen.IncludeXmlComments(xmlPath);
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/productV1/swagger.json", "Product API");
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}