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
        SimaiCompiler compiler = new SimaiCompiler();
        Ma2 toMa2 = new Ma2(candidate);
        toMa2.ChartVersion = ChartEnum.ChartVersion.Ma2_104;
        Console.WriteLine(toMa2.Compose());
    }

    [TestMethod]
    public void SimaiFestivalScannerInternetOverdose()
    {
        string candidate = File.ReadAllText(@"../../../data/maidata_internet_overdose.txt").Split("&inote_5")[1];
        SimaiScanner scanner = new(candidate);
        List<TokenEnum.TokenType> scannedTokens = new();
        while (scanner.CurrentToken is not TokenEnum.TokenType.EOS)
        {
            scannedTokens.Add(scanner.CurrentToken);
            scanner.ScanAndAdvance();
            Console.WriteLine("At Line {0} Char {1}, token is {2}",scanner.LineNum, scanner.CharNum, scanner.CurrentToken);
        }
    }
}
