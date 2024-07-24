using Microsoft.Extensions.Diagnostics.Metrics;

namespace Ocelot.GateWay
{
    public static class HostExtentions 
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("ocelot.json");
                })
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Program>();
               });
    }
}

