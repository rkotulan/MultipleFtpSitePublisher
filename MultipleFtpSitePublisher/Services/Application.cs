// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Application.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Services
{
    using System;
    using System.Linq;

    using Serilog;

    public class Application : IApplication
    {
        private readonly IConfigService configService;

        private readonly IFtpService ftpService;

        private readonly ILogger logger;

        public Application(IConfigService configService, IFtpService ftpService, ILogger logger)
        {
            this.configService = configService;
            this.ftpService = ftpService;
            this.logger = logger;
        }

        public void Run()
        {
            var cmdArgs = Environment.GetCommandLineArgs();
            var config = this.configService.GetConfig(this.GetConfigFileName(cmdArgs));
            if (config == null)
            {
                return;                
            }

            foreach (var site in config.Sites)
            {
                this.logger.Information($"Site: {site.HostName}({site.RemoteBasePath})");
                foreach (var transferableItem in config.TransferableItems)
                {
                    this.ftpService.PutFiles(site, transferableItem);
                }
            }

            this.logger.Information("Upload finished");
        }

        internal string GetConfigFileName(string[] commandLineArgs)
        {
            foreach (var commandLineArg in commandLineArgs.Select(x => x.Trim()))
            {
                if (commandLineArg.StartsWith("/configFile") || commandLineArg.StartsWith("/cf"))
                {
                    var parts = commandLineArg.Split('|');
                    if (parts.Length == 2)
                    {
                        return parts[1].Trim();
                    }
                }
            }

            return "config.json";
        }
    }
}