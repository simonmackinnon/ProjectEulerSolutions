using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestCollatzSeq
{
    class Program
    {
        static void Main(string[] args)
        {
            const int number = 1000000;
            
            long sequence;
            long longestLength = 0;
            long longestChainStart = 0;

            Dictionary<long, long> sequenceLength = new Dictionary<long,long>();

            for (long i = 1; i < number; i++)
            {
                long length = 1;

                sequence = i;

                while (sequence != 1)
                {
                    if (sequence % 2 == 0)
                    {
                        sequence /= 2;
                    }
                    else
                    {
                        sequence *= 3;
                        sequence += 1;
                    }

                    if (sequenceLength.ContainsKey(sequence)) 
                    {
                        length += sequenceLength[sequence];
                        break;
                    }

                    length++;

                    
                }

                if (!sequenceLength.ContainsKey(sequence))
                {
                    sequenceLength.Add(sequence, length);   
                }
                

                if (length > longestLength)
                {
                    longestLength = length;
                    longestChainStart = i;
                }
            }

            Console.WriteLine("Longest Chain starts at: {0} and is {1} elements long!" , longestChainStart, longestLength);
            Console.WriteLine(); 
        }
    }
}
