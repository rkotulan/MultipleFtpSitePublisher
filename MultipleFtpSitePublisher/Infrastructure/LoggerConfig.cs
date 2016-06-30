// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggerConfig.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Infrastructure
{
    using System;
    using System.IO;

    using Serilog;

    public static class LoggerConfig
    {
        public static void Configure()
        {
            Log.Logger =
                new LoggerConfiguration().WriteTo.ColoredConsole()
                    .WriteTo.RollingFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"log-{Date}.txt"))
                    .CreateLogger();
        }
    }
}