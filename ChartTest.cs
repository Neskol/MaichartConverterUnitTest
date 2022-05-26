using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaichartConverter;

namespace MaichartConverter
{
    [TestClass]
    public class ChartTest
    {
        [TestMethod]
        public void GetBPMTimeUnitTest1()
        {
            double bpm = 60.0;
            double expected = 4.0 / 384.0;
            Assert.AreEqual(expected, Chart.GetBPMTimeUnit(bpm));
        }

        [TestMethod]
        public void GetTimeStampTestZero()
        {
            double expected = 0.0;
            Chart chart = new Ma2();
            chart.BPMChanges = new BPMChanges();
            chart.BPMChanges.Add(new BPMChange(0,0,60.0));
            Assert.AreEqual(expected, chart.GetTimeStamp(0));
        }

        [TestMethod]
        public void GetTimeStampTest384()
        {
            double expected = Chart.GetBPMTimeUnit(60)*384;
            Chart chart = new Ma2();
            chart.BPMChanges = new BPMChanges();
            chart.BPMChanges.Add(new BPMChange(0, 0, 60.0));
            Assert.AreEqual(expected, chart.GetTimeStamp(384));
        }
    }
}