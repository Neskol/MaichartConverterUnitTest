using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaiLib;
using static MaiLib.SimaiParser;
using static MaiLib.NoteEnum;
using System.Collections.Generic;
using System;

namespace MaichartConverterUnitTest
{
    [TestClass]
    public class SimaiParserTest
    {
        private static bool IsEquivalentArray(double[] expected, double[] actual)
        {
            if (expected.Length != actual.Length) return false;
            for (int i = 0; i < expected.Length; i++)
            {
                if (Math.Abs(expected[i] - actual[i]) > 0.001)
                {
                    Console.WriteLine("ELEMENT MISMATCH AT INDEX {0}:\nEXPECT: {1}\nACTUAL: {2}", i, expected[i], actual[i]);
                    Console.ReadKey();
                    return false;
                }
            }
            return true;
        }

        [TestMethod]
        public void HoldOfTokenWithBar0Tick0HLDTest()
        {
            string holdToken = "3h[4:1]";
            SimaiParser parser = new SimaiParser();
            Hold x = parser.HoldOfToken(holdToken, 0, 0, 120);
            x.BPMChangeNotes.Add(new BPMChange(0, 0, 120));
            x.Update();
            string expectedKey = "2";
            NoteType expectedType = NoteType.HLD;
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
            x.BPMChangeNotes.Add(new BPMChange(0, 0, 120));
            x.Update();
            string expectedKey = "2";
            NoteType expectedType = NoteType.HLD;
            SpecialState expectedSpecialState = SpecialState.EX;
            int expectedBar = 0;
            int expectedTick = 0;
            int expectedLastLength = 96;
            double expectedBPM = 120.0;
            Assert.AreEqual(expectedKey, x.Key, "Key does not match!");
            Assert.AreEqual(expectedType, x.NoteType, "Hold Type does not match!");
            Assert.AreEqual(expectedSpecialState, x.NoteSpecialState, "Hold State does not match!");
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
            x.BPMChangeNotes.Add(new BPMChange(0, 0, 120));
            x.Update();
            string expectedKey = "0C";
            NoteType expectedType = NoteType.THO;
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
            Tap previousSlideStart = new Tap(NoteType.STR, 0, 0, "0");
            SimaiParser parser = new SimaiParser();
            Slide x = parser.SlideOfToken(slideToken, 0, 0, previousSlideStart, 120.0);
            x.Update();
            string expectedKey = "0";
            string expectedEndKey = "2";
            NoteType expectedType = NoteType.SI_;
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
            Tap previousSlideStart = new Tap(NoteType.STR, 0, 0, "0");
            SimaiParser parser = new SimaiParser();
            Slide x = parser.SlideOfToken(slideToken, 0, 0, previousSlideStart, 120.0);
            x.BPMChangeNotes.Add(new BPMChange(0, 0, 120));
            x.Update();
            string expectedKey = "0";
            string expectedEndKey = "2";
            NoteType expectedType = NoteType.SI_;
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
            Tap previousSlideStart = new Tap(NoteType.STR, 1, 96, "0");
            SimaiParser parser = new SimaiParser();
            Slide x = parser.SlideOfToken(slideToken, 1, 96, previousSlideStart, 120.0);
            x.Update();
            string expectedKey = "0";
            string expectedEndKey = "2";
            NoteType expectedType = NoteType.SF_;
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
            Tap previousSlideStart = new Tap(NoteType.TAP, 1, 96, "0");
            previousSlideStart.NoteSpecialState = SpecialState.Break;
            SimaiParser parser = new SimaiParser();
            Slide x = parser.SlideOfToken(slideToken, 1, 96, previousSlideStart, 120.0);
            x.Update();
            string expectedKey = "0";
            string expectedEndKey = "4";
            NoteType expectedType = NoteType.SLR;
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
            Tap previousSlideStart = new Tap(NoteType.TAP, 1, 96, "0");
            previousSlideStart.NoteSpecialState = SpecialState.Break;
            SimaiParser parser = new SimaiParser();
            Slide x = parser.SlideOfToken(slideToken, 1, 96, previousSlideStart, 120.0);
            x.Update();
            string expectedKey = "0";
            string expectedEndKey = "6";
            NoteType expectedType = NoteType.SLR;
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
            Tap previousSlideStart = new Tap(NoteType.TAP, 1, 96, "0");
            previousSlideStart.NoteSpecialState = SpecialState.Break;
            SimaiParser parser = new SimaiParser();
            Slide x = parser.SlideOfToken(slideToken, 1, 96, previousSlideStart, 120.0);
            x.Update();
            string expectedKey = "0";
            string expectedEndKey = "4";
            NoteType expectedType = NoteType.SLL;
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
        public void ExtractSlideHead()
        {
            string token = "4qq8[24:5]pp6[0##0.2151]pp7[0##0.2151]*pp8[24:5]qq2[0##0.2151]";
            List<string> expected = new() { "4_", "qq8[24:5]pp6[0##0.2151]pp7[0##0.2151]", "pp8[24:5]qq2[0##0.2151]" };
            List<string> actual = ExtractEachSlides(token);
            Assert.AreEqual(expected.Count, actual.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void ParseConnectingEachSlides()
        {
            string token = "(120){1}4b>8[64:35]v2[0##0.4536]v4[0##0.4536]*<8[64:35]v6[0##0.4536]v4[0##0.4536],E";
            SimaiTokenizer tokenizer = new SimaiTokenizer();
            SimaiParser parser = new SimaiParser();
            Chart test = new Ma2(parser.ChartOfToken(tokenizer.TokensFromText(token)));
            test.ChartVersion = ChartEnum.ChartVersion.Ma2_104;
            Console.WriteLine(test.Compose());
            Console.WriteLine(parser.ChartOfToken(tokenizer.TokensFromText(token)).Compose());
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void ComprehensiveTest()
        {
            SimaiTokenizer tokenizer = new SimaiTokenizer();
            tokenizer.UpdateFromPath(@"../../../data/maidata_pandora.txt");
            SimaiParser parser = new SimaiParser();
            string[] tokensCandidates = tokenizer.ChartCandidates["6"];
            Chart candidate = parser.ChartOfToken(tokensCandidates);
            SimaiCompiler compiler = new SimaiCompiler();
            Ma2 toMa2 = new Ma2(candidate);
            Console.WriteLine(toMa2.Compose());
        }

        [TestMethod]
        public void ComprehensiveTestUma()
        {
            SimaiTokenizer tokenizer = new SimaiTokenizer();
            tokenizer.UpdateFromPath(@"../../../data/maidata_uma.txt");
            SimaiParser parser = new SimaiParser();
            string[] tokensCandidates = tokenizer.ChartCandidates["6"];
            Chart candidate = parser.ChartOfToken(tokensCandidates);
            SimaiCompiler compiler = new SimaiCompiler();
            Ma2 toMa2 = new Ma2(candidate);
            Console.WriteLine(new Simai(toMa2).Compose());
        }

        [TestMethod]
        public void ComprehensiveTestInternetOverdose()
        {
            SimaiTokenizer tokenizer = new SimaiTokenizer();
            tokenizer.UpdateFromPath(@"../../../data/maidata_internet_overdose.txt");
            SimaiParser parser = new SimaiParser();
            string[] tokensCandidates = tokenizer.ChartCandidates["5"];
            Chart candidate = parser.ChartOfToken(tokensCandidates);
            SimaiCompiler compiler = new SimaiCompiler();
            Ma2 toMa2 = new Ma2(candidate);
            Console.WriteLine(new Simai(toMa2).Compose());
        }

        [TestMethod]
        public void ComprehensiveTestComplex()
        {
            SimaiTokenizer tokenizer = new SimaiTokenizer();
            tokenizer.UpdateFromPath(@"../../../data/maidata-bpmChanges.txt");
            SimaiParser parser = new SimaiParser();
            string[] tokensCandidates = tokenizer.ChartCandidates["5"];
            Chart candidate = parser.ChartOfToken(tokensCandidates);
            SimaiCompiler compiler = new SimaiCompiler();
            Ma2 toMa2 = new Ma2(candidate);
            Console.WriteLine(toMa2.Compose());
        }

        [TestMethod]
        public void TestPowerSignSlide()
        {
            string candidate = "(120){4}2^8[1:1]),E";
            SimaiTokenizer tokenizer = new SimaiTokenizer();
            string[] tokens = tokenizer.TokensFromText(candidate);
            SimaiParser parser = new SimaiParser();
            Chart result = parser.ChartOfToken(tokens);
            Console.WriteLine(result.Compose());
        }

        [TestMethod]
        public void TestCHold()
        {
            string candidate = "(120){4}C2h[1:1],E";
            SimaiTokenizer tokenizer = new SimaiTokenizer();
            string[] tokens = tokenizer.TokensFromText(candidate);
            SimaiParser parser = new SimaiParser();
            Chart result = parser.ChartOfToken(tokens);
            Console.WriteLine(result.Compose());
        }

        [TestMethod]
        public void TestCTouch()
        {
            string candidate = "(120){4}C,,,E";
            SimaiTokenizer tokenizer = new SimaiTokenizer();
            string[] tokens = tokenizer.TokensFromText(candidate);
            SimaiParser parser = new SimaiParser();
            Chart result = parser.ChartOfToken(tokens);
            Console.WriteLine(result.Compose());
        }

        [TestMethod]
        public void TestWhiteSpace()
        {
            string candidate = "(120){4}C2h[1:1], ,  , ,    ,E";
            SimaiTokenizer tokenizer = new SimaiTokenizer();
            string[] tokens = tokenizer.TokensFromText(candidate);
            SimaiParser parser = new SimaiParser();
            Chart result = parser.ChartOfToken(tokens);
            Console.WriteLine(result.Compose());
        }

        [TestMethod]
        public void TestTimingWithTimedSlides()
        {
            Chart qz = new Ma2("../../../data/011311_03.ma2");
            SimaiParser simaiParser = new SimaiParser();
            SimaiTokenizer simaiTokenizer = new SimaiTokenizer();
            string composedSimai = qz.Compose(ChartEnum.ChartVersion.Simai);
            Chart revisedQz = simaiParser.ChartOfToken(simaiTokenizer.TokensFromText(composedSimai));
            Console.WriteLine(revisedQz.Compose(ChartEnum.ChartVersion.Ma2_103));
        }

        [TestMethod]
        public void TestGetDurationZeroWaitTime()
        {
            double bpm = 120;
            double[] expected = [0, 4];
            string quaverBeatCandidate = "[1:2]";
            string holdLastTimeCandidate = "[#4]";
            string slideLastTimeCandidate = "[0##4]";
            string holdBpmQuaverBeatCandidate = "[60#1:1]";
            string slideBpmQuaverBeatCandidate = "[0##60#1:1]";

            static bool IsEquivalentArray(double[] expected, double[] actual)
            {
                if (expected.Length != actual.Length) return false;
                for (int i = 0; i < expected.Length; i++)
                {
                    if (Math.Abs(expected[i] - actual[i]) > 0.001)
                    {
                        return false;
                    }
                }

                return true;
            }

            Assert.IsTrue(IsEquivalentArray(expected, SimaiParser.GetTimeCandidates(bpm, quaverBeatCandidate)));
            Assert.IsTrue(IsEquivalentArray(expected, SimaiParser.GetTimeCandidates(bpm, holdLastTimeCandidate)));
            Assert.IsTrue(IsEquivalentArray(expected, SimaiParser.GetTimeCandidates(bpm, slideLastTimeCandidate)));
            Assert.IsTrue(IsEquivalentArray(expected, SimaiParser.GetTimeCandidates(bpm, holdBpmQuaverBeatCandidate)));
            Assert.IsTrue(IsEquivalentArray(expected, SimaiParser.GetTimeCandidates(bpm, slideBpmQuaverBeatCandidate)));
            // Assert.AreEqual(expected, SimaiParser.GetTimeCandidates(bpm,quaverBeatCandidate));
            // Assert.AreEqual(expected, SimaiParser.GetTimeCandidates(bpm,holdLastTimeCandidate));
            // Assert.AreEqual(expected, SimaiParser.GetTimeCandidates(bpm,slideLastTimeCandidate));
            // Assert.AreEqual(expected, SimaiParser.GetTimeCandidates(bpm,holdBpmQuaverBeatCandidate));
            // Assert.AreEqual(expected, SimaiParser.GetTimeCandidates(bpm,slideBpmQuaverBeatCandidate));
        }

        [TestMethod]
        public void TestGetDurationOneSecWaitTime()
        {
            double bpm = 120;
            double[] expected = [1, 2];
            string slideLastTimeCandidate = "[1##2]";
            string slideReassignedCandidate = "[60#2]";
            string slideBpmQuaverBeatCandidate = "[1##60#2:1]";

            double[] slideLastTimeCandidateResult = GetTimeCandidates(bpm, slideLastTimeCandidate);
            double[] slideReassignedCandidateResult = GetTimeCandidates(bpm, slideReassignedCandidate);
            double[] slideBpmQuaverBeatCandidateResult = GetTimeCandidates(bpm, slideBpmQuaverBeatCandidate);

            Assert.IsTrue(IsEquivalentArray(expected, slideLastTimeCandidateResult));
            Assert.IsTrue(IsEquivalentArray(expected, slideReassignedCandidateResult));
            Assert.IsTrue(IsEquivalentArray(expected, slideBpmQuaverBeatCandidateResult));
            // Assert.AreEqual(expected, SimaiParser.GetTimeCandidates(bpm,quaverBeatCandidate));
            // Assert.AreEqual(expected, SimaiParser.GetTimeCandidates(bpm,holdLastTimeCandidate));
            // Assert.AreEqual(expected, SimaiParser.GetTimeCandidates(bpm,slideLastTimeCandidate));
            // Assert.AreEqual(expected, SimaiParser.GetTimeCandidates(bpm,holdBpmQuaverBeatCandidate));
            // Assert.AreEqual(expected, SimaiParser.GetTimeCandidates(bpm,slideBpmQuaverBeatCandidate));
        }

        [TestMethod]
        public void TestGraceNoteSplitting()
        {
            // string candidate = "4/C/Ch/5-7[8:1]";
            string candidate = "1`2`3`4bx/Cf/Chf/5-7[8:1]";
            foreach (string x in SimaiParser.EachGroupOfToken(candidate))
            {
                Console.WriteLine(x);
            }
        }

        [TestMethod]
        public void TestGraceNoteParsing()
        {
            string candidate = "(120){4}1`2`3`4`2^8[1:1]),E";
            SimaiTokenizer tokenizer = new();
            string[] tokens = tokenizer.TokensFromText(candidate);
            SimaiParser parser = new();
            Chart result = parser.ChartOfToken(tokens);
            Console.WriteLine(result.Compose(ChartEnum.ChartVersion.Ma2_104));
        }
    }
}