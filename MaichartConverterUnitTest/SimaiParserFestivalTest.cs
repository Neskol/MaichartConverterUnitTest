namespace MaichartConverterUnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaiLib;
using System.IO;

[TestClass]
public class SimaiParserFestivalTest
{
    [TestMethod]
    public void SimaiFestivalTestInternetOverdose()
    {
        SimaiTokenizer tokenizer = new SimaiTokenizer();
        tokenizer.UpdateFromPath(@"../../../data/maidata_internet_overdose.txt");
        SimaiParser parser = new SimaiParser();
        string[] tokensCandidates = tokenizer.ChartCandidates["5"];
        Chart candidate = parser.ChartOfToken(tokensCandidates);
        // Console.WriteLine("This chart contains following numbers of ");
        SimaiCompiler compiler = new SimaiCompiler();
        Ma2 toMa2 = new Ma2(candidate);
        toMa2.ChartVersion = ChartEnum.ChartVersion.Ma2_104;
        Console.WriteLine(toMa2.Compose());
    }

    [TestMethod]
    public void SimaiFestivalTestAssignConnectingSlideMeasure()
    {
        // string token = "-8^7[8:1]";
        // string token = "2-4-6-8[1:1]";
        // string token = "2-4[1:1]-6[1:1]-8[1:1]";
        string token = "2-4[1:1]";
        foreach (string x in SimaiParser.ExtractConnectingSlides(token))
        {
            Console.WriteLine(x);
        }
    }

    [TestMethod]
    public void SimaiFestivalTestAssignConnectingSlideTiming()
    {
        string token = "2-4-6-8[0.3##0.6]";
        // string token = "2-4[1:1]-6[1:1]-8[1:1]";
        // string token = "2-4[1:1]";
        foreach (string x in SimaiParser.ExtractConnectingSlides(token))
        {
            Console.WriteLine(x);
        }
    }

    [TestMethod]
    public void SimaiFestivalTestConnectingSlide()
    {
        SimaiTokenizer tokenizer = new SimaiTokenizer();
        SimaiParser parser = new SimaiParser();
        // string token = "(120){1}2-4[1:1]-6[1:1]-8[1:1],E";
        // string token = "(120){1}2-4-6-8[1:1],E";
        string token = "(120){1}3-8^7[8:1],E";
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
        Console.WriteLine(SimaiParser.KeyDistance(6,7,NoteEnum.NoteType.SCR));
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
