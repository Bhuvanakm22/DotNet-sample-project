using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMSMQMsgConsoleApp
{
    internal class SampleCodeProjects
    {
        private string _projectName;
        public string ProjectName
        {

            get
            {
                return _projectName; 
            }
            set
            {
                _projectName = value;
            }
        }
        //With loops and return string
        public static string IsPalindrome1(string str)
        {
            string FinalStr = string.Empty;
            int strLength= str.Length;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i]!= str[strLength-i-1])
                {
                    return "";
                }
                else
                {
                    FinalStr += str[strLength - i - 1];
                }
            }
            Console.WriteLine(FinalStr);
                return FinalStr;
        }
        //With no loops
        public bool IsPalindrome2(string input)
        {
            bool ResPalindrome= false;
            string LeftHandString = input.Substring(0, input.Length / 2);
            char[] ArrayString = input.ToCharArray();
            Array.Reverse(ArrayString);
            string ReversedString = new string(ArrayString);
            string RightHandString= ReversedString.Substring(0, ReversedString.Length/2);
            ResPalindrome = (LeftHandString == RightHandString) ? true : false;
            return ResPalindrome;
        }
        public static bool IsPalindrome3(string value)
        {
            int i = 0;
            int j = value.Length - 1;
            while (true)
            {
                if (i > j)
                {
                    return true;
                }
                char a = value[i];
                char b = value[j];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                i++;
                j--;
            }
        }
 
            
    }
    public class Solution
    {
        public string LongestPalindrome_Traditional(string s)
        {
            //ex s=babab
            int oddstring;
            int evenstring;
            int start = 0, end = 0;
           // int[] leftRightPosition = new int[] { 0, 0 };
            try
            {
                for (int i = 0; i < s.Length; i++)
                {
                    Console.WriteLine("Loop Start:------------" + i);
                    // Expand around single character as center
                    oddstring = ExpandAroundCenter(s, i, i);
                    if (oddstring > end - start + 1)
                    {
                        int middleposition = oddstring / 2;
                        start = i - middleposition;
                        end = i + middleposition;
                    }
                    // Expand around two characters as center (for even-length palindromes)
                    evenstring = ExpandAroundCenter(s, i, i + 1);

                    if (evenstring > end - start + 1)
                    {
                        int middleposition = (evenstring / 2) - 1;
                        start = i - middleposition;
                        end = (i + middleposition) + 1;
                    }
                    Console.WriteLine("oddstring:" + oddstring + " ,evenstring: " + evenstring);
                }
                
                return s.Substring(start, end - start + 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
            int ExpandAroundCenter(string s, int i, int j)
            {
                int left = i;
                int right = j;
                Console.WriteLine(i + " : " + j);
                while (left >= 0 && right < s.Length && s[left] == s[right])
                {
                    left--;
                    right++;
                    Console.WriteLine("left:" + left + " ,right: " + right);
                }
                Console.WriteLine("left:" + left + " ,right: " + right);
                // Return the length of the palindrome
                return right - left - 1;
            }
        }
        private string LongestPalindrome_Optimized(string s)
        {
            if (s.Length == 1)
                return s;

            int palindromeStart = 0;
            int palindromeLength = 1;

            for (int i = s.Length / 2; i < s.Length; i++)
            {
                ExpandFromLeft(i);
                ExpandFromLeft(s.Length - 1 - i);
            }

            void ExpandFromLeft(int left)
            {
                if (left < 0 || left + 1 >= s.Length)
                    return;

                if (s[left] == s[left + 1])
                    Expand(left, 2);

                if (left + 2 < s.Length && s[left] == s[left + 2])
                    Expand(left, 3);
            }

            void Expand(int start, int length)
            {
                int maxOneSidedGrowth = Math.Min(start, s.Length - start - length);

                if ((maxOneSidedGrowth * 2) + length <= palindromeLength)
                    return;

                int left = start - 1;
                int right = start + length;

                while (left >= 0 && right < s.Length && s[left] == s[right])
                {
                    start--;
                    length += 2;

                    left--;
                    right++;
                }

                if (length > palindromeLength)
                {
                    palindromeStart = start;
                    palindromeLength = length;
                }
            }

            return s.Substring(palindromeStart, palindromeLength);
        }
        public int LengthOfLongestSubstring(string s)
            {
                int result = 0;
                int i = 0;
                int j = 0;
                Hashtable hashtable = new Hashtable();                
                while (j < s.Length)
                {
                var ss = hashtable[s[j]];
                if (hashtable.ContainsKey(s[j]))
                {
                    i = Math.Max(Convert.ToInt32(hashtable[s[j]]), i);
                }
                    hashtable[s[j]] = j + 1;
                    result = Math.Max(result, j - i + 1);
                    j++;
                }

                return result;
            }
        public int LengthOfLongestSubstring1(string s)
        {
            int[] chars = new int[128];
            int left = 0;
            int right = 0;
            int maxLength = 0;

            while (right < s.Length)
            {
                if (chars[s[right]] > left)
                {
                    left = chars[s[right]];
                }

                maxLength = Math.Max(right - left + 1, maxLength);
                chars[s[right]] = right + 1;
                right++;
            }

            return maxLength;
        }
    }
}
