using System;
using System.Collections.Generic;
using System.Linq;

namespace CountingSundays
{
    class Program
    {
        static void Main(string[] args)
        {
            int year = 1900;
            int dayOfWeek = 1;
            int dayOfYear = 1;
            int count = 0;

            while (year < 2001) 
            {
                bool isLeap = year % 4 == 0;
                int numDaysInYear = isLeap ? 366 : 365;

                int Jan1Date = 1;
                int Feb1Date = Jan1Date + 31;
                int Mar1Date = isLeap ? Feb1Date + 29 : Feb1Date + 28;
                int Apr1Date = Mar1Date + 31;
                int May1Date = Apr1Date + 30;
                int Jun1Date = May1Date + 31;
                int Jul1Date = Jun1Date + 30;
                int Aug1Date = Jul1Date + 31;
                int Sep1Date = Aug1Date + 31;
                int Oct1Date = Sep1Date + 30;
                int Nov1Date = Oct1Date + 31;
                int Dec1Date = Nov1Date + 30;
                int Jan1NextDate = Dec1Date + 31;

                
                List<int> MonthFirstDates = new List<int>()
                {
                    Jan1Date, Feb1Date, Mar1Date, 
                    Apr1Date, May1Date, Jun1Date, 
                    Jul1Date, Aug1Date, Sep1Date, 
                    Oct1Date, Nov1Date, Dec1Date
                };

                while (dayOfYear < numDaysInYear)
                {
                    if (year != 1900 && MonthFirstDates.Contains(dayOfYear) && dayOfWeek == 0)
                    {
                        count++;
                    }

                    dayOfWeek++;

                    if (dayOfWeek > 6)
                        dayOfWeek = 0;

                    dayOfYear++;
                }

                dayOfYear = 1;
                year++;
            }

            Console.WriteLine("Count: " + count);

        }
    }
}
