using System;
using System.Linq;

namespace PandigitalPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            int index = 0;
            int largest = 0;
            while (index <= 9854321)
            {
                if (IsPrime(index) && isNumberPandigital(index) && index > largest)
                {
                    largest = index;
                    Console.WriteLine("New Largest Pandigital Prime: {0}", largest);
                }
                index++;
            }
        }

        static bool isNumberPandigital(int number)
        {
            string numberString = number.ToString();
            return String.Concat(numberString.OrderBy(c => c)) == "123456789".Substring(0, numberString.Length); 
        }

        public static bool IsPrime(int candidate)
        {
            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }
            return candidate != 1;
        }
    }
}
