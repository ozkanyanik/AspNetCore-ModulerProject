using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using App.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mvc.Base
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            this._modules = new ModuleRegister(configuration);
        }

        public IConfiguration Configuration { get; }
        private readonly ModuleRegister _modules;

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            foreach (var assembly in ModuleLoader())
            {
                services.AddMvc().AddApplicationPart(assembly);
            }
            this._modules.ConfigureServices(services);
        }
        private static Assembly[] ModuleLoader()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var moduleAssembly = (from assembly in assemblies
                                  from type in assembly.GetTypes()
                                  where type.BaseType == typeof(Controller)
                                  select assembly).ToArray();
            return moduleAssembly;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            this._modules.Configure(app);
        }
    }
}
