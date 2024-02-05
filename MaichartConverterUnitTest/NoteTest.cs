using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaiLib;
using static MaiLib.NoteEnum;
using static MaiLib.ChartEnum;

namespace MaichartConverterUnitTest
{
    [TestClass]
    public class NoteTest
    {
        [TestMethod]
        public void GetBPMTimeUnitTest1()
        {
            double bpm = 60.0;
            double expected = 4.0 / 384.0;
            Assert.AreEqual(expected, Note.GetBPMTimeUnit(bpm));
        }

        /// <summary>
        /// Test GetTimeStamp with actuall notes
        /// </summary>
        [TestMethod]
        public void GetTimeStampTestNoteTapBar0Tick192()
        {
            Chart chart = new Ma2();
            chart.BPMChanges = new BPMChanges();
            chart.BPMChanges.Add(new BPMChange(0, 0, 60.0));
            chart.BPMChanges.Add(new BPMChange(1, 0, 120.0));
            chart.BPMChanges.Add(new BPMChange(2, 0, 240.0));
            Note x = new Tap(NoteType.TAP, 0, 192, "1");
            chart.Notes.Add(x);
            chart.Update();
            double expected = Note.GetBPMTimeUnit(60) * 192;
            int bar0Tick192 = 192;
            double actual = chart.GetTimeStamp(bar0Tick192);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTimeStampTestNoteSlideBar0Tick192()
        {
            Chart chart = new Ma2();
            chart.BPMChanges = new BPMChanges();
            chart.BPMChanges.Add(new BPMChange(0, 0, 60.0));
            chart.BPMChanges.Add(new BPMChange(1, 0, 120.0));
            chart.BPMChanges.Add(new BPMChange(2, 0, 240.0));
            Note start = new Tap(NoteType.STR, 0, 96, "1");
            Note x = new Slide(NoteType.SLR, 0, 192, "1", 24, 96, "3");
            chart.Notes.Add(x);
            chart.Update();
            double expectedTick = Note.GetBPMTimeUnit(60) * 192;
            double expectedWait = Note.GetBPMTimeUnit(60) * (192 + 24);
            double expectedLast = Note.GetBPMTimeUnit(60) * (192 + 24 + 96);
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

        [TestMethod]
        public void GetTimeStampTestNoteTapBar0Tick192WithoutChart()
        {
            BPMChanges bpmChanges = new BPMChanges();
            bpmChanges.Add(new BPMChange(0, 0, 60.0));
            bpmChanges.Add(new BPMChange(1, 0, 120.0));
            bpmChanges.Add(new BPMChange(2, 0, 240.0));
            bpmChanges.Update();
            Note x = new Tap(NoteType.TAP, 0, 192, "1");
            x.BPMChangeNotes = bpmChanges.ChangeNotes;
            double expected = Note.GetBPMTimeUnit(60) * 192;
            int bar0Tick192 = 192;
            double actual = x.GetTimeStamp(bar0Tick192);
            Console.WriteLine(x.GetTickStampByTime(7));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetTimeStampTestNoteSlideBar0Tick192WithoutChart()
        {
            BPMChanges bpmChanges = new BPMChanges();
            bpmChanges.Add(new BPMChange(0, 0, 60.0));
            bpmChanges.Add(new BPMChange(1, 0, 120.0));
            bpmChanges.Add(new BPMChange(2, 0, 240.0));
            bpmChanges.Update();
            Note x = new Slide(NoteType.SLR, 0, 192, "1", 24, 96, "3");
            x.BPMChangeNotes = bpmChanges.ChangeNotes;
            double expectedTick = Note.GetBPMTimeUnit(60) * 192;
            double expectedWait = Note.GetBPMTimeUnit(60) * (192 + 24);
            double expectedLast = Note.GetBPMTimeUnit(60) * (192 + 24 + 96);
            int bar0Tick192 = 192;
            int bar0Tick192Add24 = 192 + 24;
            int bar0Tick192Add24Add96 = 192 + 24 + 96;
            double actualTick = x.GetTimeStamp(bar0Tick192);
            double actualWait = x.GetTimeStamp(bar0Tick192Add24);
            double actualLast = x.GetTimeStamp(bar0Tick192Add24Add96);
            Assert.AreEqual(expectedTick, actualTick);
            Assert.AreEqual(expectedWait, actualWait);
            Assert.AreEqual(expectedLast, actualLast);
        }

        [TestMethod]
        public void SlideComposeTestSLL1V37()
        {
            Note start = new Tap(NoteType.STR, 0, 0, "0");
            Note slide = new Slide(NoteType.SLL, 0, 0, "0", 96, 96, "6");
            string expected = "1V37[4:1]";
            string startCompose = start.Compose(ChartVersion.Simai);
            string slideCompose = slide.Compose(ChartVersion.Simai);
            string actual = startCompose + slideCompose;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HoldSpecialEffectTest()
        {
            Note touchHold = new Hold(NoteType.THO, 0, 0, "0C", 384);
            // touchHold.SpecialEffect = true;
            string expected = "C1h[1:1]";
            Assert.AreEqual(expected,touchHold.Compose(ChartVersion.Simai));
        }
    }
}

