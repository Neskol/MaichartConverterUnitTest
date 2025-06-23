using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaiLib;

namespace MaichartConverterUnitTest
{
    [TestClass]
    public class XmlInformationTest
    {
        [TestMethod]
        public void DummyInformationGenreationTest()
        {
            XmlInformation xml = new XmlInformation();
            xml.FormatDummyInformation();
            // xml.GenerateEmptyStoredXML();
            // xml.TakeInValue.Save("../../../data/information.xml");
        }

        [TestMethod]
        public void ExistingXmlTest()
        {

            XmlInformation xml = new XmlInformation("../../../data/500429_Music.xml");
            string expected = "[宴]Wonderland Wars オープニング";
            string actual = xml.InformationDict["Name"];
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void GenerateNormalXmlTest()
        {

        }
    }
}