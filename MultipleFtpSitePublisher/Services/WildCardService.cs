// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WildCardService.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Services
{
    using System;
    using System.IO;
    using System.Linq;

    using MultipleFtpSitePublisher.Configs;

    public class WildCardService : IWildCardService
    {
        public void ReplaceWildcards(TransferableItem transferableItem)
        {
            if (transferableItem.LocalPath.Contains("{NewestDictionary}"))
            {
                var wildcard = this.GetNewestDictionaryWildcard(transferableItem.LocalPath);
                transferableItem.LocalPath = transferableItem.LocalPath.Replace("{NewestDictionary}", wildcard);
                transferableItem.RemotePath = transferableItem.RemotePath.Replace("{NewestDictionary}", wildcard);
            }
        }

        internal string GetNewestDictionaryWildcard(string localPath)
        {
            var path = this.NewestDictionaryWildcardStripPath(localPath);
            var directories = Directory.GetDirectories(path);

            var dirTuple =
                directories.Select(x => new Tuple<string, DateTime>(x, Directory.GetCreationTime(x)))
                    .OrderByDescending(x => x.Item2)
                    .FirstOrDefault();

            if (dirTuple != null)
            {
                return dirTuple.Item1.Split(new[] { '\\' }).Last();
            }

            return string.Empty;
        }

        internal string NewestDictionaryWildcardStripPath(string localPath)
        {
            var index = localPath.IndexOf("{NewestDictionary}", StringComparison.CurrentCultureIgnoreCase);
            if (index > -1)
            {
                return localPath.Substring(0, index);
            }

            return localPath;
        }
    }
}