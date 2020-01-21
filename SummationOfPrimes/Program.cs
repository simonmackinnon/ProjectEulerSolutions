using System;

namespace SummationOfPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 17; //sum of 2+3+5+7
            int number = 11; 

            while(number < 2000000)
            {
                if(isPrime(number))
                {
                    Console.WriteLine(number + " is prime");
                    sum+=number;
                }
                number+=2;
            }
            Console.WriteLine("Sum of primes below 2M: " + sum);
        }

        static bool isPrime(int num)
        {
            int c;
            for ( c = 3 ; c <= num - 1 ; c+=2 )
            {
                if ( num%c == 0 )return false;
            }
            if ( c == num ) return true;

            return true;
        }

    }
}
