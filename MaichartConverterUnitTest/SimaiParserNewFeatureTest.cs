using System;
using MaiLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaichartConverterUnitTest;

[TestClass]
public class SimaiParserNewFeatureTest
{
    /// <summary>
    /// From MaichartConverter Issue #19
    /// </summary>
    [TestMethod]
    public void FesSlideDuration()
    {
        string token = "(120){4}1-4-6[8:1],E";
        SimaiParser parser = new();
        SimaiTokenizer tokenizer = new();
        Chart candidate = parser.ChartOfToken(tokenizer.TokensFromText(token));
        Console.WriteLine(candidate.Compose(ChartEnum.ChartVersion.Simai));
        Console.WriteLine(candidate.Compose(ChartEnum.ChartVersion.Ma2_104));
    }
}