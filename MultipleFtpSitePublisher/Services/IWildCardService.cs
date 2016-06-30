// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWildCardService.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Services
{
    using MultipleFtpSitePublisher.Configs;

    public interface IWildCardService
    {
        void ReplaceWildcards(TransferableItem transferableItem);
    }
}