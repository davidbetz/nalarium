using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace Nalarium.Test
{
    [TestClass]
    public class Url
    {
        [TestMethod]
        public void Join()
        {
            var expected = "path/to/item";
            var path = @"path";
            var to = @"to";
            var item = @"item";

            var result = Nalarium.Url.Join(path, to, item);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CleanTail()
        {
            var expected = "/path/with/useless/ending";
            var input = @"/path/with/useless/ending/";

            var result = Nalarium.Url.CleanTail(input);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FromPath()
        {
            var expected = "myfolder";
            var baseFolder = @"E:\Some\Series\Of\Folders\content";
            var folder = @"E:\some\series\of\folders\content\" + expected;
            var result = Nalarium.Url.FromPath(Nalarium.Path.Clean(folder.Substring(baseFolder.Length, folder.Length - baseFolder.Length)).ToLower(CultureInfo.InvariantCulture));
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetParent()
        {
            var expected = "path/to/something/deep/with/lame";
            var input = "/path/to/something/deep/with/lame/ending/";
            var result = Nalarium.Url.GetParent(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetParent_Single()
        {
            var expected = "";
            var input = "path";
            var result = Nalarium.Url.GetParent(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetParent_AlreadyRoot()
        {
            var expected = "";
            var input = "";
            var result = Nalarium.Url.GetParent(input);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetUrlPartArray()
        {
            var result = Nalarium.Url.GetUrlPartArray(string.Empty);
            CollectionAssert.AreEquivalent(result, new string[] { });
        }
    }
}
