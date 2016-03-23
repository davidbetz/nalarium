using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Nalarium.Test
{
    [TestClass]
    public class Base64
    {
        [TestMethod]
        public void To()
        {
            var input = "hello";

            var base64 = Nalarium.Base64.To(input);
            Console.WriteLine(base64);

            var plain = Nalarium.Base64.From(base64);
            Assert.AreEqual(input, plain);
        }

        [TestMethod]
        public void Bad()
        {
            var bad = Nalarium.Base64.From("base64");
            Assert.AreEqual(bad, string.Empty);

        }

        [TestMethod]
        public void Merge()
        {
            var merged = Nalarium.Base64.Merge("hello", "there");
            Console.WriteLine(merged);

            var mergedPlain = Nalarium.Base64.From(merged);

            Assert.AreEqual("hellothere", mergedPlain);
        }

        [TestMethod]
        public void MergedWithSeparator()
        {
            var mergedWithSeparator = Nalarium.Base64.Merge(':', "hello", "there");
            Console.WriteLine(mergedWithSeparator);

            var mergedWithSeparatorPlain = Nalarium.Base64.From(mergedWithSeparator);

            Assert.AreEqual("hello:there", mergedWithSeparatorPlain);
        }
    }
}
