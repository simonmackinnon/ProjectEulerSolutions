using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _1000DigitFibonacciNumber
{
    class C1000DigitFibonacciNumber
    {
        static void Main(string[] args)
        {
            BigInteger fiboNumberPrev = 0;
            BigInteger fiboNumber = 1;

            uint index = 1;

            while (true)
            {
                
                BigInteger temp = fiboNumber;
                fiboNumber = fiboNumberPrev + fiboNumber;
                fiboNumberPrev = temp;

                index++;

                if (fiboNumber.ToString().Length >= 1000)
                {
                    break;
                }
            }

        }
    }
}
