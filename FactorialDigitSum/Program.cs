using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace FactorialDigitSum
{
    class FactorialDigitSum
    {
        static void Main(string[] args)
        {
            BigInteger largeFactorial = factorial(100);

            BigInteger sum = sumOfDigitsInNumber(largeFactorial);

            Console.WriteLine("sum: " + sum);

        }

        private static BigInteger factorial(uint to, uint from = 1)
        {
            BigInteger ret = 1;

            for (uint i = from; i <= to; i++)
            {
                ret = BigInteger.Multiply(ret, i);
            }

            return ret;
        }

        private static BigInteger sumOfDigitsInNumber(BigInteger num)
        {
            BigInteger ret = 0;
            foreach (char c in num.ToString())
            {
                ret += c - 48;
            }
            return ret;
        }

    }
}
