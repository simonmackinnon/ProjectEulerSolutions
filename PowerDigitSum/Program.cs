using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace PowerDigitSum
{
    class PowerDigitSum
    {
        static void Main(string[] args)
        {
            BigInteger largeNum = BigInteger.Pow(2, 1000);

            BigInteger sumOfDigits = 0;

            string largeNumAsString = largeNum.ToString();

            foreach (char c in largeNumAsString)
            {
                sumOfDigits += c - 48;
            }

            Console.WriteLine("Sum of digits of result from 2^1000: " );
            Console.WriteLine(sumOfDigits.ToString());

        }
    }
}
