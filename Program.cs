using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeepakGallery.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DeepakGallery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            RunSeeding(host);

            host.Run();
        }

        private static void RunSeeding(IHost host)
        {
            var scopedFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopedFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<GalleryDataSeeder>();
                seeder.SeedAsync().Wait();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetupConfig)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void SetupConfig(HostBuilderContext context, IConfigurationBuilder configBuilder)
        {
            // Remove the default configuration.
            configBuilder.Sources.Clear();
            configBuilder.AddJsonFile("config.json", false, true)
                .AddEnvironmentVariables();
        }
    }
}
