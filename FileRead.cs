using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Show;


namespace FileRead
{ 
    public class FileReader
    {
        Shower shower = new Shower();
        public void FileRead(string filePath, int[] costs, string[] items)
        {
            string[] texts = new string[costs.Length];
            int size = 0;
            FileStream fs = new FileStream(filePath,FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding(65001));
            Console.WriteLine("ソート前");
            while (null != (texts[size] = sr.ReadLine())) 
            {
                //texts[size++] = sr.ReadLine();
                Console.WriteLine(texts[size++]);
            }
            fs.Close();
            sr.Close();
            for(int i = 0; i < texts.Length; i++)
            {
                if(texts[i] == null)
                {
                    break;
                }

                string test =  Regex.Match(texts[i], @"\d+").Value;
                //Console.WriteLine(test);
                bool isSuccess = int.TryParse(test, out costs[i]);
                if(costs[i] == 0)
                {
                    //Console.WriteLine("終端です");
                    break;
                }
                if (isSuccess == true)
                {
                    //Console.WriteLine("文字列を変換しました：" + test);
                }
                else
                {
                    shower.ErrorMessage(2);
                    Console.WriteLine(test);
                }
                items[i] = Regex.Replace(texts[i], @"\d+", "");
            }
        }

        public void MakeDirectory(string filePath)
        {
            Directory.CreateDirectory(filePath);
        }

        public void FileWrite(string filePath, int[] costs, string[] items)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(65001));
            for(int i = 0; i < costs.Length; i++)
            {
                if(costs[i] == 0)
                {
                    break;
                }
                sw.WriteLine(costs[i] + items[i]);
            }
            sw.Close();
            fs.Close();
        }
    }
}