using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmicableNumbers
{
    class AmicableNumbers
    {
        static void Main(string[] args)
        {
            int[] d;
            d = new int[10000];

            int sumOfAmicableNums = 0;

            for(int i = 1; i < 10000; i++)
            {
                d[i] = sumOfProperDivisors(i);
            }

            for (int i = 1; i < 10000; i++)
            {
                for (int j = 1; j < 10000; j++)
                {
                    if ((d[i] == j) && (d[j] == i))
                    {
                        if (i == j)
                        {
                            continue;
                        }
                        sumOfAmicableNums += i;
                    }
                }  
            }

            Console.WriteLine("sumOfAmicableNums: " + sumOfAmicableNums);
        }

        private static int sumOfProperDivisors(int n)
        {
            int ret = 0;

            for (int i = 1; i < n; i++)
            {
                if (n % i == 0)
                {
                    ret += i;
                }
            }

            return ret;

        }
    }
}
