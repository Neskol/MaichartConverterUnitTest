using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaiLib;
using static MaiLib.SimaiParser;
using System.Collections.Generic;
using System.IO;
using System;

namespace MaichartConverterUnitTest
{
    [TestClass]
    public class SimaiParserTest
    {
        [TestMethod]
        public void HoldOfTokenWithBar0Tick0HLDTest()
        {
            string holdToken = "3h[4:1]";
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
        public void HoldOfTokenWithBar0Tick0XHDTest()
        {
            string holdToken = "3xh[4:1]";
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
        public void HoldOfTokenWithBar0Tick0THOTest()
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

        //Test SlideOfToken
        [TestMethod]
        public void SlideOfTokenWithBar0Tick0SI_Test()
        {
            string slideToken = "-3[4:1]";
            Tap previousSlideStart = new Tap("STR", 0, 0, "0");
            SimaiParser parser = new SimaiParser();
            Slide x = parser.SlideOfToken(slideToken, 0, 0, previousSlideStart, 120.0);
            string expectedKey = "0";
            string expectedEndKey = "2";
            string expectedType = "SI_";
            int expectedBar = 0;
            int expectedTick = 0;
            int expectedWaitLength = 96;
            int expectedLastLength = 96;
            double expectedBPM = 120.0;
            Assert.AreEqual(expectedKey, x.Key, "Key does not match!");
            Assert.AreEqual(expectedEndKey, x.EndKey, "End Key does not match!");
            Assert.AreEqual(expectedType, x.NoteType, "Slide Type does not match!");
            Assert.AreEqual(expectedBar, x.Bar, "Bar does not match!");
            Assert.AreEqual(expectedTick, x.Tick, "Tick does not match!");
            Assert.AreEqual(expectedWaitLength, x.WaitLength, "Wait Length does not match!");
            Assert.AreEqual(expectedLastLength, x.LastLength, "Last Length does not match!");
            Assert.AreEqual(expectedBPM, x.BPM, "BPM does not match!");
        }

        [TestMethod]
        public void SlideOfTokenWithBar0Tick0SI_TestUsingSeconds()
        {
            string slideToken = "-3[0.5##0.5]";
            Tap previousSlideStart = new Tap("STR", 0, 0, "0");
            SimaiParser parser = new SimaiParser();
            Slide x = parser.SlideOfToken(slideToken, 0, 0, previousSlideStart, 120.0);
            string expectedKey = "0";
            string expectedEndKey = "2";
            string expectedType = "SI_";
            int expectedBar = 0;
            int expectedTick = 0;
            int expectedWaitLength = 96;
            int expectedLastLength = 96;
            double expectedBPM = 120.0;
            Assert.AreEqual(expectedKey, x.Key, "Key does not match!");
            Assert.AreEqual(expectedEndKey, x.EndKey, "End Key does not match!");
            Assert.AreEqual(expectedType, x.NoteType, "Slide Type does not match!");
            Assert.AreEqual(expectedBar, x.Bar, "Bar does not match!");
            Assert.AreEqual(expectedTick, x.Tick, "Tick does not match!");
            Assert.AreEqual(expectedWaitLength, x.WaitLength, "Wait Length does not match!");
            Assert.AreEqual(expectedLastLength, x.LastLength, "Last Length does not match!");
            Assert.AreEqual(expectedBPM, x.BPM, "BPM does not match!");
        }

        [TestMethod]
        public void SlideOfTokenWithBar1Tick96SF_Test()
        {
            string slideToken = "w3[4:1]";
            Tap previousSlideStart = new Tap("STR", 1, 96, "0");
            SimaiParser parser = new SimaiParser();
            Slide x = parser.SlideOfToken(slideToken, 1, 96, previousSlideStart, 120.0);
            string expectedKey = "0";
            string expectedEndKey = "2";
            string expectedType = "SF_";
            int expectedBar = 1;
            int expectedTick = 96;
            int expectedWaitLength = 96;
            int expectedLastLength = 96;
            double expectedBPM = 120.0;
            Assert.AreEqual(expectedKey, x.Key, "Key does not match!");
            Assert.AreEqual(expectedEndKey, x.EndKey, "End Key does not match!");
            Assert.AreEqual(expectedType, x.NoteType, "Slide Type does not match!");
            Assert.AreEqual(expectedBar, x.Bar, "Bar does not match!");
            Assert.AreEqual(expectedTick, x.Tick, "Tick does not match!");
            Assert.AreEqual(expectedWaitLength, x.WaitLength, "Wait Length does not match!");
            Assert.AreEqual(expectedLastLength, x.LastLength, "Last Length does not match!");
            Assert.AreEqual(expectedBPM, x.BPM, "BPM does not match!");
        }

        [TestMethod]
        public void SlideOfTokenWithBar1Tick96SLLTest()
        {
            string slideToken = "V35[4:1]";
            Tap previousSlideStart = new Tap("BRK", 1, 96, "0");
            SimaiParser parser = new SimaiParser();
            Slide x = parser.SlideOfToken(slideToken, 1, 96, previousSlideStart, 120.0);
            string expectedKey = "0";
            string expectedEndKey = "4";
            string expectedType = "SLL";
            int expectedBar = 1;
            int expectedTick = 96;
            int expectedWaitLength = 96;
            int expectedLastLength = 96;
            double expectedBPM = 120.0;
            Assert.AreEqual(expectedKey, x.Key, "Key does not match!");
            Assert.AreEqual(expectedEndKey, x.EndKey, "End Key does not match!");
            Assert.AreEqual(expectedType, x.NoteType, "Slide Type does not match!");
            Assert.AreEqual(expectedBar, x.Bar, "Bar does not match!");
            Assert.AreEqual(expectedTick, x.Tick, "Tick does not match!");
            Assert.AreEqual(expectedWaitLength, x.WaitLength, "Wait Length does not match!");
            Assert.AreEqual(expectedLastLength, x.LastLength, "Last Length does not match!");
            Assert.AreEqual(expectedBPM, x.BPM, "BPM does not match!");
        }

        [TestMethod]
        public void SlideOfTokenWithRealSLLTest()
        {
            string slideToken = "V37[4:1]";
            Tap previousSlideStart = new Tap("BRK", 1, 96, "0");
            SimaiParser parser = new SimaiParser();
            Slide x = parser.SlideOfToken(slideToken, 1, 96, previousSlideStart, 120.0);
            string expectedKey = "0";
            string expectedEndKey = "6";
            string expectedType = "SLL";
            int expectedBar = 1;
            int expectedTick = 96;
            int expectedWaitLength = 96;
            int expectedLastLength = 96;
            double expectedBPM = 120.0;
            Assert.AreEqual(expectedKey, x.Key, "Key does not match!");
            Assert.AreEqual(expectedEndKey, x.EndKey, "End Key does not match!");
            Assert.AreEqual(expectedType, x.NoteType, "Slide Type does not match!");
            Assert.AreEqual(expectedBar, x.Bar, "Bar does not match!");
            Assert.AreEqual(expectedTick, x.Tick, "Tick does not match!");
            Assert.AreEqual(expectedWaitLength, x.WaitLength, "Wait Length does not match!");
            Assert.AreEqual(expectedLastLength, x.LastLength, "Last Length does not match!");
            Assert.AreEqual(expectedBPM, x.BPM, "BPM does not match!");
        }

        [TestMethod]
        public void SlideOfTokenWithBar1Tick96SLRTest()
        {
            string slideToken = "V75[4:1]";
            Tap previousSlideStart = new Tap("BRK", 1, 96, "0");
            SimaiParser parser = new SimaiParser();
            Slide x = parser.SlideOfToken(slideToken, 1, 96, previousSlideStart, 120.0);
            string expectedKey = "0";
            string expectedEndKey = "4";
            string expectedType = "SLR";
            int expectedBar = 1;
            int expectedTick = 96;
            int expectedWaitLength = 96;
            int expectedLastLength = 96;
            double expectedBPM = 120.0;
            Assert.AreEqual(expectedKey, x.Key, "Key does not match!");
            Assert.AreEqual(expectedEndKey, x.EndKey, "End Key does not match!");
            Assert.AreEqual(expectedType, x.NoteType, "Slide Type does not match!");
            Assert.AreEqual(expectedBar, x.Bar, "Bar does not match!");
            Assert.AreEqual(expectedTick, x.Tick, "Tick does not match!");
            Assert.AreEqual(expectedWaitLength, x.WaitLength, "Wait Length does not match!");
            Assert.AreEqual(expectedLastLength, x.LastLength, "Last Length does not match!");
            Assert.AreEqual(expectedBPM, x.BPM, "BPM does not match!");
        }

        [TestMethod]
        public void ExtractEachSlides2SectionTest()
        {
            string token = "1-3[2:1]";
            List<string> expected = new() { "1_", "-3[2:1]" };
            List<string> actual = ExtractEachSlides(token);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
        [TestMethod]
        public void ExtractEachSlides2SectionWithBSTTest()
        {
            string token = "1b-3[2:1]";
            List<string> expected = new() { "1b_", "-3[2:1]" };
            List<string> actual = ExtractEachSlides(token);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void ExtractEachSlides2SectionWithXSTTest()
        {
            string token = "1x-3[2:1]";
            List<string> expected = new() { "1x_", "-3[2:1]" };
            List<string> actual = ExtractEachSlides(token);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void ExtractEachSlides5SectionTest()
        {
            string token = "1-3[2:1]*-5[2:1]*v4[2:1]";
            List<string> expected = new() { "1_", "-3[2:1]", "-5[2:1]", "v4[2:1]" };
            List<string> actual = ExtractEachSlides(token);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void ExtractEachSlides2SectionQAndQQTest()
        {
            string token = "1-3[2:1]*q5[2:1]*qq4[2:1]";
            List<string> expected = new() { "1_", "-3[2:1]", "q5[2:1]", "qq4[2:1]" };
            List<string> actual = ExtractEachSlides(token);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void ComprehensiveTest()
        {
            SimaiTokenizer tokenizer = new SimaiTokenizer();
            tokenizer.UpdateFromPath(@"../../../data/maidata.txt");
            SimaiParser parser = new SimaiParser();
            string[] tokensCandidates = tokenizer.ChartCandidates["6"];     
            Chart candidate = parser.ChartOfToken(tokensCandidates);
            SimaiCompiler compiler = new SimaiCompiler();
            Ma2 toMa2 = new Ma2(candidate);
            Console.WriteLine(toMa2.Compose());
        }

        //[TestMethod]
        //public void EachNoteOfToken1()
        //{
        //    Assert.IsTrue(true);
        //}
    }
}

