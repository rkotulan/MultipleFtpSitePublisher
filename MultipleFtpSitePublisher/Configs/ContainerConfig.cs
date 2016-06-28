// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerConfig.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Configs
{
    using Autofac;

    using MultipleFtpSitePublisher.Services;

    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<ConfigService>().As<IConfigService>();
            builder.RegisterType<FtpService>().As<IFtpService>();

            return builder.Build();
        }
    }
}