﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using University.Data;

namespace University
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Lägger till Automapper den statiska versionen av Automapper
            //och talar om villken configurations klass vi använder oss av
            //i det här fallet MapperProfile
            Mapper.Initialize(cfg => cfg.AddProfile<MapperProfile>());

            IWebHost webHost = CreateWebHostBuilder(args).Build();

            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                //Seed
                SeedData.Initialize(services);
            }

            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
