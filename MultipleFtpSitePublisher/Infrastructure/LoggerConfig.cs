// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggerConfig.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Infrastructure
{
    using System;
    using System.IO;

    using MultipleFtpSitePublisher.Configs;

    using Serilog;

    public static class LoggerConfig
    {
        public static void Configure(AppConfig appConfig)
        {
            if (string.IsNullOrEmpty(appConfig.LogFileName))
            {
                appConfig.LogFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"log-{Date}.txt");
            }

            Log.Logger =
                new LoggerConfiguration().WriteTo.ColoredConsole()
                    .WriteTo.RollingFile(appConfig.LogFileName)
                    .CreateLogger();
        }
    }
}