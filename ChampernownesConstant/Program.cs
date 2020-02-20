using System;
using System.Text;
using System.Numerics;

namespace ChampernownesConstant
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("", 1000000);
            int i = 1;
            while(sb.Length < 1000000)
            {
                sb.Append(i.ToString());
                i++;
            }

            int product = int.Parse(sb[0].ToString());
            int index = 999999;
            while(index > 0)
            {
                product *= int.Parse(sb[index].ToString());
                index /= 10;
            }

            Console.WriteLine("product: {0}", product);
        }
    }
}
