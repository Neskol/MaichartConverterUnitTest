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
    }
}