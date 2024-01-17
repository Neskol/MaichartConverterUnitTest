using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaiLib;
using static MaiLib.Chart;
using static MaiLib.NoteEnum;
using static MaiLib.ChartEnum;

namespace MaichartConverterUnitTest
{
    [TestClass]
    public class ChartTest
    {
        //[TestMethod]
        //public void Pass()
        //{
        //    Assert.IsTrue(true);
        //}

        public static int Definition = 384;

        //Starts ChartTest
        /// <summary>
        /// Test GetBPMTimeUnit
        /// </summary>
        [TestMethod]
        public void ChartGetBPMTimeUnitTest1()
        {
            double bpm = 60.0;
            double expected = 4.0 / 384.0;
            Assert.AreEqual(expected, Chart.GetBPMTimeUnit(bpm, Definition));
        }

        /// <summary>
        /// Test GetTimeStamp Method
        /// </summary>
        [TestMethod]
        public void GetTimeStampTestZero()
        {
            double expected = 0.0;
            Chart chart = new Ma2();
            chart.BPMChanges = new BPMChanges();
            chart.BPMChanges.Add(new BPMChange(0, 0, 60.0));
            Assert.AreEqual(expected, chart.GetTimeStamp(0));
        }

        [TestMethod]
        public void GetTimeStampTest384()
        {
            double expected = Chart.GetBPMTimeUnit(60, Definition) * 384;
            Chart chart = new Ma2();
            chart.BPMChanges = new BPMChanges();
            chart.BPMChanges.Add(new BPMChange(0, 0, 60.0));
            double actual = chart.GetTimeStamp(384);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTimeStampTest60To120()
        {
            Chart chart = new Ma2();
            chart.BPMChanges = new BPMChanges();
            chart.BPMChanges.Add(new BPMChange(0, 0, 60.0));
            chart.BPMChanges.Add(new BPMChange(1, 0, 120.0));
            double expected = Chart.GetBPMTimeUnit(60, Definition) * 384 + Chart.GetBPMTimeUnit(120, Definition) * 384;
            double actual = chart.GetTimeStamp(768);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTimeStampTest60to120to240()
        {
            Chart chart = new Ma2();
            chart.BPMChanges = new BPMChanges();
            chart.BPMChanges.Add(new BPMChange(0, 0, 60.0));
            chart.BPMChanges.Add(new BPMChange(1, 0, 120.0));
            chart.BPMChanges.Add(new BPMChange(2, 0, 240.0));
            double expected = Chart.GetBPMTimeUnit(60, Definition) * 384 + Chart.GetBPMTimeUnit(120, Definition) * 384 + Chart.GetBPMTimeUnit(240, Definition) * 384;
            int bar3Tick = 384 * 3;
            double actual = chart.GetTimeStamp(bar3Tick);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTimeStampTest60to120to240withTick3B24Tick()
        {
            Chart chart = new Ma2();
            chart.BPMChanges = new BPMChanges();
            chart.BPMChanges.Add(new BPMChange(0, 0, 60.0));
            chart.BPMChanges.Add(new BPMChange(1, 0, 120.0));
            chart.BPMChanges.Add(new BPMChange(2, 0, 240.0));
            double expected = Chart.GetBPMTimeUnit(60, Definition) * 384 + Chart.GetBPMTimeUnit(120, Definition) * 384 + Chart.GetBPMTimeUnit(240, Definition) * 384 + Chart.GetBPMTimeUnit(240, Definition) * 24;
            int bar3Tick24 = 384 * 3 + 24;
            double actual = chart.GetTimeStamp(bar3Tick24);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test GetTimeStamp Method with BPMChange
        /// </summary>
        [TestMethod]
        public void GetTimeStampTestZeroWithBPMChange()
        {
            double expected = 0.0;
            BPMChanges x = new BPMChanges();
            x.Add(new BPMChange(0, 0, 60.0));
            Assert.AreEqual(expected, Chart.GetTimeStamp(x, 0, Definition));
        }

        [TestMethod]
        public void GetTimeStampTest384WithBPMChange()
        {
            double expected = Chart.GetBPMTimeUnit(60, Definition) * 384;
            BPMChanges x = new BPMChanges();
            x.Add(new BPMChange(0, 0, 60.0));
            double actual = GetTimeStamp(x, 384, Definition);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTimeStampTest60To120WithBPMChange()
        {
            BPMChanges x = new BPMChanges();
            x.Add(new BPMChange(0, 0, 60.0));
            x.Add(new BPMChange(1, 0, 120.0));
            double expected = Chart.GetBPMTimeUnit(60, Definition) * 384 + Chart.GetBPMTimeUnit(120, Definition) * 384;
            double actual = GetTimeStamp(x, 768, Definition);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTimeStampTest60to120to240WithBPMChange()
        {
            BPMChanges x = new BPMChanges();
            x.Add(new BPMChange(0, 0, 60.0));
            x.Add(new BPMChange(1, 0, 120.0));
            x.Add(new BPMChange(2, 0, 240.0));
            double expected = Chart.GetBPMTimeUnit(60, Definition) * 384 + Chart.GetBPMTimeUnit(120, Definition) * 384 + Chart.GetBPMTimeUnit(240, Definition) * 384;
            int bar3Tick = 384 * 3;
            double actual = GetTimeStamp(x, bar3Tick, Definition);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTimeStampTest60to120to240withTick3B24TickWithBPMChange()
        {
            BPMChanges x = new BPMChanges();
            x.Add(new BPMChange(0, 0, 60.0));
            x.Add(new BPMChange(1, 0, 120.0));
            x.Add(new BPMChange(2, 0, 240.0));
            double expected = Chart.GetBPMTimeUnit(60, Definition) * 384 + Chart.GetBPMTimeUnit(120, Definition) * 384 + Chart.GetBPMTimeUnit(240, Definition) * 384 + Chart.GetBPMTimeUnit(240, Definition) * 24;
            int bar3Tick24 = 384 * 3 + 24;
            double actual = GetTimeStamp(x, bar3Tick24,Definition);
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// Test GetTimeStamp with actual notes
        /// </summary>
        [TestMethod]
        public void ChartGetTimeStampTestNoteTapBar0Tick192()
        {
            Chart chart = new Ma2();
            chart.BPMChanges = new BPMChanges();
            chart.BPMChanges.Add(new BPMChange(0, 0, 60.0));
            chart.BPMChanges.Add(new BPMChange(1, 0, 120.0));
            chart.BPMChanges.Add(new BPMChange(2, 0, 240.0));
            Note x = new Tap(NoteType.TAP, 0, 192, "1");
            chart.Notes.Add(x);
            chart.Update();
            double expected = Chart.GetBPMTimeUnit(60, Definition) * 192;
            int bar0Tick192 = 192;
            double actual = chart.GetTimeStamp(bar0Tick192);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ChartGetTimeStampTestNoteSlideBar0Tick192()
        {
            Chart chart = new Ma2();
            chart.BPMChanges = new BPMChanges();
            chart.BPMChanges.Add(new BPMChange(0, 0, 60.0));
            chart.BPMChanges.Add(new BPMChange(1, 0, 120.0));
            chart.BPMChanges.Add(new BPMChange(2, 0, 240.0));
            Note start = new Tap(NoteType.STR, 0, 96, "1");
            Note x = new Slide(NoteType.SLR, 0, 192, "1", 24, 96, "3");
            chart.Notes.Add(x);
            chart.Notes.Add(start);
            chart.Update();
            double expectedTick = Chart.GetBPMTimeUnit(60, Definition) * 192;
            double expectedWait = Chart.GetBPMTimeUnit(60, Definition) * (192 + 24);
            double expectedLast = Chart.GetBPMTimeUnit(60, Definition) * (192 + 24 + 96);
            int bar0Tick192 = 192;
            int bar0Tick192Add24 = 192 + 24;
            int bar0Tick192Add24Add96 = 192 + 24 + 96;
            double actualTick = chart.GetTimeStamp(bar0Tick192);
            double actualWait = chart.GetTimeStamp(bar0Tick192Add24);
            double actualLast = chart.GetTimeStamp(bar0Tick192Add24Add96);
            Assert.AreEqual(expectedTick, actualTick);
            Assert.AreEqual(expectedWait, actualWait);
            Assert.AreEqual(expectedLast, actualLast);
        }

        /// <summary>
        /// Test GetBPMByTick
        /// </summary>
        [TestMethod]
        public void GetBPMByTickZero()
        {
            Chart chart = new Ma2();
            chart.BPMChanges = new BPMChanges();
            chart.BPMChanges.Add(new BPMChange(0, 0, 120));
            chart.Update();
            double expected = 120.0;
            double actual = chart.GetBPMByTick(0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetBPMByTick384()
        {
            Chart chart = new Ma2();
            chart.BPMChanges = new BPMChanges();
            chart.BPMChanges.Add(new BPMChange(0, 0, 120));
            chart.Update();
            double expected = 120.0;
            double actual = chart.GetBPMByTick(384);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetBPMByTickWithNoteZero()
        {
            Chart chart = new Ma2();
            chart.BPMChanges = new BPMChanges();
            chart.BPMChanges.Add(new BPMChange(0, 0, 120));
            Note x = new Tap(NoteType.TAP, 1, 0, "1");
            chart.Notes.Add(x);
            chart.Update();
            double expected = 120.0;
            double actual = chart.GetBPMByTick(x.TickStamp);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetBPMByTickTestNoteSlideBar0Tick0Cross3Bar()
        {
            Chart chart = new Ma2();
            chart.BPMChanges = new BPMChanges();
            chart.BPMChanges.Add(new BPMChange(0, 0, 60.0));
            chart.BPMChanges.Add(new BPMChange(1, 0, 120.0));
            chart.BPMChanges.Add(new BPMChange(2, 0, 240.0));
            Note start = new Tap(NoteType.STR, 0, 192, "1");
            Note x = new Slide(NoteType.SLR, 0, 0, "1", 384, 384, "3");
            chart.Notes.Add(x);
            chart.Update();
            double expectedTick = 60.0;
            double expectedWait = 120.0;
            double expectedLast = 240.0;
            double actualTick = chart.GetBPMByTick(x.TickStamp);
            double actualWait = chart.GetBPMByTick(x.WaitTickStamp);
            double actualLast = chart.GetBPMByTick(x.LastTickStamp);
            Assert.AreEqual(expectedTick, actualTick);
            Assert.AreEqual(expectedWait, actualWait);
            Assert.AreEqual(expectedLast, actualLast);
        }

        [TestMethod]
        public void TestSlideGroup()
        {
            Chart candidate = new Ma2("../../../data/DXFestivalTestMa2.ma2");
            foreach (Note x in candidate.Notes)
            {
                if (x.NoteGenre is NoteGenre.SLIDE)
                {
                    Console.WriteLine(x.Compose(ChartVersion.Debug));
                    Assert.IsTrue(x.NoteGenre is NoteGenre.SLIDE);
                }
            }
        }

        [TestMethod]
        public void TestUpdateNoteTypeChange()
        {
            Chart candidateChart = new Ma2();
            BPMChange changeNote = new BPMChange(0, 0, 120.0);
            Note tap1 = new Tap(NoteType.TAP, 1, 0, "1");
            Note tap2 = new Tap(NoteType.TAP, 1, 1, "2");
            Note tap3 = new Tap(NoteType.TAP, 1, 1, "3");
            candidateChart.BPMChanges = new BPMChanges();
            candidateChart.BPMChanges.Add(changeNote);
            candidateChart.Notes.Add(tap1);
            candidateChart.Notes.Add(tap2);
            candidateChart.Notes.Add(tap3);
            candidateChart.Update();
            Console.WriteLine(new Simai(candidateChart).Compose());
            Assert.IsNotNull(candidateChart);
        }

        [TestMethod]
        public void TestDifferentChartVersionParse()
        {
            Chart candidate = new Ma2("../../../data/011568_03.ma2");
            Console.WriteLine(candidate.Compose(ChartVersion.Debug));
            Assert.IsNotNull(candidate);
        }

        [TestMethod]
        public void TestNoteStatistics()
        {
            Ma2 candidate = new Ma2("../../../data/011568_03.ma2");
            // LINQ for TAP
            Console.WriteLine("TAP Num:\t{0}", candidate.Notes.Count(p=>p.NoteType is NoteType.TAP && p.NoteSpecialState is SpecialState.Normal));
            Console.WriteLine("Break Num:\t{0}", candidate.Notes.Count(p=>p.NoteType is NoteType.TAP && p.NoteSpecialState is SpecialState.Break));
            Console.WriteLine("EX Tap Num:\t{0}", candidate.Notes.Count(p=> p.NoteType is NoteType.TAP && p.NoteSpecialState is SpecialState.EX));
            Console.WriteLine("BreakEX Tap\tNum: {0}", candidate.Notes.Count(p=> p.NoteType is NoteType.TAP && p.NoteSpecialState is SpecialState.BreakEX));

            // LINQ for Hold
            Console.WriteLine("HOLD Num:\t{0}", candidate.Notes.Count(p=>p.NoteType is NoteType.HLD && p.NoteSpecialState is SpecialState.Normal));
            Console.WriteLine("EX HOLD Num:\t{0}", candidate.Notes.Count(p=> p.NoteType is NoteType.HLD && p.NoteSpecialState is SpecialState.EX));
            Console.WriteLine("Break HOLD Num:\t{0}", candidate.Notes.Count(p=>p.NoteType is NoteType.HLD && p.NoteSpecialState is SpecialState.Break));
            Console.WriteLine("BreakEX HOLD Num:\t{0}", candidate.Notes.Count(p=> p.NoteType is NoteType.HLD && p.NoteSpecialState is SpecialState.BreakEX));

            // LINQ for Slide Starts
            Console.WriteLine("STR Num:\t{0}", candidate.Notes.Count(p=>p.NoteType is NoteType.STR && p.NoteSpecialState is SpecialState.Normal));
            Console.WriteLine("Break STR Num:\t{0}", candidate.Notes.Count(p=>p.NoteType is NoteType.STR && p.NoteSpecialState is SpecialState.Break));
            Console.WriteLine("EX STR Num:\t{0}", candidate.Notes.Count(p=> p.NoteType is NoteType.STR && p.NoteSpecialState is SpecialState.EX));
            Console.WriteLine("BreakEX STR Num:\t{0}", candidate.Notes.Count(p=> p.NoteType is NoteType.STR && p.NoteSpecialState is SpecialState.BreakEX));

            // LINQ for Touch
            Console.WriteLine("Touch Tap Num:\t{0}", candidate.Notes.Count(p=>p.NoteType is NoteType.TTP));
            Console.WriteLine("Touch Hold Num:\t{0}", candidate.Notes.Count(p=>p.NoteType is NoteType.THO));

            // LINQ for Slide
            candidate.ComposeSlideGroup(); // This is needed to exclude connecting slide
            Console.WriteLine("Slide Num:\t{0}", candidate.Notes.Count(p=>p.NoteGenre is NoteGenre.SLIDE && p.NoteSpecialState is SpecialState.Normal));
            Console.WriteLine("Break Slide Num:\t{0}", candidate.Notes.Count(p=>p.NoteGenre is NoteGenre.SLIDE && p.NoteSpecialState is SpecialState.Break));

            // LINQ for ALL
            Console.WriteLine("ALL Num:\t{0}", candidate.Notes.Count);

            Console.WriteLine(candidate.GenerateNoteStatistics());
        }
    }
}

