using Api.Plugin.Vehicles.Controllers;
using App.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Plugin.Vehicles
{
    public class Configuration : IModuleConfiguration
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<VehiclesController>();
        }

        public void Configure(IApplicationBuilder app)
        {

        }
    }
}
