using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
namespace Watson.VisualRecognition.Tool
{
    public class Program
    {
        public static void Main(string[] args)
        {
             var config = new ConfigurationBuilder() //ADD THESE 3 LINES AT THE TOP OF THE MAIN METHOD
                .AddCommandLine(args)
                .Build();

            var host = new WebHostBuilder()
                .UseKestrel()
            //    .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(config) //ADD THIS LINE BEFORE 'UseStartup'
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
