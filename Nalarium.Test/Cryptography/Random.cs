using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nalarium.Test
{
    [TestClass]
    public class Random
    {
        [TestMethod]
        public void Create()
        {
            var first = Nalarium.Cryptography.Random.Create(2);
            var second = Nalarium.Cryptography.Random.Create(2);

            Assert.AreNotEqual(first, 0);

            Assert.AreNotEqual(second, 0);

            Assert.AreNotEqual(first, second);
        }
    }
}
