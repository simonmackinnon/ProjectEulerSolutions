using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DigitFifthPowers
{
    class CDigitFifthPowers
    {
        static void Main(string[] args)
        {
            int i = 10;
            int sumOfAll = 0;
            while (true)
            {
                string str = i.ToString();
                double sumOfDigitFithPowers = 0;
                for (int j = 0; j < str.Length; j++)
                {
                    sumOfDigitFithPowers += Math.Pow((str[j] - 48), 5);
                }
                if (sumOfDigitFithPowers == i)
                {
                    sumOfAll += (int)sumOfDigitFithPowers;
                }
                i++;
            }
        }
    }
}
