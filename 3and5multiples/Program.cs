using System;

namespace _3and5multiples
{
    class Program
    {
        static void Main(string[] args)
        {

            long sum = 0;
            int i = 0;

            for(i=0; i< 1000; i++)
            {
                if((i%3==0)||(i%5==0))
                {
                    sum += i;
                }

            }

            Console.WriteLine("Sum = " + sum);         
        }
    }
}
