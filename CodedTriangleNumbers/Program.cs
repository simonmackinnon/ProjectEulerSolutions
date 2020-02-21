using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodedTriangleNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("words.txt");  

            var words_array = text.Replace("\"", string.Empty).Split(',');

            var words = new List<string>(words_array);

            int count = words.Where(x => IsWordTriangular(x)).Count();

            Console.WriteLine("Count of Triangular Words in file: {0}", count);
        }

        static bool IsWordTriangular(string word)
        {
            var word_chars = word.ToCharArray();
            int sum = 0;
            foreach (char c in word_chars)
            {
                int index = char.ToUpper(c) - 64;
                sum += index;
            }

            int currentTriagSeqNumber = 1;
            int jump = 2;
            while (sum >= currentTriagSeqNumber)
            {
                if (sum == currentTriagSeqNumber)
                {
                    return true;
                }
                currentTriagSeqNumber += jump;
                jump++;
            }
            return false;
        }
    }
}
