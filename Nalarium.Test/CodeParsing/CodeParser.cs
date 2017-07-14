using NUnit.Framework;

namespace Nalarium.Test
{
    public class AmazonAffiliateCodeParser : Nalarium.CodeParsing.CodeParserTemplate
    {
        public override string Code => "AmazonAffiliate";

        public override string Template => @"<a href=""http://www.amazon.com/gp/product/{ASIN}/{AffiliateCode}"">{Title}</a>";
    }

    public class YouTubeCodeParser : Nalarium.CodeParsing.CodeParserTemplate
    {
        public override string Code => "YouTube";

        public override string Template => @"https://www.youtube.com/watch?v={Code}";
    }

    [TestFixture]
    public class CodeParser
    {
        [Test]
        public void ParseCode_AmazonAffiliate()
        {
            var series = new Nalarium.CodeParsing.CodeParser();
            series.Add(new AmazonAffiliateCodeParser().AddCode("AffiliateCode", "my-amazon-code"));

            var input = "The book you should study is {{AmazonAffiliate:ASIN=B00SLXVBC4;Title=Elasticsearch: The Definitive Guide}}.";

            var results = series.ParseCode(input);

            var expected = @"The book you should study is <a href=""http://www.amazon.com/gp/product/B00SLXVBC4/my-amazon-code"">Elasticsearch: The Definitive Guide</a>.";

            Assert.AreEqual(expected, results);
        }

        [Test]
        public void ParseCode_YouTube()
        {
            var series = new Nalarium.CodeParsing.CodeParser();
            series.Add(new YouTubeCodeParser());

            var input = "The book is {{YouTube:Code=XC2RYiaM6WU}}.";

            var results = series.ParseCode(input);

            var expected = "The book is https://www.youtube.com/watch?v=XC2RYiaM6WU.";

            Assert.AreEqual(expected, results);
        }
    }
}