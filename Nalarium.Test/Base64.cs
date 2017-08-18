using NUnit.Framework;
using System;

namespace Nalarium.Test
{
    [TestFixture]
    public class Base64
    {
        [Test]
        public void To()
        {
            var input = "hello";

            var base64 = Nalarium.Base64.To(input);

            var plain = Nalarium.Base64.From(base64);
            Assert.AreEqual(input, plain);
        }

        [Test]
        public void Bad()
        {
            var bad = Nalarium.Base64.From("base64");
            Assert.AreEqual(bad, string.Empty);

        }

        [Test]
        public void Merge()
        {
            var merged = Nalarium.Base64.Merge("hello", "there");

            var mergedPlain = Nalarium.Base64.From(merged);

            Assert.AreEqual("hellothere", mergedPlain);
        }

        [Test]
        public void MergedWithSeparator()
        {
            var mergedWithSeparator = Nalarium.Base64.Merge(':', "hello", "there");

            var mergedWithSeparatorPlain = Nalarium.Base64.From(mergedWithSeparator);

            Assert.AreEqual("hello:there", mergedWithSeparatorPlain);
        }
    }
}
