using Api.Plugin.Drivers.Controllers;
using App.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Plugin.Drivers
{
    public class Configuration : IModuleConfiguration
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DriversController>();
        }

        public void Configure(IApplicationBuilder app)
        {

        }
    }
}
