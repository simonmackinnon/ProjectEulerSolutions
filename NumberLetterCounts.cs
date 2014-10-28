using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberLetterCounts
{
    class CNumberLetterCounts
    {
        static void Main(string[] args)
        {
            long letterCount = 0;

            for (int i = 1; i < 1000; i++)
            {
                int countForCurrentNumber = 0;

                if ((i > 100) && (i%100 != 0))
                {
                    //add and for numbers > 100
                    countForCurrentNumber += 3;
                }

                switch (i / 100)
                {
                    case 1:
                    case 2:
                    case 6:
                        countForCurrentNumber += 10;
                        break;
                    case 3:
                    case 7:
                    case 8:
                        countForCurrentNumber += 12;
                        break;
                    case 4:
                    case 5:
                    case 9:
                        countForCurrentNumber += 11;
                        break;
                    default:
                        break;
                }

                switch((i % 100) / 10)
                {
                    case 2:
                    case 3: 
                    case 8:
                    case 9:
                        countForCurrentNumber += 6;
                        break;
                    case 4:
                    case 5:
                    case 6:
                        countForCurrentNumber += 5;
                        break;
                    case 7:
                        countForCurrentNumber += 7;
                        break;
                    case 1:
                        if (i % 100 == 10)
                        {
                            countForCurrentNumber += 3;
                        }
                        else if ((i % 100 == 11) || (i % 100 == 12))
                        {
                            countForCurrentNumber += 6;
                        }
                        else if ((i % 100 == 13) || (i % 100 == 18))
                        {
                            countForCurrentNumber += 8;
                        }
                        else if (i % 100 == 15)
                        {
                            countForCurrentNumber += 7;
                        }
                        else
                        {
                            countForCurrentNumber += 4;
                        }
                        break;
                    default:
                        break;
                }

                if(((i % 100 >= 10) && (i % 100 <= 13))
                    || (i % 100 == 15)
                    || (i % 100 == 18))
                {
                    letterCount += countForCurrentNumber;
                    Console.WriteLine("Number {0} has {1} letters", i, countForCurrentNumber);
                    continue;
                }

                switch(i % 10)
                {
                    case 1:
                    case 2:
                    case 6:
                        countForCurrentNumber += 3;
                        break;
                    case 3:
                    case 7:
                    case 8:
                        countForCurrentNumber += 5;
                        break;
                    case 4:
                    case 5:
                    case 9:                    
                        countForCurrentNumber += 4;
                        break;
                    default:
                        break;
                }

                letterCount += countForCurrentNumber;
                Console.WriteLine("Number {0} has {1} letters", i, countForCurrentNumber);
            
}

            //Add for 1000 "onethousand"

            letterCount += 11;

        }
    }
}
