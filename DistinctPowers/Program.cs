using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DistinctPowers
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<BigInteger> distinctPowers = new HashSet<BigInteger>();
            for (int a = 2; a <= 100; a++) 
            {
                for (int b = 2; b <= 100; b++) 
                {
                    distinctPowers.Add(new BigInteger(Math.Pow(a, b)));
                }
            }

            Console.WriteLine("Count of set: " + distinctPowers.Count);
        }
    }
}
