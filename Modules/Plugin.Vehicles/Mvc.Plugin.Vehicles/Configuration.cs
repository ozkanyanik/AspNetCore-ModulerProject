using App.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Mvc.Plugin.Vehicles.Controllers;
using System.Reflection;

namespace Mvc.Plugin.Vehicles
{
    public class Configuration : IModuleConfiguration
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<VehiclesController>();
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.FileProviders.Add(
                    new EmbeddedFileProvider(typeof(VehiclesController).GetTypeInfo().Assembly));
            });
        }

        public void Configure(IApplicationBuilder app)
        {

        }
    }
}
