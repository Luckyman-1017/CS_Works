using System;
using System.Threading;
using FileRead;
using Calculator;
using Show;

class Execurioner
{
    static void Main()
    {
        FileReader fileReader = new FileReader();
        Shower shower = new Shower();
        Calculate cal = new Calculate();
        string filePath, year, cmonth, monthName, copyPath, directoryPath;
        int month, sumcost;
        bool isSuccess, isRetry;
        string[] items = new string[150], copyItems = new string[150];
        int[] costs = new int[150], copyCosts = new int[150];

        year = shower.SearchYear();
        cmonth = shower.SearchMonth();
        isSuccess = int.TryParse(cmonth, out month);
        monthName = cal.MonthIdentify(month);
        filePath = cal.MakeFilepath(year, cmonth, monthName);

        //Console.WriteLine(filePath);
        try
        {
            fileReader.FileRead(filePath, costs, items);
        }
        catch
        {
            shower.ErrorMessage(0);
            Main();
        }
        /*for(int i = 0; i < costs.Length; i++)
        {
            if(costs[i] == 0)
            {
                break;
            }
            Console.WriteLine("costs : " + costs[i] + "\titem : " + items[i]);
        }*/
        cal.Sort(costs, items, copyCosts, copyItems);
        sumcost = cal.SumCalculator(copyCosts);
        shower.ShowResult(copyCosts, copyItems, sumcost);
        copyPath = cal.MakeCopypath(year, cmonth, monthName);
        try
        {
            fileReader.FileWrite(copyPath, copyCosts, copyItems);
            Console.WriteLine("ソート後を上書きしました");
        }
        catch
        {
            Console.WriteLine("ディレクトリがないので作成します");
            directoryPath = cal.MakeDirectoryPath(year);
            fileReader.MakeDirectory(directoryPath);
            fileReader.FileWrite(copyPath, copyCosts, copyItems);
            Console.WriteLine("ソート後を書き込みました");
        }

        isRetry = shower.AskReturn();
        if(isRetry == true)
        {
            Main();
        }
    }
}