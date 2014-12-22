using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuadraticPrimes
{
    class CQuadraticPrimes
    {
        static void Main(string[] args)
        {
            int numOfConseqPrimes = 0;
            int aOfLongest = 1;
            int bOfLongest = 1;

            const int number = 1000;
            const int lowNumber = -999;

            for (int a = lowNumber; a <= number; a++)
            {
                for (int b = lowNumber; b <= number; b++)
                {
                    int n = 0;
                    int currentNumOfConseqPrimes = 0;
                    while(true)
                    {
                        int result = (int)Math.Pow(n, 2) + (a * n) + b;

                        if (isPrime(result))
                        {
                            currentNumOfConseqPrimes++;
                        }
                        else
                        {
                            break;
                        }

                        if (currentNumOfConseqPrimes > numOfConseqPrimes)
                        {
                            numOfConseqPrimes = currentNumOfConseqPrimes;
                            aOfLongest = a;
                            bOfLongest = b;
                        }
                        n++;
                    }
                    
                }
            }
        }

        private static bool isPrime(int num)
        {
            if (num <= 1)
            {
                return false;   
            }
            else
            {
                for (int i = 2; i < num/2; i++)
                {
                    if (num % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            
        }
    }
}
