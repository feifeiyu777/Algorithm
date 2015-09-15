using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringOperation
{
    public class StringDemo
    {
        #region Simplify path
        public string simplifyPath(string path)
        {
            string result = "/";
            string[] stubs = path.Split(new char[] { '/' });

            List<string> paths = new List<String>();

            foreach (string s in stubs)
            {
                if (s.Equals(".."))
                {
                    if (paths.Count > 0)
                    {
                        paths.RemoveAt(paths.Count - 1);
                    }
                }
                else if (!s.Equals(".") && !s.Equals(""))
                {
                    paths.Add(s);
                }
            }
            foreach (string s in paths)
            {
                result += s + "/";
            }
            if (result.Length > 1)
                result = result.Substring(0, result.Length - 1);
            return result;
        }
        #endregion

        #region Multiply
        public string Multiply(string num1, string num2)
        {
            if (num1.Length == 0 || num2.Length == 0)
            {
                return "";
            }

            int len1 = num1.Length;
            int len2 = num2.Length;
            int len = len1 + len2;
            int[] mul = new int[len];
            for (int i = len1 - 1; i >= 0; i--)
            {
                int a = num1[i] - '0';
                int k = len2 + i;
                for (int j = len2 - 1; j >= 0; j--)
                {
                    int b = num2[j] - '0';
                    int c = mul[k] + a * b;
                    mul[k] = c % 10;
                    mul[k - 1] = mul[k - 1] + c / 10;
                    k--;
                }
            }

            int ind = 0;
            while (mul[ind] == 0 && ind < len - 1)
            {
                ind++;
            }
            StringBuilder sb = new StringBuilder();
            for (; ind < len; ind++)
                sb.Append(mul[ind]);
            return sb.Length == 0 ? "0" : sb.ToString();
        }
        #endregion

        #region Longest Substring Without Repeating Characters
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0 || s == null)
            {
                return 0;
            }

            HashSet<char> set = new HashSet<char>();
            int fast = 0;
            int slow = 0;
            int max = 0;
            for (fast = 0; fast < s.Length; fast++)
            {
                if (set.Contains(s[fast]))
                {
                    //when case abcdaefghd, just slow++,just the fist a, bcdaefghd
                    while (slow < fast && s[slow] != s[fast])
                    {
                        //remove when case abcddefthg
                        set.Remove(s[slow]);
                        slow++;
                    }
                    slow++;
                }
                else
                {
                    set.Add(s[fast]);
                    max = Math.Max(fast - slow + 1, max);
                }
            }

            return max;

        }
        #endregion

        #region Longest Palindrome
        public string LongestPalindrome(string s)
        {
            if (s.Length == 0 || s == null)
            {
                return "";
            }

            bool[,] dp = new bool[s.Length, s.Length];

            //record the longest substring
            int start = 0;
            int end = 0;
            int maxL = 0;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    //determine if palindrome
                    dp[j, i] = (s[j] == s[i] && (i - j < 2 || dp[j + 1, i - 1]));

                    //Max length must be less than length of string
                    if (dp[j, i] && maxL < i - j + 1)
                    {
                        maxL = i - j + 1;
                        start = j;
                        end = i;
                    }
                }
                //careful with this case, each char is palindroem
                dp[i, i] = true;
            }

            return s.Substring(start, end - start + 1);
        }

        #endregion
    }
}
