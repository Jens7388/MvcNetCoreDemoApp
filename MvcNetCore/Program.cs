using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Autofac;
using Autofac.Extensions.DependencyInjection;

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using MvcNetCore.Models;
using MvcNetCore.Models.Interfaces;

namespace MvcNetCore
{
    public class Program
    {
        private static IContainer Container { get; set; }

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
     WebHost.CreateDefaultBuilder(args)
         .UseStartup<Startup>();
    }
}