using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nalarium.Test.Text
{
    [TestClass]
    public class Case
    {
        [TestMethod]
        public void GetPascalCase()
        {
            var results = Nalarium.Text.Case.GetPascalCase("TEST");

            Assert.AreEqual("Test", results);
        }

        [TestMethod]
        public void GetCamelCase()
        {
            var results = Nalarium.Text.Case.GetCamelCase("TEST");

            Assert.AreEqual("test", results);
        }
    }
}