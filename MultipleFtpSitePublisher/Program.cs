// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher
{
    using System;
    using System.IO;

    using Autofac;

    using MultipleFtpSitePublisher.Configs;
    using MultipleFtpSitePublisher.Services;

    using Serilog;

    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo
                .ColoredConsole()
                .WriteTo
                .RollingFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"log-{Date}.txt"))
                .CreateLogger();

            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }

            Log.CloseAndFlush();
        }
    }
}