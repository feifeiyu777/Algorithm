using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringOperation
{
    public class DPProblems
    {
        #region Workd break
        public List<string> WordBreak(string s, ISet<string> wordDict)
        {
            List<string> ret = new List<string>();
            if (s == null || s.Length == 0 || wordDict == null)
            {
                return ret;
            }

            bool[] canBreak = CanBreak(s, wordDict);
            List<string> list = new List<string>();

            WordBreakDFS(s, wordDict, ret, list, 0, s.Length, canBreak);

            return ret;
        }

        private void WordBreakDFS(string s, ISet<string> wordDict, List<string> ret, List<string> list, int index, int len, bool[] canBreak)
        {
            if (!canBreak[index])
            {
                return;
            }

            //to the end of string
            if (index == len)
            {
                StringBuilder sb = new StringBuilder();
                foreach (string item in list)
                {
                    sb.Append(item);
                    sb.Append(" ");
                }

                sb = sb.Remove(sb.Length - 1, 1);
                ret.Add(sb.ToString());
            }

            for (int i = index; i < s.Length; i++)
            {
                string sub = s.Substring(index, i - index + 1);
                if (!wordDict.Contains(sub))
                {
                    continue;
                }

                list.Add(sub);
                WordBreakDFS(s, wordDict, ret, list, i + 1, len, canBreak);
                list.RemoveAt(list.Count - 1);
            }

        }

        private bool[] CanBreak(string s, ISet<string> wordDict)
        {
            bool[] dp = new bool[s.Length + 1];
            int len = s.Length;
            dp[len] = true;

            for (int i = len - 1; i >= 0; i--)
            {
                for (int j = i; j <= len - 1; j++)
                {
                    // 左边从i 到 j
                    dp[i] = false;
                    string sub = s.Substring(i, j - i + 1);
                    if (dp[j + 1] && wordDict.Contains(sub))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp;
        }
        #endregion



    }
}
