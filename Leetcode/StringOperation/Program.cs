using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringOperation
{
    class Program
    {
        static void Main(string[] args)
        {

            StringDemo str = new StringDemo();
            DPProblems dp = new DPProblems();

            HashSet<string> wordDict = new HashSet<string>();
            wordDict.Add("cat");
            wordDict.Add("cats");
            wordDict.Add("and");
            wordDict.Add("sand");
            wordDict.Add("dog");
            //wordDict.Add("dog");

            dp.WordBreak("catsanddog", wordDict);
            //str.Multiply("63","20");
            str.LongestPalindrome("ccc");

            char c = '8';
            int t = c - '1';

            HashSet<int>[] cell = new HashSet<int>[9];

          
            for (int i = 0; i < 9; i++)
            {
                cell[i] = new HashSet<int>();              
            }          


            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    cell[3 * (i / 3) + j / 3].Add(j);
                }

            }
        }
    }
}
