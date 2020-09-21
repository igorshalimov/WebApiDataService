using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApiDataService.Data.Interfaces;
using WebApiDataService.Data.Repository;
using WebApiGuideService.Data;

namespace WebApiDataService
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment hostEnv)
        {
            Configuration = configuration;
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build(); //получаем строку подключения
        }

        public IConfiguration Configuration { get; }
        private IConfigurationRoot _confString;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IGetValue, GetValueRepository>(); /*регистрация данных интерфейсов и класса для работы с БД*/
            services.AddTransient<IDataRequest, DataRequest>();
            services.AddDbContext<AppDBContent>(optionsAction => optionsAction.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var scope = app.ApplicationServices.CreateScope()) //выделяем область под инициализацию данных
            { AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>(); DBObjects.Initial(content); }
        }
    }
}
