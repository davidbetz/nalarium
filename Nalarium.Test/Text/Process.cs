using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nalarium.Test.Text
{
    [TestClass]
    public class Process
    {
        [TestMethod]
        public void Max()
        {
            var results = Nalarium.Text.Process.Max("asdfasdfasdasdfasfasdff", 10);

            Assert.AreEqual(results, "asdfasdfas");
        }

        [TestMethod]
        public void MaxWithEllipsis()
        {
            var results = Nalarium.Text.Process.Max("asdfasdfasdasdfasfasdff", 10, true);

            Assert.AreEqual(results, "asdfasd...");
        }

        [TestMethod] 
        public void MaxWithHtmlEllipsis()
        {
            var results = Nalarium.Text.Process.Max("asdfasdfasdasdfasfasdff", 10, true, true);

            Assert.AreEqual(results, "asdfasd&hellip;");
        }
    }
}