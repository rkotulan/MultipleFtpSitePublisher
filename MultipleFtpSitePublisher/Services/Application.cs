// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Application.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Services
{
    public class Application : IApplication
    {
        private readonly IConfigService configService;

        private readonly IFtpService ftpService;

        public Application(IConfigService configService, IFtpService ftpService)
        {
            this.configService = configService;
            this.ftpService = ftpService;
        }

        public void Run()
        {
            var config = this.configService.GetConfig();

            foreach (var site in config.Sites)
            {
                foreach (var transferableItem in config.TransferableItems)
                {
                    this.ftpService.PutFiles(site, transferableItem);
                }
            }
        }
    }
}