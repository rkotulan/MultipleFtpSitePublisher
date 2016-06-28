// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Config.cs" company="Rudolf Kotulán">
//   Copyright © Rudolf Kotulán All Rights Reserved
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

        public IList<Site> Sites { get; }

        public IList<TransferableItem> TransferableItems { get; }
    }
}