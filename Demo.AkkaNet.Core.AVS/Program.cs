using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Demo.AkkaNet.Core.AVS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Avs API";
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        //.ConfigureKestrel((context, options) =>
        //    {
        //        // Set properties and call methods on options
        //        options.Listen(IPAddress.Loopback, 7000);
        //        options.Listen(IPAddress.Loopback, 7001);
        //    });
    }
}
