// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher
{
    using System;

    using Autofac;

    using MultipleFtpSitePublisher.Infrastructure;
    using MultipleFtpSitePublisher.Services;

    using Serilog;

    public class Program
    {
        public static void Main(string[] args)
        {
            var appConfig = CommandLineParser.Configure(args);
            LoggerConfig.Configure(appConfig);

            var container = ContainerConfig.Configure(appConfig);
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }

            Log.CloseAndFlush();

            if (appConfig.WaitForEnter)
            {
                Console.ReadLine();
            }
        }
    }
}