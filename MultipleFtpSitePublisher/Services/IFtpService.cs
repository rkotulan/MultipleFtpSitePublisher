// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFtpService.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Services
{
    using MultipleFtpSitePublisher.Configs;

    public interface IFtpService
    {
        void PutFiles(Site site, TransferableItem transferableItem);
    }
}