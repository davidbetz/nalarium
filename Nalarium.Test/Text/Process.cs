using NUnit.Framework;

namespace Nalarium.Test.Text
{
    [TestFixture]
    public class Process
    {
        [Test]
        public void Max()
        {
            var results = Nalarium.Text.Process.Max("asdfasdfasdasdfasfasdff", 10);

            Assert.AreEqual(results, "asdfasdfas");
        }

        [Test]
        public void MaxWithEllipsis()
        {
            var results = Nalarium.Text.Process.Max("asdfasdfasdasdfasfasdff", 10, true);

            Assert.AreEqual(results, "asdfasd...");
        }

        [Test] 
        public void MaxWithHtmlEllipsis()
        {
            var results = Nalarium.Text.Process.Max("asdfasdfasdasdfasfasdff", 10, true, true);

            Assert.AreEqual(results, "asdfasd&hellip;");
        }
    }
}