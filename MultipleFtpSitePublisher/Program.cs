// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher
{
    using Autofac;

    using MultipleFtpSitePublisher.Configs;
    using MultipleFtpSitePublisher.Services;

    public class Program
    {
        public static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
        }
    }
}