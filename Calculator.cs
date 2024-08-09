using System;
using System.IO;

namespace Calculator
{
    public class Calculate
    {
        public void Sort(int[] costs, string[] items, int[] copyCosts, string[] copyItems) 
        {
            int size = 0;
            for(int i = 0; i < items.Length; i++)
            {
                for(int j = 0; j <= size; j++)
                {
                    if(copyItems[j] == items[i])
                    {
                        copyCosts[j] += costs[i];
                        break;
                    }
                    if((j == size)&& (copyItems[j] != items[i]))
                    {
                        copyItems[size] = items[i];
                        copyCosts[size++] += costs[i];
                        break;
                    }
                }
            }
        }

        public int SumCalculator(int[] costs)
        {
            int sum = 0;
            foreach(int x in costs)
            {
                sum += x;
            }
            return sum;
        }

        public string MonthIdentify(int month)
        {
            string monthName;
            switch (month)
            {
                case 1: monthName = "January"; break;
                case 2: monthName = "February"; break;
                case 3: monthName = "March"; break;
                case 4: monthName = "April"; break;
                case 5: monthName = "May"; break;
                case 6: monthName = "June"; break;
                case 7: monthName = "July"; break;
                case 8: monthName = "August"; break;
                case 9: monthName = "September"; break;
                case 10: monthName = "October"; break;
                case 11: monthName = "November"; break;
                case 12: monthName = "December"; break;
                default: monthName = ""; break;
            }
            return monthName;
        }

        public string MakeFilepath(string year, string cmonth, string monthName)
        {
            string filePath = "./出費/" + year + "年/"  + cmonth + "." + monthName + ".txt";

            return filePath;
        }

        public string MakeDirectoryPath(string year)
        {
            string directoryPath = "./出費/ソート後/" + year + "年";
            return directoryPath;
        }

        public string MakeCopypath(string year, string cmonth, string monthName)
        {
            string filePath = "./出費/ソート後/" + year + "年/" + cmonth + "." + monthName + "_soted.txt";
            return filePath;
        }
    }
}