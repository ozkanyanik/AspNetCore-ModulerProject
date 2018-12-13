using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Settings
{
    public interface IModuleConfiguration
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
        
        void Configure(IApplicationBuilder app);
    }
}
