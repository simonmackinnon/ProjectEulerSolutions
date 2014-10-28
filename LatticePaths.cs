using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace LatticePaths
{
    class CLatticePaths
    {
        static void Main(string[] args)
        {
            const uint squareSideLength = 20;
            
            BigInteger noOfOptionsForGrid;
            
            uint set = squareSideLength * 2;
            uint choose = squareSideLength;

            BigInteger numerator = factorial(set);

            BigInteger denominator = BigInteger.Pow(factorial(choose), 2);

            noOfOptionsForGrid = BigInteger.Divide(numerator, denominator);

            Console.WriteLine("No. of routes in grid: {0}", noOfOptionsForGrid.ToString());
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
    }

}


