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


        public void ConfigureServices(IServiceCollection services) // регистрирует сервисы, которые используются приложением
        {
            services.AddControllersWithViews(); // добавляет в коллекцию сервисы, необходимые для работы контроллеров MVC

            // Контекст при этом настраивается для использования поставщика базы данных SQL Server 
            //и считывания строки подключения из конфигурации ASP.NET Core.

            services.AddDbContext<GameDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("GameDbContext")));
            //позволяет установить некоторую начальную конфигурацию. Здесь мы указываем тип пользователя и тип роли, 
            //которые будут использоваться системой Identity

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<GameDbContext>().AddTokenProvider<EmailTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);

            //Метод AddEntityFrameworkStores() устанавливает тип хранилища, которое будет применяться в Identity для хранения данных. 
            //В качестве типа хранилища здесь указывается класс контекста данных.
        }

        // Метод Configure устанавливает, как приложение будет обрабатывать запрос. Этот метод является обязательным

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //Для установки компонентов, которые обрабатывают запрос, 
                                                                                //используются методы объекта IApplicationBuilder
                                                                                //объект IWebHostEnvironment, который позволяет получить информацию о среде, в которой запускается приложение, и взаимодействовать с ней
        {
            // если приложение в процессе разработки
            if (env.IsDevelopment())
            {
                // то выводим информацию об ошибке, при наличии ошибки
                app.UseDeveloperExceptionPage();
            }

            WWWRootPath = env.WebRootPath;

            app.UseHttpsRedirection(); // https

            app.UseStaticFiles(new StaticFileOptions // поддержка статических файлов (те, которые не нужно обрабатывать серверу)
            {
                FileProvider = new PhysicalFileProvider(WWWRootPath),
                ServeUnknownFileTypes = true
            });

            IList<CultureInfo> supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("ru-RU")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions // устанавливаем культуру
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            // добавляем возможности маршрутизации
            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyOrigin()); // принимаем запросы с любого адреса
            //CORS - совместное использование ресурсов разными источниками
            
            app.UseAuthentication();
            app.UseAuthorization();

            // устанавливаем адреса, которые будут обрабатываться
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