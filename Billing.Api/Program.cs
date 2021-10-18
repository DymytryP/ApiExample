using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Billing.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates host builder
        /// </summary>
        /// <param name="args">Host builder creation arguments.</param>
        /// <returns>Host builder reference.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog((host, config) =>
                {
                    config
                        .ReadFrom.Configuration(host.Configuration)
                        .Enrich.FromLogContext();
                });
    }
}
