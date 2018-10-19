using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ReducibleNodeDemo
{
    public class App
    {
        private readonly ILogger<App> logger;
        private readonly DataContext context;

        public App(ILogger<App> logger, DataContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public void Run()
        {
            this.logger.LogInformation($"Starting...");
            Stopwatch sw = new Stopwatch();
            sw.Start();

            ILookup<int, string> data = 
                this.context.Foos
                    .SelectMany(f => f.FooBars.Select(fb => new { f.Id, fb.Bar.Value }))
                    .ToLookup(fb => fb.Id, fb => fb.Value);

            Console.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));

            this.logger.LogInformation($"Finished! ({sw.Elapsed})");
            Console.ReadKey();
        }
    }
}
