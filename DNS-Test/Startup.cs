using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNS_Test.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DNS_Test
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			// получаем строку подключения из файла конфигурации
			string connection = Configuration.GetConnectionString("DefaultConnection");
			// добавляем контекст TreeContext в качестве сервиса в приложение
			services.AddDbContext<TreeContext>(options =>
				options.UseSqlServer(connection));
			services.AddTransient<ITreeRepository, TreeRepository>();
			services.AddMvc();
		}

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
