// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Application.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Services
{
    using MultipleFtpSitePublisher.Configs;

    using Serilog;

    public class Application : IApplication
    {
        private readonly AppConfig appConfig;

        private readonly IConfigService configService;

        private readonly IFtpService ftpService;

        private readonly ILogger logger;

        private readonly IWildCardService wildCardService;

        public Application(
            IConfigService configService, 
            IFtpService ftpService, 
            ILogger logger, 
            IWildCardService wildCardService, 
            AppConfig appConfig)
        {
            this.configService = configService;
            this.ftpService = ftpService;
            this.logger = logger;
            this.wildCardService = wildCardService;
            this.appConfig = appConfig;
        }

        public void Run()
        {
            var config = this.configService.GetConfig(this.GetConfigFileName());
            if (config == null)
            {
                return;
            }

            foreach (var site in config.Sites)
            {
                this.logger.Information($"Site: {site.HostName}({site.RemoteBasePath})");
                foreach (var transferableItem in config.TransferableItems)
                {
                    this.wildCardService.ReplaceWildcards(transferableItem);
                    this.ftpService.PutFiles(site, transferableItem);
                }
            }

            this.logger.Information("Upload finished");
        }

        internal string GetConfigFileName()
        {
            if (string.IsNullOrEmpty(this.appConfig.ConfigFileName))
            {
                return "config.json";
            }

            return this.appConfig.ConfigFileName;
        }
    }
}