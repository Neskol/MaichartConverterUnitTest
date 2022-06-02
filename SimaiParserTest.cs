using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaichartConverter;
using static MaichartConverter.SimaiParser;
using System.Collections.Generic;
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
            Assert.AreEqual(expected.Count,actual.Count);
            for (int i = 0;i<expected.Count;i++)
            {
                Assert.AreEqual(expected[i],actual[i]);
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

        //Test EachGroupOfToken
        [TestMethod]
        public void EachGroupOfTokenBasicTest()
        {
            string token = "1";
            List<string> expected = new() { token };
            List<string> actual = EachGroupOfToken(token);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void EachGroupOfTokenSlideBasicTest()
        {
            string token = "1-3[2:1]";
            List<string> expected = new() { "1_","-3[2:1]" };
            List<string> actual = EachGroupOfToken(token);
            for (int i = 0; i < actual.Count; i++)
            {
                Console.WriteLine(actual[i]);
            }
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void EachGroupOfTokenBPMBasicTest()
        {
            string token = "(240)";
            List<string> expected = new() { token };
            List<string> actual = EachGroupOfToken(token);
            for (int i = 0; i < actual.Count; i++)
            {
                Console.WriteLine(actual[i]);
            }
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void EachGroupOfTokenMeasureBasicTest()
        {
            string token = "{4}";
            List<string> expected = new() { token };
            List<string> actual = EachGroupOfToken(token);
            for (int i = 0; i < actual.Count; i++)
            {
                Console.WriteLine(actual[i]);
            }
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void EachGroupOfTokenTapEachTest()
        {
            string token = "1/2";
            List<string> expected = new() { "1","2"};
            List<string> actual = EachGroupOfToken(token);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void EachGroupOfTokenTapEach3Test()
        {
            string token = "1/2/3";
            List<string> expected = new() { "1", "2","3" };
            List<string> actual = EachGroupOfToken(token);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void EachGroupOfTokenTapEachWithoutSlashTest()
        {
            string token = "12";
            List<string> expected = new() { "1", "2" };
            List<string> actual = EachGroupOfToken(token);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void EachGroupOfTokenTapHoldEachTest()
        {
            string token = "1/2h[1:2]";
            List<string> expected = new() { "1", "2h[1:2]" };
            List<string> actual = EachGroupOfToken(token);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void EachGroupOfTokenBPMTapEachTest()
        {
            string token = "(120)1";
            List<string> expected = new() { "(120)", "1" };
            List<string> actual = EachGroupOfToken(token);
            for (int i = 0; i < actual.Count; i++)
            {
                Console.WriteLine(actual[i]);
            }
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void EachGroupOfTokenMeasureTapEachTest()
        {
            string token = "{4}1";
            List<string> expected = new() { "{4}", "1" };
            List<string> actual = EachGroupOfToken(token);
            for (int i = 0; i < actual.Count; i++)
            {
                Console.WriteLine(actual[i]);
            }
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void EachGroupOfTokenBPMMeasureTapEachTest()
        {
            string token = "(120){4}1";
            List<string> expected = new() { "(120)","{4}", "1" };
            List<string> actual = EachGroupOfToken(token);
            for (int i = 0; i < actual.Count; i++)
            {
                Console.WriteLine(actual[i]);
            }
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }


        [TestMethod]
        public void EachGroupOfTokenTapSlideEachTest()
        {
            string token = "1/2-3[1:2]";
            List<string> expected = new() { "1", "2_","-3[1:2]" };
            List<string> actual = EachGroupOfToken(token);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void EachGroupOfTokenTap3SlideEachTest()
        {
            string token = "1/2-3[1:2]*v4[1:2]*qq5[1:2]";
            List<string> expected = new() { "1", "2_", "-3[1:2]","v4[1:2]","qq5[1:2]" };
            List<string> actual = EachGroupOfToken(token);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void EachGroupOfTokenMixedEachTest()
        {
            string token = "(120){4}1/2-3[1:2]*v4[1:2]*qq5[1:2]/3h[1:2]/4b/5x/C1f";
            List<string> expected = new() {"(120)","{4}", "1", "2_", "-3[1:2]", "v4[1:2]", "qq5[1:2]","3h[1:2]","4b","5x","C1f" };
            List<string> actual = EachGroupOfToken(token);
            for (int i = 0; i < actual.Count; i++)
            {
                Console.WriteLine(actual[i]);
            }
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
            SimaiParser parser = new SimaiParser();
            string[] tokensCandidates = tokenizer.Tokens(@"D:\SimaiCandidate.txt");
            List<string> tokensList = new();
            List<string> tokensSecondTry = new();
            foreach (string x in tokensCandidates)
            {
                tokensList.AddRange(SimaiParser.EachGroupOfToken(x));
            }
            foreach (string y in tokensList)
            {
                tokensSecondTry.AddRange(SimaiParser.EachGroupOfToken(y));
            }
            string[] tokens = tokensSecondTry.ToArray();
            foreach (string x in tokens)
            {
                Console.WriteLine(x);
            }
            //Assert.Fail();
            Chart candidate = parser.ChartOfToken(tokens);
            MaidataCompiler compiler = new MaidataCompiler();
            Console.WriteLine(compiler.Compose(candidate));
            Assert.IsTrue(true);
        }
    }
}

