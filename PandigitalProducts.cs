using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandigitalProducts
{
    class CPandigitalProducts
    {
        static void Main(string[] args)
        {
            List<int> aList = new List<int>();
            List<int> bList = new List<int>();
            List<int> productList = new List<int>();

            for (int a = 1; a < 9999; a++)
            {
                for (int b = 1; b < 9999; b++)
                {
                    string strA = a.ToString();
                    string strB = b.ToString();

                    if(strA.Length + strB.Length > 8)
                    {
                        continue;
                    }
                    
                    int product = a * b;                    
                    string strProduct = product.ToString();

                    //Quickest To Evaluate sum of lengths of strings first
                    if(strA.Length + strB.Length + strProduct.Length != 9)
                    {
                        continue;
                    }

                    string strConcat = strA + strB + strProduct;

                    char[] charArray = strConcat.ToCharArray();

                    Array.Sort<char>(charArray);
                    bool isOkay = true;
                    for (int i = 1; i <= 9; i++)
                    {
                        if (charArray[i-1] != (i + 48))
                        {
                            isOkay = false;
                        }
                    }

                    if (isOkay)
                    {
                        bool alreadyInList = false;
                        for (int i = 0; i < productList.Count; i++ )
                        {
                            if (productList[i] == product)
                            {
                     //           if (aList[i] == b && bList[i] == a)
                     //           {
                                    alreadyInList = true;
                                    break;
                     //           }
                            }
                        }

                        if (!alreadyInList)
                        {
                            Console.WriteLine("New Values {0} * {1} = {2}", a, b, product);

                            aList.Add(a);
                            bList.Add(b);
                            productList.Add(product);
                        }                        
                    }

                }
            }

            ulong sumOfProducts = 0;
            foreach (int j in productList)
            {
                sumOfProducts += (ulong)j;
            }

        }
    }
}
