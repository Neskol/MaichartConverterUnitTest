using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaiLib;
using static MaiLib.Chart;
using System.IO;

namespace MaichartConverterUnitTest
{
    [TestClass]
    public class Ma2Test
    {
        [TestMethod]
        public void UtageTest()
        {
            Ma2 test = new Ma2("/Users/Neskol/MaiAnalysis/A000-Utage/music/music000363/000363_00.ma2");
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
        public void Ma2GUDRotateTest()
        {
            Ma2 test = new Ma2("/Users/Neskol/MaiAnalysis/A000/music/music010363/010363_03.ma2");
            StreamWriter sw = new StreamWriter("../../../data/DX363BeforeRotate.txt", false);
            sw.WriteLine(test.Compose());
            sw.Close();
            test.RotateNotes("UpSideDown");
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
            test.ShiftByOffset(1,96);
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
            test.ShiftByOffset(-384);
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
    }
}

