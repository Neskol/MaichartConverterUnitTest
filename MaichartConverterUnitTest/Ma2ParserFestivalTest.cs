using System;
using MaiLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaichartConverterUnitTest
{
    [TestClass]
    public class Ma2ParserFestivalTest
    {
        [TestMethod]
        public void FestivalTestTanaka()
        {
            Ma2 test = new Ma2("/Users/Neskol/MaiAnalysis/A000-1.30Candidate/music/music011489/011489_03.ma2");
            Console.WriteLine(new Simai(test).Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void FestivalTestTaps()
        {
            Ma2Tokenizer tokenizer = new Ma2Tokenizer();
            Ma2Parser parser = new Ma2Parser();
            Ma2 test = (Ma2)parser.ChartOfToken(tokenizer.Tokens("../../../data/DXFestivalTestMa2.txt"));
            Console.WriteLine(new Simai(test).Compose());
            Assert.IsNotNull(test);
        }
    }
}