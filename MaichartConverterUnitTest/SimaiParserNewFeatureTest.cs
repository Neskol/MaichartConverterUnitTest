using System;
using MaiLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaichartConverterUnitTest;

[TestClass]
public class SimaiParserNewFeatureTest
{
    /// <summary>
    ///     From MaichartConverter Issue #19
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

    [TestMethod]
    public void FesSlideDurationComplex()
    {
        string token = "(120){4}1-4-6[240#8:3],E";
        SimaiParser parser = new();
        SimaiTokenizer tokenizer = new();
        Chart candidate = parser.ChartOfToken(tokenizer.TokensFromText(token));
        Console.WriteLine(candidate.Compose(ChartEnum.ChartVersion.Simai));
        Console.WriteLine(candidate.Compose(ChartEnum.ChartVersion.Ma2_104));
    }

    /// <summary>
    ///     From MaiLib Issue #41
    /// </summary>
    [TestMethod]
    public void FesSlideCustomDuration()
    {
        string token = "(120){4}1-4[160#4:1],E";
        SimaiParser parser = new();
        SimaiTokenizer tokenizer = new();
        Chart candidate = parser.ChartOfToken(tokenizer.TokensFromText(token));
        Console.WriteLine(candidate.Compose(ChartEnum.ChartVersion.Simai));
        Console.WriteLine(candidate.Compose(ChartEnum.ChartVersion.Ma2_104));
    }

    /// <summary>
    ///     From MaiLib Issue #42
    /// </summary>
    [TestMethod]
    public void FesConnectingSlideDelay()
    {
        string token = "(120){4}1-4[8:1]-6[16:1]-8[24:1],E";
        SimaiParser parser = new();
        SimaiTokenizer tokenizer = new();
        Chart candidate = parser.ChartOfToken(tokenizer.TokensFromText(token));
        Console.WriteLine(candidate.Compose(ChartEnum.ChartVersion.Simai));
        Console.WriteLine(candidate.Compose(ChartEnum.ChartVersion.Ma2_104));
    }

    /// <summary>
    ///     From MaiLib Issue #43
    /// </summary>
    [TestMethod]
    public void EachTapRework()
    {
        string token = "(120){48}26,37,48,E";
        SimaiParser parser = new();
        SimaiTokenizer tokenizer = new();
        Chart candidate = parser.ChartOfToken(tokenizer.TokensFromText(token));
        Console.WriteLine(candidate.Compose(ChartEnum.ChartVersion.Simai));
        Console.WriteLine(candidate.Compose(ChartEnum.ChartVersion.Ma2_104));
    }
}