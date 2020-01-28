using System;
using System.Collections.Generic;
using System.Linq;

namespace LexicographicPermutations
{
    class Program
    {
        static void Main(string[] args)
        {
            string digits = "0123456789";
            int n = digits.Length; 
            List<string> list = new List<string>();
            PermuteString(digits, 0, n - 1,  ref list);
        }

        static string SwapChars(string a, int i, int j)
        {
            char temp; 
            char[] charArray = a.ToCharArray(); 
            temp = charArray[i]; 
            charArray[i] = charArray[j]; 
            charArray[j] = temp; 
            string s = new string(charArray); 
            return s;
        }

        static void PermuteString(String str, int l, int r, ref List<string> list)
        { 
            if (l == r) 
            {
                list.Add(str);
                int count = list.Count();
                Console.WriteLine(str + " count: " + count); 
                if (count >= 1010000)
                {
                    list.Sort(); 
                    string last = list.ElementAt(999999);
                    Console.WriteLine("the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9 is: " + last);
                    Console.Read();
                }
            } 
            else 
            { 
                for (int i = l; i <= r; i++) 
                { 
                    str = SwapChars(str, l, i); 
                    PermuteString(str, l + 1, r, ref list); 
                    str = SwapChars(str, l, i); 
                } 
            } 
        }
    }
}
