// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandLineParser.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Infrastructure
{
    using Fclp;

    using MultipleFtpSitePublisher.Configs;

    public static class CommandLineParser
    {
        public static AppConfig Configure(string[] args)
        {
            var parser = new FluentCommandLineParser<AppConfig>();
            parser.Setup(x => x.ConfigFileName).As('c', "configFile");
            parser.Setup(x => x.LogFileName).As('l', "logFile");
            parser.Setup(x => x.WaitForEnter).As('w', "waitForEnter");
            parser.Parse(args);
            return parser.Object;
        }
    }
}