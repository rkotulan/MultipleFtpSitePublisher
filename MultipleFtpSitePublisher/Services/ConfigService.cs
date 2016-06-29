// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigService.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Services
{
    using System.IO;

    using MultipleFtpSitePublisher.Configs;

    using Newtonsoft.Json;

    using Serilog;

    public class ConfigService : IConfigService
    {
        private readonly ILogger logger;

        public ConfigService(ILogger logger)
        {
            this.logger = logger;
        }

        public Config GetConfig(string fileName)
        {
            if (!File.Exists(fileName))
            {
                this.logger.Information("Config file not found.");
                return null;
            }

            var configContent = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<Config>(configContent);
        }
    }
}