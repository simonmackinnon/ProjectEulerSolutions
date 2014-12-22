using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace DistinctPowers
{
    class CDistinctPowers
    {
        static void Main(string[] args)
        {
            List<BigInteger> list = new List<BigInteger>();

            for (int a = 2; a <= 100; a++)
            {
                for (int b = 2; b <= 100; b++)
                {
                    BigInteger result = BigInteger.Pow(a, b);
                    if (!list.Contains(result))
                    {
                        list.Add(result);
                    }
                }
            }
        }
    }
}
