// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationTest.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Tests.Services
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MultipleFtpSitePublisher.Infrastructure;
    using MultipleFtpSitePublisher.Services;

    [TestClass]
    public class ApplicationTest
    {
        [TestMethod]
        public void Parse_FileName_From_App_No_Argument()
        {
            var cmd = new string[] { };

            var cfg = CommandLineParser.Configure(cmd);
            var app = new Application(null, null, null, null, cfg);
            var fileName = app.GetConfigFileName();

            Assert.AreEqual("config.json", fileName);
        }

        [TestMethod]
        public void Parse_FileName_From_App_One_Argument()
        {
            var cmd = new[] { "-configFile=\"x:\\config-ksystem.json\"" };

            var cfg = CommandLineParser.Configure(cmd);
            var app = new Application(null, null, null, null, cfg);
            var fileName = app.GetConfigFileName();

            Assert.AreEqual("x:\\config-ksystem.json", fileName);
        }

        [TestMethod]
        public void Parse_FileName_From_App_One_Argument_ShortParamName()
        {
            var cmd = new[] { "-c=\"config-ksystem.json\"", "--w" };

            var cfg = CommandLineParser.Configure(cmd);
            var app = new Application(null, null, null, null, cfg);
            var fileName = app.GetConfigFileName();

            Assert.AreEqual("config-ksystem.json", fileName);
            Assert.AreEqual(true, cfg.WaitForEnter);
        }

        [TestMethod]
        public void Parse_FileName_From_App_Two_Argument()
        {
            var cmd = new[] { "-configFile=\"x:\\config-ksystem.json\"", "--waitForEnter" };

            var cfg = CommandLineParser.Configure(cmd);
            var app = new Application(null, null, null, null, cfg);
            var fileName = app.GetConfigFileName();

            Assert.AreEqual("x:\\config-ksystem.json", fileName);
            Assert.AreEqual(true, cfg.WaitForEnter);
        }
    }
}