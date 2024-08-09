using System;

namespace Show{
    public class Shower
    {
        public string SearchYear()
        {
            Console.Write("調べる年は? :>");
            string year = Console.ReadLine();
            return year;
        }

        public string SearchMonth()
        {
            Console.Write("調べる月は? :>");
            string month = Console.ReadLine();
            return month;
        }

        public void ShowResult(int[] copyCosts, string[] copyItems, int sumcost)
        {
            Console.WriteLine("\nソート後");
            int num_of_items = 0;
            for (int i = 0; i < copyCosts.Length; i++)
            {
                if (copyCosts[i] == 0)
                {
                    break;
                }
                Console.WriteLine("[" + (i + 1) + "]" + copyCosts[i] + copyItems[i]);
                num_of_items++;
            }
            Console.WriteLine("出費合計は" + num_of_items + "点で" + sumcost + "円です");
        }

        public void ErrorMessage(int number)
        {
            switch (number)
            {
                case 2: Console.WriteLine("エラー2 :文字列を数値に変換できませんでした"); break;
                case 1 :Console.WriteLine("エラー1 :パスを作成できませんでした"); break;
                default:Console.WriteLine("もう一度やり直してください"); break;
            }
        }

        public bool AskReturn()
        {
            string answer;
            bool isRetry = false;
            Console.Write("もう一度読み込みますか?(はい(y)/いいえ(n)) :>");
            answer = Console.ReadLine();
            if(answer == "y")
            {
                isRetry = true;
            }
            else if(answer == "n")
            {
                isRetry = false;
            }
            else
            {
                Console.WriteLine("もう一度入力してください");
                AskReturn();
            }
            return isRetry;
        }
    }
}