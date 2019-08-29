using System;

namespace LargestPalindromeProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            int iOf = 0;
            int jOf = 0;

            for (int i = 100; i < 1000; i++) {
                for (int j = 100; j < 1000; j++) {
                    int current = i*j;
                    
                    if (isPalindromic(current) && current > result) {
                        result = current;
                        iOf = i;
                        jOf = j;
                    }
                }
            }

            Console.WriteLine("Result = " + result);
        }

        static bool isPalindromic(int n)
        {
            string s = n.ToString();
            char[] charArray = s.ToCharArray();
            Array.Reverse( charArray );
            string r = new string ( charArray );
            return s == r;
        }
    }
}
