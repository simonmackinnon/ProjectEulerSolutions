using System;

namespace SpecialPythagoreanTriplet
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 0;
            int found = 0;

            long cSquared;
            double c = 0;

            for(a = 1; a < 1000; a++)
            {
                for(b = 1; b < 1000; b++)
                {
                    cSquared = (a*a)+(b*b);
                    c = Math.Sqrt((double)cSquared);

                    if(a+b+c == 1000)
                    {
                        found = 1;
                        break;

                    }


                }
                if(found != 0)
                {
                    break;
                }
            }

            Console.WriteLine("Pythagorean Triplet you are looking for is " + a + ", " + b + ", " + c);
            Console.WriteLine("Product abc " + a*b*c);
        }
    }
}
