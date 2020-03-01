using System;
using System.Collections.Generic;

namespace PentagonNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            const int maxNum = 25000000;

            Dictionary<int, int> PentagonNumbers = new Dictionary<int, int>();

            for (int n = 1; n <= maxNum; n++)
            {
                int pN = (n*(3*n-1))/2;
                PentagonNumbers.Add(n, pN);
            }

            int pJ = int.MaxValue;
            int pK = int.MaxValue;
            int D_min = int.MaxValue;

            for(int j = 1; j <= 5000; j++)
            {
                for(int k = 1; k <= 5000; k++)
                {
                    int D = Math.Abs(PentagonNumbers[k] - PentagonNumbers[j]);
                    int sum = PentagonNumbers[k] + PentagonNumbers[j];

                    Console.WriteLine("D: {0}, sum: {1}, P({2}): {3}, P({4}): {5}", D, sum, j, PentagonNumbers[j], k, PentagonNumbers[k]);

                    if (IsPentagonNumber(D) && IsPentagonNumber(sum) && D < D_min)
                    {
                        D_min = D;
                        pJ = PentagonNumbers[j];
                        pK = PentagonNumbers[k];

                    }
                }
            }
            
            Console.WriteLine("D_min: {0}, P(j): {1}, P(k): {2}", D_min, pJ, pK);
        }

        static bool IsPentagonNumber(int x) {
            var r = Math.Sqrt(1 + 24 * x);
            return r % 6 == 5;
        }


    }


}
