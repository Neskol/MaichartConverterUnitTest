using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaichartConverter;
using static MaichartConverter.SimaiParser;
using System.Collections.Generic;

namespace MaichartConverterUnitTest
{
    [TestClass]
    public class SimaiParserTest
    {
        [TestMethod]
        public void TestHoldOfChartWithBar0Tick0HLD()
        {
            string holdToken = "3[4:1]";
            SimaiParser parser = new SimaiParser();
            Hold x = parser.HoldOfToken(holdToken, 0, 0, 120);
            string expectedKey = "2";
            string expectedType = "HLD";
            int expectedBar = 0;
            int expectedTick = 0;
            int expectedLastLength = 96;
            double expectedBPM = 120.0;
            Assert.AreEqual(expectedKey, x.Key, "Key does not match!");
            Assert.AreEqual(expectedType, x.NoteType, "Hold Type does not match!");
            Assert.AreEqual(expectedBar, x.Bar, "Bar does not match!");
            Assert.AreEqual(expectedTick, x.Tick, "Tick does not match!");
            Assert.AreEqual(expectedLastLength, x.LastLength, "Last Length does not match!");
            Assert.AreEqual(expectedBPM, x.BPM, "BPM does not match!");
        }

        [TestMethod]
        public void TestHoldOfChartWithBar0Tick0XHD()
        {
            string holdToken = "3x[4:1]";
            SimaiParser parser = new SimaiParser();
            Hold x = parser.HoldOfToken(holdToken, 0, 0, 120);
            string expectedKey = "2";
            string expectedType = "XHO";
            int expectedBar = 0;
            int expectedTick = 0;
            int expectedLastLength = 96;
            double expectedBPM = 120.0;
            Assert.AreEqual(expectedKey, x.Key, "Key does not match!");
            Assert.AreEqual(expectedType, x.NoteType, "Hold Type does not match!");
            Assert.AreEqual(expectedBar, x.Bar, "Bar does not match!");
            Assert.AreEqual(expectedTick, x.Tick, "Tick does not match!");
            Assert.AreEqual(expectedLastLength, x.LastLength, "Last Length does not match!");
            Assert.AreEqual(expectedBPM, x.BPM, "BPM does not match!");
        }

        [TestMethod]
        public void TestHoldOfChartWithBar0Tick0THO()
        {
            string holdToken = "C1[4:1]";
            SimaiParser parser = new SimaiParser();
            Hold x = parser.HoldOfToken(holdToken, 0, 0, 120);
            string expectedKey = "0C";
            string expectedType = "THO";
            int expectedBar = 0;
            int expectedTick = 0;
            int expectedLastLength = 96;
            double expectedBPM = 120.0;
            Assert.AreEqual(expectedKey, x.Key, "Key does not match!");
            Assert.AreEqual(expectedType, x.NoteType, "Hold Type does not match!");
            Assert.AreEqual(expectedBar, x.Bar, "Bar does not match!");
            Assert.AreEqual(expectedTick, x.Tick, "Tick does not match!");
            Assert.AreEqual(expectedLastLength, x.LastLength, "Last Length does not match!");
            Assert.AreEqual(expectedBPM, x.BPM, "BPM does not match!");
        }

        //[TestMethod]
        //public void TestExtractEachSlides()
        //{
        //    string token = "1-3[2:1]";
        //    List<string> expected = new() { "1_", "-3[2:1]" };
        //    List<string> actual = ExtractEachSlides(token);
        //    Assert.AreEqual(expected, actual);
        //}
    }
}

