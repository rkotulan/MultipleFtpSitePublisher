// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerConfig.cs" company="Rudolf Kotulán">
//   Copyright © Rudolf Kotulán All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Configs
{
    using Autofac;

    using MultipleFtpSitePublisher.Services;

    using Serilog;

    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<ConfigService>().As<IConfigService>();
            builder.RegisterType<FtpService>().As<IFtpService>();

            builder.Register((c, p) => Log.Logger).As<ILogger>().ExternallyOwned();

            return builder.Build();
        }
    }
}