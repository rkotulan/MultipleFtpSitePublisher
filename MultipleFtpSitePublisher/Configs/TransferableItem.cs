// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransferableItem.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Configs
{
    public class TransferableItem
    {
        public string LocalPath { get; set; }

        public string RemotePath { get; set; }

        public bool Remove { get; set; }
    }
}