using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Nalarium.Test.Text
{
    [TestClass]
    public class TextSplitter
    {
        [TestMethod]
        public void Split()
        {
            var results = Nalarium.Text.TextSplitter.Split(@"""asdf"",""qwerq,wer""", ',');

            CollectionAssert.AreEqual(results, new List<string>(new[] { "asdf", "qwerq,wer" }));
        }
    }
}