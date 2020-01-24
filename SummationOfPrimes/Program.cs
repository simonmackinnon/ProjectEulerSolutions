using System;

namespace SummationOfPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            long sum = 0; 
            int number = 0; 

            while(number < 2000000)
            {
                if(PrimeTool.IsPrime(number))
                {
                    Console.WriteLine(number + " is prime");
                    sum+=number;
                }
                number++;
            }
            Console.WriteLine("Sum of primes below 2M: " + sum);
        }
    }
}
