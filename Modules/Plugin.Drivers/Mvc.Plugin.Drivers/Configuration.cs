using App.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Mvc.Plugin.Drivers.Controllers;
using System.Reflection;

namespace Mvc.Plugin.Drivers
{
    public class Configuration : IModuleConfiguration
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DriversController>();
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(
                    new EmbeddedFileProvider(typeof(DriversController).GetTypeInfo().Assembly));
            });
        }

        public void Configure(IApplicationBuilder app)
        {

        }
    }
}
