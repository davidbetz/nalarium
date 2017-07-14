using NUnit.Framework;

namespace Nalarium.Test.Text
{
    [TestFixture]
    public class Case
    {
        [Test]
        public void GetPascalCase()
        {
            var results = Nalarium.Text.Case.GetPascalCase("TEST");

            Assert.AreEqual("Test", results);
        }

        [Test]
        public void GetCamelCase()
        {
            var results = Nalarium.Text.Case.GetCamelCase("TEST");

            Assert.AreEqual("test", results);
        }
    }
}