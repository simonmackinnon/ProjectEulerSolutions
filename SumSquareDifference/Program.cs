using System;

namespace SumSquareDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            long sum = 0;
            long sumSquared = 0;
            long squareOfSum = 0;

            int counter = 0;

            for(counter = 1; counter <= 100; counter++)
            {
                sum += counter;
            }

            sumSquared = sum * sum;

            sum = 0;

            for(counter = 1; counter <= 100; counter++)
            {
                sum += (counter*counter);
            }
            squareOfSum = sum;

            Console.WriteLine("difference = " + (squareOfSum - sumSquared).ToString());
        }
    }
}
