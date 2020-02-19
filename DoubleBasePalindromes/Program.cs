using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
* 
* The decimal number, 585 = 10010010012 (binary), is palindromic in both bases.                
*  Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.
*  (Please note that the palindromic number, in either base, may not include leading zeros.)
*/

namespace DoubleBasePalindromes
{
    class CDoubleBasePalindromes
    {
        static void Main(string[] args)
        {
            ulong sum = 0;

            for (int i = 0; i < 1000000; i++)
            {
                if (isPalindromic(intToCharArray(i)) && isPalindromic(intToBinaryCharArray(i)))
                {
                    sum += (ulong)i;
                }
            }

            Console.WriteLine("Sum: {0}", sum);
        }

        private static bool isPalindromic(char[] chArr)
        {
            bool isPalindrome = true;

            if (chArr.Length == 1)
            {
                return true;
            }

            for (int i = 0; i < chArr.Length / 2; i++)
            {
                if (chArr[i] != chArr[chArr.Length - i - 1])
                {
                    isPalindrome = false;
                    break;
                }
            }

            return isPalindrome;
        }

        private static char[] intToCharArray(int i)
        {
            return i.ToString().ToCharArray();
        }

        private static char[] intToBinaryCharArray(int i)
        {
            return Convert.ToString(i, 2).ToCharArray();
        }
    }
}
