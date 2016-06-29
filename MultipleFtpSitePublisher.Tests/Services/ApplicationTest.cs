// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationTest.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Tests.Services
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MultipleFtpSitePublisher.Services;

    [TestClass]
    public class ApplicationTest
    {
        [TestMethod]
        public void Parse_FileName_From_App_One_Argument()
        {
            var cmd = new string[] { " /configFile|config-ksystem.json " };

            var app = new Application(null, null, null);
            var fileName = app.GetConfigFileName(cmd);

            Assert.AreEqual("config-ksystem.json", fileName);
        }

        [TestMethod]
        public void Parse_FileName_From_App_Two_Argument()
        {
            var cmd = new string[] { "/configFile|config-ksystem.json", "/help" };

            var app = new Application(null, null, null);
            var fileName = app.GetConfigFileName(cmd);

            Assert.AreEqual("config-ksystem.json", fileName);
        }

        [TestMethod]
        public void Parse_FileName_From_App_No_Argument()
        {
            var cmd = new string[] { };

            var app = new Application(null, null, null);
            var fileName = app.GetConfigFileName(cmd);

            Assert.AreEqual("config.json", fileName);
        }

        [TestMethod]
        public void Parse_FileName_From_App_One_Argument_ShortParamName()
        {
            var cmd = new string[] { " /cf|config-ksystem.json " };

            var app = new Application(null, null, null);
            var fileName = app.GetConfigFileName(cmd);

            Assert.AreEqual("config-ksystem.json", fileName);
        }
    }
}