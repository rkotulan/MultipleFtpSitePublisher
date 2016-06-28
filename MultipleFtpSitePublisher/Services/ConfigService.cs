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

    public class ConfigService : IConfigService
    {
        public Config GetConfig(string fileName = "config.json")
        {
            var configContent = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<Config>(configContent);
        }
    }
}