using System;

namespace SmallestMultiple
{
    class Program
    {
        static void Main(string[] args)
        {
            long theNumber = 0;
            int i;

            while(true)
            {
                theNumber += 2520;

                for(i = 19; i >= 2; i--)
                {
                    if(theNumber % i != 0)
                    {
                        break;
                    }
                }

                Console.WriteLine("got to " + i + " before break");

                if(i < 2)
                {
                    break;
                }
            }
            Console.WriteLine("Smallest multiple: " + theNumber);
        }
    }
}
