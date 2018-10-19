using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace ReducibleNodeDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // create service collection
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);

            // create service provider
            ServiceProvider provider = services.BuildServiceProvider();

            // entry to run app
            provider.GetService<App>().Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // add config
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddSingleton(config);

            // add logging
            services.AddSingleton(new LoggerFactory().AddConsole());
            services.AddLogging();

            // add db context
            services.AddDbContext<DataContext>(o =>
            {
                o.UseSqlServer(config.GetConnectionString("SqlConnection"));
                o.EnableSensitiveDataLogging();
            });

            // add app
            services.AddTransient<App>();
        }
    }
}
