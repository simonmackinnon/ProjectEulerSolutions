using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

// Problem 39
// If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, there are exactly three solutions for p = 120.
// {20,48,52}, {24,45,51}, {30,40,50}
// For which value of p ≤ 1000, is the number of solutions maximised?

namespace IntegerRightTriangles
{
    class CIntegerRightTriangles
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();            
            
            List<IntegerRightTriangle> perimeterValues = new List<IntegerRightTriangle>();

            // We know that a+b>c, otherwise the edges would not join to form a triangle. 
            // Adding c to both sides gives, a+b+c>2c, and as a+b+c<=1000, 2c<=1000, hence 
            // c<=500. Because c is the longest side, a<500, so it is only necessary for 
            // the loop to run so far.
            for (int a = 1; a < 500; a++)
            {
                for (int b = 1; b < 500; b++)
                {
                    double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                    if (c % 1 == 0)
                    {
                        int p = a + b + (int)c;
                        if (p <= 1000)
                        {
                            perimeterValues.Add(new IntegerRightTriangle(a,b,(int)c, p));
                        }                        
                    }
                }
            }

            perimeterValues.Sort();

            int maximisedPVal = 0;
            int maximumSolutions = 0;

            for (int i = 0; i < perimeterValues.Count-2; i++)
            {
                IntegerRightTriangle currentTriag = perimeterValues.ElementAt(i);
                int numSolutions = 1;
                while (true)
                {
                    IntegerRightTriangle jumpTriag = perimeterValues.ElementAt(i+numSolutions);
                    if (currentTriag.p == jumpTriag.p)
                    {
                        if (    (currentTriag.a != jumpTriag.b) &&
                                (currentTriag.a != jumpTriag.c) &&
                                (currentTriag.b != jumpTriag.c))
                        {
                            numSolutions++;
                        }
                        else
                        {
                            break;
                        }

                        if (numSolutions > maximumSolutions)
                        {
                            maximisedPVal = currentTriag.p;
                            maximumSolutions = numSolutions;
                        }

                    }
                    else
                    {
                        break;
                    }
                }
            }
            sw.Stop();
            Console.WriteLine("Total time (ms): {0}", (long)sw.ElapsedMilliseconds);
        
        }
    }

    class IntegerRightTriangle : IComparable
    {
        public int a;
        public int b;
        public int c;
        public int p;

        public IntegerRightTriangle(int a, int b, int c, int p)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.p = p;
        }

        // Implement IComparable CompareTo to provide default sort order.
        int IComparable.CompareTo(object obj)
        {
            IntegerRightTriangle t = (IntegerRightTriangle)obj;
            
            if (this.p > t.p)
                return 1;

            if (this.p < t.p)
                return -1;

            else
                return 0;
        }

    }

}
