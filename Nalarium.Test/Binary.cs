using NUnit.Framework;
using System.Collections.Generic;

namespace Nalarium.Test
{
    [TestFixture]
    public class Binary
    {
        [Test]
        public void Decompose()
        {
            var results = Nalarium.Binary.Decompose(12345);

            var expected = new List<long>(new long[] { 1, 8, 16, 32, 4096, 8192 });

            CollectionAssert.AreEqual(expected, results);
        }
    }
}