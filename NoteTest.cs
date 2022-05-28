using Microsoft.VisualStudio.TestTools.UnitTesting;
using static MaichartConverter.Note;
using static MaichartConverter.Chart;
using MaichartConverter;

namespace MaichartConverter
{
	[TestClass]
	public class NoteTest
	{
        [TestMethod]
        public void GetBPMTimeUnitTest1()
        {
            double bpm = 60.0;
            double expected = 4.0 / 384.0;
            Assert.AreEqual(expected, Chart.GetBPMTimeUnit(bpm));
        }
    }
}

