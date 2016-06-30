// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WildCardServiceTest.cs" company="K - system. CZ s.r.o.">
//   Copyright © K - system. CZ s.r.o. All Rights Reserved
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace MultipleFtpSitePublisher.Tests.Services
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MultipleFtpSitePublisher.Configs;
    using MultipleFtpSitePublisher.Services;

    [TestClass]
    public class WildCardServiceTest
    {
        [TestMethod]
        public void Find_Newest_Directory_Wildcard()
        {
            var path = "x:\\Develop\\S5\\K-System\\MoneyWorkflow\\Releases\\{NewestDictionary}\\*";

            var service = new WildCardService();
            var result = service.GetNewestDictionaryWildcard(path);

            Assert.AreEqual("1.7.1.0", result);
        }

        [TestMethod]
        public void Strip_Path_Before_Wildcard()
        {
            var path = "x:\\Develop\\S5\\K-System\\MoneyWorkflow\\Releases\\{NewestDictionary}\\*";

            var service = new WildCardService();
            var result = service.NewestDictionaryWildcardStripPath(path);

            Assert.AreEqual("x:\\Develop\\S5\\K-System\\MoneyWorkflow\\Releases\\", result);
        }

        [TestMethod]
        public void Update_Newest_Directory_Wildcard()
        {
            var item = new TransferableItem();
            item.LocalPath = "x:\\Develop\\S5\\K-System\\MoneyWorkflow\\Releases\\{NewestDictionary}\\*";
            item.RemotePath = "/wwwroot/{NewestDictionary}";

            var service = new WildCardService();
            service.ReplaceWildcards(item);

            Assert.AreEqual("x:\\Develop\\S5\\K-System\\MoneyWorkflow\\Releases\\1.7.1.0\\*", item.LocalPath);
            Assert.AreEqual("/wwwroot/1.7.1.0", item.RemotePath);
        }
    }
}