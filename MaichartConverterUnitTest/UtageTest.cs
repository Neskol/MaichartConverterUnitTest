using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaiLib;
using static MaiLib.Chart;

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
            Ma2 test = new Ma2("/Users/Neskol/MaiAnalysis/A000/music/music000363/000363_03.ma2");
            Console.WriteLine(new Simai(test).Compose());
            Assert.IsNotNull(test);
        }
    }
}

