using System;
using System.Collections.Generic;

namespace DigitCancellingFractions
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> fractions = new Dictionary<int, int>();
            for (int num = 10; num <= 49; num++)
            {
                for (int den = 10; den <= 99; den++)
                {
                    if (num.ToString()[1] != '0' && den.ToString()[1] != '0' && num != den)   //exclude any trivial values
                    {
                        if ( num.ToString()[0] == den.ToString()[1])
                        {
                            double frac1 = (double)num / (double)den;
                            char a = num.ToString()[1];
                            char b = den.ToString()[0];
                            double frac2 = double.Parse(a.ToString()) / double.Parse(b.ToString());
                            if (frac1 == frac2)
                            {
                                fractions.Add(num, den);
                            }
                        }
                        else if ( num.ToString()[1] == den.ToString()[0])
                        {
                            double frac1 = (double)num / (double)den;
                            char a = num.ToString()[0];
                            char b = den.ToString()[1];
                            double frac2 = double.Parse(a.ToString()) / double.Parse(b.ToString());
                            if (frac1 == frac2)
                            {
                                fractions.Add(num, den);
                            }
                        }
                    }
                }
            }

            List<double> values = new List<double>();
            double product = 1;

            foreach (var fraction in fractions)
            {
                Console.WriteLine("Fraction: " + fraction);
                product *= ((double)(fraction.Key) / (double)(fraction.Value));
            }

            Console.WriteLine("Product: " + product);
            Console.WriteLine("LCD: " + 1/product);

        }


    }
}
