using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LongestCollatzSequence
{
    class CLongestCollatzSequence
    {
        static void Main(string[] args)
        {
            const int number = 1000000;
            
            long sequence;
            long longestLength = 0;
            long longestChainStart = 0;

            for (int i = 2; i < number; i++)
            {
                int length = 1;

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
                    length++;
                }

                if (length > longestLength)
                {
                    longestLength = length;
                    longestChainStart = i;
                }
            }

            Console.WriteLine("Longest Chain starts at: {0} and is {2} elements long!" , longestChainStart, longestLength);
            Console.WriteLine(); 
        }
    }
}
