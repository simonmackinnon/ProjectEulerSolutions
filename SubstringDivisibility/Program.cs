using System;
using System.Collections.Generic;
using System.Linq;

namespace SubstringDivisibility
{
    class Program
    {
        private static long [] primes = new long[]{2,3,5,7,11,13,17};

        static void Main(string[] args)
        {
            long sum = 0;

            string sourceString = "0123456789";
            List<string> permutations = Permutate(sourceString).ToList();
            
            foreach (string str in permutations)
            {
                long num = long.Parse(str);
                if (num > 1000000000 && isNumberSubstringDivisible(str))
                {
                    sum += num;
                }
            }

            Console.WriteLine("Sum: {0}", sum);
        }
        
        private static IEnumerable<string> Permutate(string source)
        {
            if (source.Length == 1) return new List<string> { source };

            var permutations =  from c in source
                                from p in Permutate(new String(source.Where(x => x != c).ToArray()))
                                select c + p;

            return permutations;
        }

        static bool isNumberSubstringDivisible(string numberString)
        {
            
            
            for (int i = 1; i < 8; i++)
            {
                string dStr = numberString.Substring(i, 3);
                long d = long.Parse(dStr);

                if (d % primes[i-1] != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
