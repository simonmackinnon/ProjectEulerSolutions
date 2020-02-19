using System;
using System.Numerics;

namespace DigitFactorials
{
    class Program
    {
        static void Main(string[] args)
        {   
            BigInteger MaxDigitsNumber = 9999999;
            BigInteger sum = 0;

            for (int number = 3; number < MaxDigitsNumber; number++)
            {
                BigInteger local_number = number;

                BigInteger local_sum = 0;
                while (local_number > 0)
                {
                    local_sum += factorial(local_number % 10);
                    local_number /= 10;
                }

                if (local_sum == number)
                {
                    Console.WriteLine("found Digit Factorial: " + local_sum);
                    sum += local_sum;
                }
            }

            Console.WriteLine("sum: " + sum);
        }

        private static BigInteger factorial(BigInteger to)
        {
            BigInteger ret = 1;

            for (BigInteger i = 1; i <= to; i++)
            {
                ret = BigInteger.Multiply(ret, i);
            }

            return ret;
        }
    }
}
