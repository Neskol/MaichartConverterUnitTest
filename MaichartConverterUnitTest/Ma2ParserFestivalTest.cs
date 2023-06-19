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
            Ma2 test = new Ma2("/Users/Neskol/MaiAnalysis/A000/music/music011489/011489_03.ma2");
            Simai slideGroupCandidate = new Simai(test);
            // Console.WriteLine("BEFORE: ");
            // Console.WriteLine(slideGroupCandidate.Compose());
            // slideGroupCandidate.ComposeSlideGroup();
            // slideGroupCandidate.ComposeSlideEachGroup();
            slideGroupCandidate.Update();
            // foreach (Note x in slideGroupCandidate.Notes)
            // {
            //     Console.WriteLine("{0}, {1}", x.Compose(1),x.TickTimeStamp);
            // }
            // Console.WriteLine(slideGroupCandidate.Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void FestivalTestTanakaSlideGroup()
        {
            Ma2 test = new Ma2("../../../data/Ma2UtageNSTSlides.ma2");
            Simai slideGroupCandidate = new Simai(test);
            // Console.WriteLine("BEFORE: ");
            // Console.WriteLine(slideGroupCandidate.Compose());
            slideGroupCandidate.ComposeSlideGroup();
            slideGroupCandidate.ComposeSlideEachGroup();
            slideGroupCandidate.Update();
            Console.WriteLine("AFTER: ");
            Console.WriteLine(slideGroupCandidate.Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void FestivalTestTaps()
        {
            Ma2Tokenizer tokenizer = new Ma2Tokenizer();
            Ma2Parser parser = new Ma2Parser();
            Ma2 test = (Ma2)parser.ChartOfToken(tokenizer.Tokens("../../../data/DXFestivalTestMa2.ma2"));
            Console.WriteLine(new Simai(test).Compose());
            Assert.IsNotNull(test);
        }
    }
}