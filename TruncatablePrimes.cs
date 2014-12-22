using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
* The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right,
*  and remain prime at each stage: 3797, 797, 97, and 7. Similarly we can work from right to left: 3797, 379, 37, and 3.
* Find the sum of the only eleven primes that are both truncatable from left to right and right to left.
* NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes. 
*/

namespace TruncatablePrimes
{
    class CTruncatablePrimes
    {
        static void Main(string[] args)
        {
            int count = 0;
            int number = 10;
            int sum = 0;

            while (count < 11)
            {
                bool isTruncatablePrime = true;

                if (isTruncatablePrime)
                {
                    int i = 1;
                    while (true)
                    {
                        int num = (int)Math.Pow(10, i);
                        int tmp = number % num;

                        if (!isPrime(tmp))
                        {
                            isTruncatablePrime = false;
                            break;
                        }

                        if (tmp == number)
                        {
                            break;
                        }

                        i++;
                    }
                }

                if (isTruncatablePrime)
                {
                    int i = 0;
                    while (true)
                    {
                        int tmp = number / (int)Math.Pow(10, i);

                        if (tmp == 0)
                        {
                            break;
                        }

                        if (!isPrime(tmp))
                        {
                            isTruncatablePrime = false;
                            break;
                        }

                        i++;
                    }

                }

                if (isTruncatablePrime)
                {
                    sum += number;
                    count++;
                }

                number++;
            }
        }

        private static bool isPrime(int num)
        {
            if (num <= 1)
            {
                return false;
            }
            for (int i = 2; i < num; i++)
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
