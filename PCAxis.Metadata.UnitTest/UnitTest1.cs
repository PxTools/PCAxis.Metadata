using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace PCAxis.Metadata.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string metaid_raw = "KORTNAVN:aku";
            string expectedLink = "https://www.ssb.no/aku#om-statistikken";
            string expectedLinkText = "Om statistikken";

            var metaLinkCreator = new MetaLinkManager();
            Assert.IsTrue(metaLinkCreator.LoadConfiguration("metadata.config"));


            var links = metaLinkCreator.GetTableLinks(metaid_raw, "no");
            Assert.AreEqual(expectedLink, links[0].Link);
            Assert.AreEqual(expectedLinkText, links[0].LinkText);

        }

        [TestMethod]
        public void TestMethod2()
        {
            string metaid_raw = "urn:ssb:classification:klass:123";
            //string expectedLink = "https://www.ssb.no/aku#om-statistikken";
            //string expectedLinkText = "Om statistikken";

            var metaLinkCreator = new MetaLinkManager();
            Assert.IsTrue(metaLinkCreator.LoadConfiguration("metadata.config"));


            //var links = metaLinkCreator.GetTableLinks(metaid_raw, "no");
            //Assert.AreEqual(expectedLink, links[0].Link);
            //Assert.AreEqual(expectedLinkText, links[0].LinkText);

            var varLinks = metaLinkCreator.GetVariableLinks(metaid_raw, "no");
            // returns empty with orginal code. The problem is that "urn:ssb:classification:klass" id the system Id
            // , but : is the parameter separator , so things get confusing :-) 
            Assert.IsTrue(varLinks.Count() > 0, "No link for variable");


        }

    }
}
