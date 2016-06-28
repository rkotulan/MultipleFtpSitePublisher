// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Application.cs" company="Rudolf Kotulán">
//   Copyright © Rudolf Kotulán All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Services
{
    using MultipleFtpSitePublisher.Configs;

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
            var config = this.configService.GetConfig();

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
    }
}