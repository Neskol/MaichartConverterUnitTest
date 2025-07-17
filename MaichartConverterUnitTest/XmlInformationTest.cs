using MaiLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaichartConverterUnitTest
{
    [TestClass]
    public class XmlInformationTest
    {
        [TestMethod]
        public void DummyInformationGenreationTest()
        {
            XmlInformation xml = new();
            xml.FormatDummyInformation();
            // xml.GenerateEmptyStoredXML();
            // xml.TakeInValue.Save("../../../data/information.xml");
        }

        [TestMethod]
        public void ExistingXmlTest()
        {
            XmlInformation xml = new("../../../data/500429_Music.xml", true);
            string expected = "[宴]Wonderland Wars オープニング";
            string actual = xml.InformationDict["Name"];
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GenerateNormalXmlTest()
        {
            SimaiTokenizer tokenizer = new();
            tokenizer.UpdateFromPath("../../../data/maidata_pandora.txt");
            tokenizer.SimaiTrackInformation.Save("../../../data/Music_pandora.xml");
            XmlInformation xml = new("../../../data/Music_pandora.xml", true);
            string expected = "PANDORA PARADOXXX";
            string actual = xml.InformationDict["Name"];
            Assert.AreEqual(expected, actual);
        }
    }
}