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
            Ma2 test = new Ma2("../../../data/011489_03.ma2") { ChartVersion = ChartEnum.ChartVersion.Ma2_104 };
            Simai slideGroupCandidate = new Simai(test);
            slideGroupCandidate.Update();
            Console.WriteLine(test.Compose());
            Console.WriteLine(slideGroupCandidate.Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void FestivalTestTanakaBar36()
        {
            Ma2 test = new Ma2("../../../data/TanakaBar36.ma2");
            Simai slideGroupCandidate = new Simai(test);
            slideGroupCandidate.Update();
            Console.WriteLine(test.Compose());
            Console.WriteLine(slideGroupCandidate.Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void FestivalTestInternetOverdose()
        {
            Ma2 test = new Ma2("../../../data/011568_03.ma2");
            Simai slideGroupCandidate = new Simai(test);
            slideGroupCandidate.Update();
            slideGroupCandidate.ChartVersion = ChartEnum.ChartVersion.SimaiFes;
            // Console.WriteLine(test.Compose());
            Console.WriteLine(slideGroupCandidate.Compose(ChartEnum.ChartVersion.Simai));
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void FestivalTestJingleBell()
        {
            Ma2 test = new Ma2("../../../data/010070_03.ma2");
            Simai slideGroupCandidate = new Simai(test);
            slideGroupCandidate.Update();
            slideGroupCandidate.ChartVersion = ChartEnum.ChartVersion.SimaiFes;
            // Console.WriteLine(test.Compose());
            Console.WriteLine(slideGroupCandidate.Compose());
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

        [TestMethod]
        public void Ma2Ver103Tanaka()
        {
            Ma2 test = new Ma2("../../../data/011568_03.ma2");
            Console.WriteLine(test.Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void Ma2Ver104Tanaka()
        {
            Ma2 test = new Ma2("../../../data/011568_03.ma2");
            Console.WriteLine(test.Compose(ChartEnum.ChartVersion.Ma2_104));
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void Ma2ZundamonHold()
        {
            Ma2 test = new Ma2("../../../data/ZundamonHoldTest.ma2");
            Console.WriteLine(test.Compose(ChartEnum.ChartVersion.SimaiFes));
            Assert.IsNotNull(test);
        }
    }
}