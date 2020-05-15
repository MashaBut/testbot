using IBWT.Framework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace testProject.Configuration
{
    public static class ConfigurationExtention
    {
        public static void AddConfigurationProvider(this IServiceCollection services, IConfiguration config, IHostingEnvironment env)
        {
            services.Configure<ConnectingStrings>(config.GetSection("ConnectionStrings"));

            if (env.IsDevelopment())
            {
                services.Configure<BotOptions>(config.GetSection("TextBot"));
            }
            else
            {
                services.Configure<BotOptions>(config.GetSection("TextBot"));
            }
        }

        private static T GetConfiguration<T>(IConfiguration config, string Path) where T : class
        {
            return config.GetSection(Path).Get<T>();
        }

    }
}