// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Site.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Configs
{
    using WinSCP;

    public class Site
    {
        public string HostName { get; set; }

        public string Password { get; set; }

        public Protocol Protocol { get; set; }

        public string UserName { get; set; }

        public string RemoteBasePath { get; set; }
    }
}