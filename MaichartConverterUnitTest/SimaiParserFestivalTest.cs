using System;
using System.Collections.Generic;
using MaiLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaichartConverterUnitTest;

[TestClass]
public class SimaiParserFestivalTest
{
    [TestMethod]
    public void SimaiFestivalTestInternetOverdose()
    {
        SimaiTokenizer tokenizer = new();
        tokenizer.UpdateFromPath(@"../../../data/maidata_internet_overdose.txt");
        SimaiParser parser = new();
        string[] tokensCandidates = tokenizer.ChartCandidates["5"];
        Chart candidate = parser.ChartOfToken(tokensCandidates);
        // Console.WriteLine("This chart contains following numbers of ");
        SimaiCompiler compiler = new();
        Ma2 toMa2 = new(candidate);
        toMa2.ChartVersion = ChartEnum.ChartVersion.Ma2_104;
        Console.WriteLine(toMa2.Compose());
        Assert.IsTrue(toMa2.IsDxChart);
    }

    [TestMethod]
    public void SimaiFestivalTestAssignConnectingSlideMeasure()
    {
        // string token = "-8^7[8:1]";
        // string token = "2-4-6-8[1:1]";
        // string token = "2-4[1:1]-6[1:1]-8[1:1]";
        // string token = "2-4[1:1]";
        string token = "1V75V71[0.3##120#4:2]";
        foreach (string x in SimaiParser.ExtractConnectingSlides(token)) Console.WriteLine(x);
    }

    [TestMethod]
    public void SimaiFestivalTestAssignConnectingSlideTiming()
    {
        // string token = "2-4-6-8[0.3##0.6]";
        // string token = "2-4-6-8[0.3##60#4:3]";
        // string token = "2-4[1:1]-6[1:1]-8[1:1]";
        // string token = "2!-4[1:1]";
        string token = "1-4-8[1:1]";
        foreach (string x in SimaiParser.ExtractConnectingSlides(token)) Console.WriteLine(x);
    }

    [TestMethod]
    public void SimaiFestivalTestConnectingSlide()
    {
        SimaiTokenizer tokenizer = new();
        SimaiParser parser = new();
        string token = "(120){1}2-4-6-8[60#4:1],E";
        // string token = "(120){1}2-4[1:1]-6[1:1]-8[1:1],E";
        // string token = "(120){1}2-4-6-8[1:1],E";
        // string token = "(120){1}3-8^7[8:1],E";
        // string token = "(120){1}1V75V71[8:1]b*V35V31[8:1],1h,C,Chf[#8],2h/3h[160#4:2],E";
        Chart candidate = parser.ChartOfToken(tokenizer.TokensFromText(token));
        candidate = new Ma2(candidate);
        candidate.ChartVersion = ChartEnum.ChartVersion.Ma2_104;
        Console.WriteLine(candidate.Compose());

        candidate = new Simai(candidate);
        candidate.ChartVersion = ChartEnum.ChartVersion.SimaiFes;
        Console.WriteLine(candidate.Compose());
    }

    [TestMethod]
    public void SimaiFestivalTestVariousSlideDuration()
    {
        SimaiTokenizer tokenizer = new();
        SimaiParser parser = new();
        string token = "(120){1}1-4[60#1:1],E";
        Chart candidate = parser.ChartOfToken(tokenizer.TokensFromText(token));
        // candidate = new Ma2(candidate);
        // candidate.ChartVersion = ChartEnum.ChartVersion.Ma2_104;
        // Console.WriteLine(candidate.Compose());

        candidate = new Simai(candidate);
        candidate.ChartVersion = ChartEnum.ChartVersion.SimaiFes;
        Console.WriteLine(candidate.Compose());
    }

    [TestMethod]
    public void SimaiFestivalTestUtageSlideStarts()
    {
        SimaiTokenizer tokenizer = new();
        SimaiParser parser = new();

        string token = "(120){1}1$/2!-4[1:1]/3h,E";
        Chart candidate = parser.ChartOfToken(tokenizer.TokensFromText(token));
        candidate = new Ma2(candidate);
        candidate.ChartVersion = ChartEnum.ChartVersion.Ma2_104;
        Console.WriteLine(candidate.Compose());

        candidate = new Simai(candidate);
        candidate.ChartVersion = ChartEnum.ChartVersion.SimaiFes;
        Console.WriteLine(candidate.Compose());
    }

    [TestMethod]
    public void SimaiFestivalTestEachTap()
    {
        SimaiTokenizer tokenizer = new();
        SimaiParser parser = new();

        // string token = "(120){1}12,34,56";
        string token = "(120){4}1-4-6[8:1],E";
        List<string> extractedParts = SimaiParser.EachGroupOfToken("(120){4}1-4-6[8:1]");

        Chart candidate = parser.ChartOfToken(tokenizer.TokensFromText(token));
        candidate = new Ma2(candidate);
        candidate.ChartVersion = ChartEnum.ChartVersion.Ma2_104;
        Console.WriteLine(candidate.Compose());

        candidate = new Simai(candidate);
        candidate.ChartVersion = ChartEnum.ChartVersion.SimaiFes;
        Console.WriteLine(candidate.Compose());
    }

    [TestMethod]
    public void TestKeyDistance()
    {
        Console.WriteLine(SimaiParser.KeyDistance(6, 7, NoteEnum.NoteType.SCR));
    }

    // [TestMethod]
    // public void SimaiFestivalScannerInternetOverdose()
    // {
    //     string candidate = File.ReadAllText(@"../../../data/maidata_internet_overdose.txt").Split("&inote_5=")[1];
    //     SimaiScanner scanner = new(candidate);
    //     List<TokenEnum.TokenType> scannedTokens = new();
    //     List<char> scannedChars = new();
    //     while (scanner.CurrentToken is not TokenEnum.TokenType.EOS)
    //     {
    //         scannedTokens.Add(scanner.CurrentToken);
    //         scannedChars.Add(scanner.CurrentChar ?? ' ');
    //         Console.WriteLine("{0} - {1}", scanner.CurrentToken, scanner.CurrentChar);
    //         scanner.ScanAndAdvance();
    //     }
    // }
}