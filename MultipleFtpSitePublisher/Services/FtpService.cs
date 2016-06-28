// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FtpService.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Services
{
    using System;

    using MultipleFtpSitePublisher.Configs;

    using Serilog;

    using WinSCP;

    public class FtpService : IFtpService
    {
        private readonly ILogger logger;

        public FtpService(ILogger logger)
        {
            this.logger = logger;
        }

        public void PutFiles(Site site, TransferableItem transferableItem)
        {
            // Setup session options
            SessionOptions sessionOptions = new SessionOptions
            {
                Protocol = site.Protocol,
                HostName = site.HostName,
                UserName = site.UserName,
                Password = site.Password
            };

            try
            {
                using (Session session = new Session())
                {
                    // Connect
                    session.Open(sessionOptions);

                    // Upload files
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.ResumeSupport.State = TransferResumeSupportState.Smart;
                    transferOptions.TransferMode = TransferMode.Binary;
                    
                    session.FileTransferred += this.OnFileTransferred;
                    var transferResult = session.PutFiles(
                        transferableItem.LocalPath,
                        site.RemoteBasePath + transferableItem.RemotePath,
                        transferableItem.Remove,
                        transferOptions);

                    // Throw on any error
                    transferResult.Check();
                }
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, "Chyba");
            }
        }

        private void OnFileTransferred(object sender, TransferEventArgs e)
        {
            if (e.Error == null)
            {
                this.logger.Information($"Upload of {e.Destination} succeeded");
            }
            else
            {
                this.logger.Error(e.Error, $"Chyba při uloadu  {e.Destination} souboru.");
            }
        }
    }
}