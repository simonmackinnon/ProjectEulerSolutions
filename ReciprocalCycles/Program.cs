using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Numerics;

namespace ReciprocalCycles
{
    class Program
    {
        static void Main(string[] args)
        {
            int den = 0;
            string cyc = "";

            for (int i = 1; i < 1000; i++)
            {
                BigInteger denI = new BigInteger(i);
                BigInteger val = 
                    BigInteger.Parse("100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000")/denI;

                string str = val.ToString().Replace(".", string.Empty);
                Console.WriteLine("str: " + str);
                
                string currentLongestCycle = longestCycle(str);
                while (true)
                {
                    string recuced = longestCycle(currentLongestCycle);
                    if (currentLongestCycle.Length == recuced.Length)
                    {
                        break;
                    }
                }
                
                if (currentLongestCycle.Length > cyc.Length) 
                {
                    den = i;
                    cyc = currentLongestCycle;

                    Console.WriteLine("New longest recurring cycle denominator: " + den + " cycle: " + cyc);
                    Console.Read();
                }
      
            }

            Console.WriteLine("longest recurring cycle denominator: " + den + " cycle: " + cyc);
        }

        static string longestCycle(string str) 
        {
            string currentLongestCycle = "";
            string remStr = "";
            
            for (int j = 0; j < str.Length; j++)
            {
                remStr = str.Substring(j);

                for (int k = 0; k < remStr.Length; k++)
                {
                    string checkStr = remStr.Substring(0,k);
                    int occurs = Regex.Matches(remStr, checkStr).Count;

                    if (occurs > 1 && currentLongestCycle.Length < checkStr.Length) // substring repeats
                    {
                        if (checkStr.Replace(checkStr.First().ToString(),"").Length != 0)
                        {
                            currentLongestCycle = checkStr;
                            break;
                        }
                    }

                    if (currentLongestCycle != string.Empty && remStr.Replace(currentLongestCycle,"").Length < 2)
                    {
                        break;
                    }
                }
                if (currentLongestCycle != string.Empty && remStr.Replace(currentLongestCycle,"").Length < 2)
                {
                    break;
                }
            }

            return currentLongestCycle;
        }
    }
}
