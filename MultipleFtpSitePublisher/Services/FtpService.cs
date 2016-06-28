// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FtpService.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Services
{
    using System;

    using MultipleFtpSitePublisher.Configs;

    using WinSCP;

    public class FtpService : IFtpService
    {
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

                    var transferResult = session.PutFiles(
                        transferableItem.LocalPath,
                        site.RemoteBasePath + transferableItem.RemotePath,
                        transferableItem.Remove,
                        transferOptions);

                    // Throw on any error
                    transferResult.Check();

                    // Print results
                    foreach (TransferEventArgs transfer in transferResult.Transfers)
                    {
                        // TODO : log
                        Console.WriteLine($"Upload of {transfer.FileName} succeeded");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}