// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerConfig.cs" company="Rudolf Kotulán">
//   Copyright © Rudolf Kotulán All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Infrastructure
{
    using Autofac;

    using MultipleFtpSitePublisher.Configs;
    using MultipleFtpSitePublisher.Services;

    using Serilog;

    public static class ContainerConfig
    {
        public static IContainer Configure(AppConfig appConfig)
        {
            var builder = new ContainerBuilder();

            builder.Register((c, p) => appConfig).ExternallyOwned();
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<ConfigService>().As<IConfigService>();
            builder.RegisterType<FtpService>().As<IFtpService>();
            builder.RegisterType<WildCardService>().As<IWildCardService>();

            builder.Register((c, p) => Log.Logger).As<ILogger>().ExternallyOwned();

            return builder.Build();
        }
    }
}