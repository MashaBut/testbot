using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace testProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration((hostBuilder, configBuilder) => configBuilder
                   .AddJsonFile("appsettings.json")
                   .AddJsonFile($"appsettings.{hostBuilder.HostingEnvironment.EnvironmentName}.json", true)
               ).UseStartup<Startup>();
    }
}
