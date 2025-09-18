using System;
using System.IO;
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

    /// <summary>
    ///     From MaiLib Issue #46
    /// </summary>
    [TestMethod]
    public void FesConnectingLongSlide()
    {
        string token = "(120){1}1-4[4:1]-6[4:1]-8[4:1],{1}1-4-6-8[4:3],E";
        SimaiParser parser = new();
        SimaiTokenizer tokenizer = new();
        Chart candidate = parser.ChartOfToken(tokenizer.TokensFromText(token));
        Console.WriteLine(candidate.Compose(ChartEnum.ChartVersion.Simai));
        Console.WriteLine(candidate.Compose(ChartEnum.ChartVersion.Ma2_104));
    }

    [TestMethod]
    public void TouchHoldOtherThanC()
    {
        string token = "(120){1}C1h,C1hf[1:1],Chf[4:1],A3h[8:1],B5h[16:1],D6hf,E1hf,F1hf,F2h,E";
        SimaiParser parser = new();
        SimaiTokenizer tokenizer = new();
        Chart candidate = parser.ChartOfToken(tokenizer.TokensFromText(token));
        Console.WriteLine(candidate.Compose(ChartEnum.ChartVersion.Simai));
        Console.WriteLine(candidate.Compose(ChartEnum.ChartVersion.Ma2_104));
    }

    /// <summary>
    ///     Test Apollo middle slide issue
    /// </summary>
    [TestMethod]
    public void TestApolloReverse()
    {
        Ma2 test = new Ma2("../../../data/011661_03.ma2") { ChartVersion = ChartEnum.ChartVersion.Ma2_104 };
        Simai apollo = new Simai(test);
        apollo.Update();
        // Console.WriteLine(test.Compose());
        Console.WriteLine(apollo.Compose(ChartEnum.ChartVersion.Ma2_104));
        StreamWriter sw2 = new StreamWriter("../../../data/ApolloAfterSimaiPaser.ma2", false);
        sw2.WriteLine(test.Compose());
        sw2.Close();
        Assert.IsNotNull(test);
    }
}