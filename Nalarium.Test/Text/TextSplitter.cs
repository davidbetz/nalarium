using NUnit.Framework;
using System.Collections.Generic;

namespace Nalarium.Test.Text
{
    [TestFixture]
    public class TextSplitter
    {
        [Test]
        public void Split()
        {
            var results = Nalarium.Text.TextSplitter.Split(@"""asdf"",""qwerq,wer""", ',');

            CollectionAssert.AreEqual(results, new List<string>(new[] { "asdf", "qwerq,wer" }));
        }
    }
}