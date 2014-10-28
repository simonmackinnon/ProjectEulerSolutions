using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NameScores
{
    class CNameScores
    {
        static void Main(string[] args)
        {         
            StreamReader streamReader = new StreamReader(@"C:\names.txt");
            string text = streamReader.ReadToEnd();
            streamReader.Close();

            text = text.Replace("\"", string.Empty);

            string[] words = text.Split(',');
            int[] nameScores = new int[words.Length];

            Quicksort(words, 0, words.Length - 1);

            for (int i = 0; i < words.Length; i++)
            {
                nameScores[i] = (i+1) * scoreForString(words[i]);
            }

            ulong total = 0;

            foreach (int i in nameScores)
            {
                total += (ulong)i;
            }

        }


        private static void Quicksort(IComparable[] elements, int left, int right)
        {
            int i = left, j = right;
            IComparable pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    IComparable tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                Quicksort(elements, left, j);
            }

            if (i < right)
            {
                Quicksort(elements, i, right);
            }
        }
        
        private static int scoreForString(string str)
        {
            int ret = 0;
            foreach (char c in str)
            {
                ret += c - 64;
            }
            return ret;
        }

    }
}
