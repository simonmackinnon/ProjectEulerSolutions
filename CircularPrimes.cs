using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.
// There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.
// How many circular primes are there below one million?

namespace CircularPrimes
{
    class CCircularPrimes
    {
        static void Main(string[] args)
        {
            int num = 3;
            int count = 1;

            while (num < 1000000)
            {
                if (num % 2 == 0)
                {
                    num++;
                    continue;
                }

                int numDigits = getNumDigits(num);
                int tmp;

                bool isCircularPrime = true;
                for (int i = 0; i < numDigits; i++)
                {
                    tmp = rotateIntByNumDigits(num, i);
                    if (!isPrime(tmp))
                    {
                        isCircularPrime = false;
                        break;
                    }
                }

                if (isCircularPrime)
                {
                    Console.WriteLine("Found Circular Prime: {0}", num);
                    count++;
                }

                num++;
            }
        }

        private static int rotateIntByNumDigits(int num, int by)
        {
            if (by == 0)
            {
                return num;
            }

            int rotatedNum ;
            int rightMostDigit = num % 10;

            rotatedNum = num / 10;
            rotatedNum += (rightMostDigit * (int)Math.Pow(10, getNumDigits(num)-1));

            if (by == 1)
            {
                return rotatedNum;
            }                
            else
            {
                return rotateIntByNumDigits(rotatedNum, by - 1);
            }
        }

        private static int getNumDigits(int num)
        {
            int i = 0;
            while (true)
            {
                int tmp = num / (int)Math.Pow(10, i);
                if (tmp == 0)
                    break;
                i++;
            }

            return i;
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
