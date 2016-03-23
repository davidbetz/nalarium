using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace Nalarium.Test
{
    [TestClass]
    public class Path
    {
        [TestMethod]
        public void Clean()
        {
            var expected = @"E:\some\series\of\folders\content";
            var folder = expected + @"\";
            var result = Nalarium.Path.Clean(folder);

            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Join()
        {
            var first = @"E:\some\series";
            var second = @"of\folders\content";

            var result = Nalarium.Path.Join(first, second);

            Assert.AreEqual(result, first + "\\" + second);
        }
    }
}
