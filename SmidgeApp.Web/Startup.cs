using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Smidge;
using Smidge.Cache;
using Smidge.Options;

namespace SmidgeApp.Web
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
            services.AddSmidge(Configuration.GetSection("smidge"));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSmidge(bundle =>
            {
                //bundle.CreateJs("my-js-bundle", "~/js/");     //Klas�r�n i�erisindeki t�m js dosyalar�n� bundle yapar
                //Debug modda Cache i�lemi yapmadan her defas�nda App_Data dosyas�n� tekrar olu�turur
                bundle.CreateJs("my-js-bundle", "~/js/site.js", "~/js/site2.js")
                .WithEnvironmentOptions(
                    BundleEnvironmentOptions
                    .Create()
                    .ForDebug(
                        builder => builder
                        .EnableCompositeProcessing()
                        .EnableFileWatcher()
                        .SetCacheBusterType<AppDomainLifetimeCacheBuster>()
                        .CacheControlOptions(enableEtag: false, cacheControlMaxAge: 0)
                        )
                    .Build());

                //bundle.CreateJs("my-js-bundle", "~/js/site.js", "~/js/site2.js");
                bundle.CreateCss("my-css-bundle", "~/css/site.css", "~/lib/bootstrap/dist/css/bootstrap.css");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}