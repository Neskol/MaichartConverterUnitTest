using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaiLib;
using static MaiLib.NoteEnum;
using static MaiLib.ChartEnum;
using System.IO;

namespace MaichartConverterUnitTest
{
    [TestClass]
    public class UtageTest
    {
        [TestMethod]
        public void UtageTestNotNull()
        {
            Ma2 test = new Ma2("/Users/Neskol/MaiAnalysis/A000-Utage/music/music000363/000363_00.ma2");
            Simai candidate = new Simai(test);
            candidate.ComposeSlideGroup();
            candidate.ComposeSlideEachGroup();
            candidate.Update();
            Console.WriteLine(candidate.Compose());
            foreach (Note x in test.Notes)
            {
                if (x.NoteSpecificGenre is NoteSpecificGenre.SLIDE_START)
                {
                    Console.WriteLine("A Slide Start is present:");
                    Console.WriteLine(x.Compose(ChartVersion.Debug));
                }
            }
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void UtageTestComplicatedOShamaCranky()
        {
            Ma2 test = new Ma2("/Users/Neskol/MaiAnalysis/A000-Utage/music/music000846/000846_00.ma2");
            Console.WriteLine(new Simai(test).Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void UtageTestComplicatedCSTOShamaUtage()
        {
            Ma2 test = new Ma2("/Users/Neskol/MaiAnalysis/A000-Utage/music/music000363/000363_00.ma2");
            // Console.WriteLine(test.Compose());
            Console.WriteLine(new Simai(test).Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void UtageTestComplicatedCSTStarLightDisco()
        {
            Ma2 test = new Ma2("/Users/Neskol/MaiAnalysis/A000-Utage/music/music000145/000145_00.ma2");
            // Console.WriteLine(test.Compose());
            Console.WriteLine(new Simai(test).Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void Ma2GTest()
        {
            Ma2 test = new Ma2("/Users/Neskol/MaiAnalysis/A000/music/music010363/010363_03.ma2");
            Console.WriteLine(new Simai(test).Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void OshamaDXBar6Test()
        {
            Ma2 test = new Ma2("../../../data/OshamaDXBar6.ma2");
            Console.WriteLine(new Simai(test).Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void SimaiGTest()
        {
            Chart test = new Ma2("../../../data/010363_03.ma2");
            Console.WriteLine(new Simai(test).Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void Ma2GTestComplicateReMasPandora()
        {
            Ma2 test = new Ma2("/Users/Neskol/MaiAnalysis/A000/music/music010363/010363_03.ma2");
            Console.WriteLine(new Simai(test).Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void Ma2GUDRotateUSDTest()
        {
            Ma2 test = new Ma2("/Users/Neskol/MaiAnalysis/A000/music/music010363/010363_03.ma2");
            StreamWriter sw = new StreamWriter("../../../data/DX363BeforeRotate.txt", false);
            sw.WriteLine(test.Compose());
            sw.Close();
            test.RotateNotes(FlipMethod.UpSideDown);
            StreamWriter sw2 = new StreamWriter("../../../data/DX363AfterRotate.txt", false);
            sw2.WriteLine(test.Compose());
            sw2.Close();
            Console.WriteLine(new Simai(test).Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void Ma2GUDRotateLTRTest()
        {
            Ma2 test = new Ma2("/Users/Neskol/MaiAnalysis/A000/music/music010363/010363_03.ma2");
            StreamWriter sw = new StreamWriter("../../../data/DX363BeforeRotate.txt", false);
            sw.WriteLine(test.Compose());
            sw.Close();
            test.RotateNotes(FlipMethod.LeftToRight);
            StreamWriter sw2 = new StreamWriter("../../../data/DX363AfterRotate.txt", false);
            sw2.WriteLine(test.Compose());
            sw2.Close();
            Console.WriteLine(new Simai(test).Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void Ma2GOffSet1BarTest()
        {
            Ma2 test = new Ma2("/Users/Neskol/MaiAnalysis/A000/music/music010363/010363_03.ma2");
            StreamWriter sw = new StreamWriter("../../../data/DX363BeforeOffset.txt", false);
            sw.WriteLine(test.Compose());
            sw.Close();
            test.ShiftByOffset(384);
            StreamWriter sw2 = new StreamWriter("../../../data/DX363AfterOffset.txt", false);
            sw2.WriteLine(test.Compose());
            sw2.Close();
            Console.WriteLine(new Simai(test).Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void Ma2GOffSet1Bar96Test()
        {
            Ma2 test = new Ma2("/Users/Neskol/MaiAnalysis/A000/music/music010363/010363_03.ma2");
            StreamWriter sw = new StreamWriter("../../../data/DX363Before1-96Offset.txt", false);
            sw.WriteLine(test.Compose());
            sw.Close();
            test.ShiftByOffset(1, 96);
            StreamWriter sw2 = new StreamWriter("../../../data/DX363After1-96Offset.txt", false);
            sw2.WriteLine(test.Compose());
            sw2.Close();
            Console.WriteLine(new Simai(test).Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void Ma2GOffSetAhead1BarTest()
        {
            Ma2 test = new Ma2("/Users/Neskol/MaiAnalysis/A000/music/music010363/010363_03.ma2");
            StreamWriter sw = new StreamWriter("../../../data/DX363Before1-96Offset.txt", false);
            sw.WriteLine(test.Compose());
            sw.Close();
            test.ShiftByOffset(384);
            StreamWriter sw2 = new StreamWriter("../../../data/DX363After1-96Offset.txt", false);
            sw2.WriteLine(test.Compose());
            sw2.Close();
            Console.WriteLine(new Simai(test).Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void Ma2GOffSetAhead2BarTest()
        {
            Ma2 test = new Ma2("/Users/Neskol/MaiAnalysis/A000/music/music010363/010363_03.ma2");
            StreamWriter sw = new StreamWriter("../../../data/DX363Before1-96Offset.txt", false);
            sw.WriteLine(test.Compose());
            sw.Close();
            test.ShiftByOffset(-768);
            StreamWriter sw2 = new StreamWriter("../../../data/DX363After1-96Offset.txt", false);
            sw2.WriteLine(test.Compose());
            sw2.Close();
            Console.WriteLine(new Simai(test).Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void TestCompareTo()
        {
            Console.WriteLine(32.CompareTo(8 * 4));
            Assert.IsTrue(true);
        }
    }
}

