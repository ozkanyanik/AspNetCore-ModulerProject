using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Settings
{
    public class ModuleRegister
    {
        private readonly IEnumerable<IModuleConfiguration> _modules;
        private readonly IConfiguration _configuration;

        public ModuleRegister(IConfiguration configuration)
        {
            this._configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));

            AppSettings appSettings = configuration.Get<AppSettings>();
            this._modules = appSettings.Modules
                .Select(s =>
                {
                    Type type = Type.GetType(s.Type);

                    if (type == null)
                    {
                        throw new TypeLoadException(
                            $"Cannot load type \"{s.Type}\"");
                    }

                    IModuleConfiguration module = (IModuleConfiguration)Activator.CreateInstance(type);
                    return module;
                }
            );
        }

        public void ConfigureServices(IServiceCollection services)
        {
            foreach (IModuleConfiguration module in this._modules)
            {
                module.ConfigureServices(services, this._configuration);
                
            }
        }

        public void Configure(IApplicationBuilder app)
        {
            foreach (IModuleConfiguration module in this._modules)
            {
                module.Configure(app);
            }
        }
    }

}
