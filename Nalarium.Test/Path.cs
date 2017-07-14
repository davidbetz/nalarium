using NUnit.Framework;
using System;
using System.Globalization;

namespace Nalarium.Test
{
    [TestFixture]
    public class Path
    {
        [Test]
        public void Clean()
        {
            var expected = @"E:\some\series\of\folders\content";
            var folder = expected + @"\";
            var result = Nalarium.Path.Clean(folder);

            Assert.AreEqual(result, expected);
        }

        [Test]
        public void Join()
        {
            var first = @"E:\some\series";
            var second = @"of\folders\content";

            var result = Nalarium.Path.Join(first, second);

            Assert.AreEqual(result, first + "\\" + second);
        }
    }
}
