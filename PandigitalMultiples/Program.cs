using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace PandigitalMultiples
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = 2;
            long largest = 0;
            while (number <= 98543)
            {
                //Console.WriteLine("Checking: {0}", number);
                List<long> nums = new List<long>();
                nums.Add(number);
                for (long i = 2; i < 9; i++)
                {
                    nums.Add(number*i);
                    var strings = from j in nums
                        select j.ToString();

                    string numberString = String.Join("", strings);
                    //Console.WriteLine("numberString: {0}", numberString);
                    
                    if (isNumberNineDigitPandigital(numberString))
                    {
                        largest = Math.Max(long.Parse(numberString), largest);
                        Console.WriteLine("New Largest: {0}", largest);
                    }
                }
                number++;
            }
            Console.WriteLine("Largest: {0}", largest);
        }

        static bool isNumberNineDigitPandigital(string numberString)
        {
            return String.Concat(numberString.OrderBy(c => c)) == "123456789";
        }

    }
}
