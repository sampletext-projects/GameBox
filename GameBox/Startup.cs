using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GameBox.Data;
using GameBox.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace GameBox
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static string WWWRootPath { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.

        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<GameDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("GameDbContext")));
            // 
            // services.AddScoped<IActorService, ActorService>();
            // 
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<GameDbContext>().AddTokenProvider<EmailTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);
            // 
            // //Подключаем AutoMapper
            // services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            WWWRootPath = env.WebRootPath;

            app.UseHttpsRedirection();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(WWWRootPath),
                ServeUnknownFileTypes = true
            });

            IList<CultureInfo> supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("ru-RU")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            // Send index.html for every single not mapped request (SPA support)
            // app.Use(next => async context =>
            // {
            //     if (context.Request.Path.Value == "/")
            //     {
            //         await context.Response.WriteAsync(await File.ReadAllTextAsync(WWWRootPath + "/index.html"));
            //         return;
            //     }
            // 
            //     await next(context);
            // });

            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyOrigin());
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    "manage",
                    "{controller=Manage}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}