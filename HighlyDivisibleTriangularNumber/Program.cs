using System;
using System.Collections.Generic;

namespace HighlyDivisibleTriangularNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = 1;
            int triangularNumber = 0;
            int numfactors = 2;

            while(true)
            {
                triangularNumber += index;

                var factors = Factor(triangularNumber);
                numfactors = factors.Count;

                if(numfactors > 500)
                {
                    break;
                }

                index++;
            }

            Console.WriteLine("triangularNumber: " + triangularNumber);
        }

        static List<int> Factor(int number) {
            List<int> factors = new List<int>();
            int max = (int)Math.Sqrt(number);  //round down
            for(int factor = 1; factor <= max; ++factor) { //test from 1 to the square root, or the int below it, inclusive.
                if(number % factor == 0) {
                    factors.Add(factor);
                    if(factor != number/factor) { // Don't add the square root twice!  Thanks Jon Skeet
                        factors.Add(number/factor);
                    }
                }
            }
            return factors;
        }
    }
}
