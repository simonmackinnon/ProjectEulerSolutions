using System;

namespace _10001stPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = 0;
            long number = 1;

            while(true)
            {
                number++;
                if(isPrime(number))
                {
                    index++;
                }

                if(index == 10001)
                {
                    break;
                }
            }

            Console.WriteLine("10001st Prime Number: " + number);
        }

        static bool isPrime(long lNumerator)
        {
            long lDivisor;
            for (lDivisor = 2; lDivisor <= lNumerator - 1; lDivisor++)
            {
            if (lNumerator % lDivisor == 0 )return false;
            }
            if (lDivisor == lNumerator) return true;

            return true;
        }
    }
}
