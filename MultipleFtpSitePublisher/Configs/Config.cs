// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Config.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Configs
{
    using System.Collections.Generic;

    public class Config
    {
        public Config()
        {
            this.Sites = new List<Site>();
            this.TransferableItems = new List<TransferableItem>();
        }

        public IList<Site> Sites { get; set; }

        public IList<TransferableItem> TransferableItems { get; set; }
    }
}