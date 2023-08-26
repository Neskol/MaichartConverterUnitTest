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
            Ma2 test = new Ma2("../../../data/011489_03.ma2");
            Simai slideGroupCandidate = new Simai(test);
            // Console.WriteLine("BEFORE: ");
            // Console.WriteLine(slideGroupCandidate.Compose());
            // slideGroupCandidate.ComposeSlideGroup();
            // slideGroupCandidate.ComposeSlideEachGroup();
            slideGroupCandidate.Update();
            Console.WriteLine(slideGroupCandidate.Compose());
            // foreach (Note x in slideGroupCandidate.Notes)
            // {
            //     Console.WriteLine("{0}, {1}", x.Compose(1),x.TimeStamp);
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
        public void FestivalTest411()
        {
            Ma2 test = new Ma2("../../../data/011469_02.ma2");
            Simai slideGroupCandidate = new Simai(test);
            Console.WriteLine(test.Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void FestivalTest411SlideGroup()
        {
            Ma2 test = new Ma2("../../../data/DXFestivalUnsyncedGroup.txt");
            Simai slideGroupCandidate = new Simai(test);
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