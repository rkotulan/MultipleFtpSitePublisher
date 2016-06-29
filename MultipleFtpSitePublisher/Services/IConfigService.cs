// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConfigService.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Services
{
    using MultipleFtpSitePublisher.Configs;

    public interface IConfigService
    {
        Config GetConfig(string fileName);
    }
}