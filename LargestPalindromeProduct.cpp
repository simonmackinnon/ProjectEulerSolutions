#include <iostream>
#include <stdio.h>

using namespace std;

int main()
{
    long num = 0;

    long i = 0;
    long j = 0;

    long iOf = 0;
    long jOf = 0;

    int n = 20;

    char buffer [10];

    for(i = 999; i >= 100; i--)
    {
        for(j = 999; j >= 100; j--)
        {
            n = sprintf(buffer, "%ld", i*j);
            if(n == 4)
            {
                if((buffer[3] == buffer[0])&&(buffer[2] == buffer[1]))
                {
                    if(i*j > num)
                    {
                        num = i*j;
                        iOf = i;
                        jOf = j;
                    }


                }

            }
            else if(n == 5)
            {
                if((buffer[4] == buffer[0])&&(buffer[3] == buffer[1]))
                {
                    if(i*j > num)
                    {
                        num = i*j;
                        iOf = i;
                        jOf = j;
                    }
                }
            }
            else if(n == 6)
            {
                if((buffer[5] == buffer[0])&&(buffer[4] == buffer[1])&&(buffer[3] == buffer[2]))
                {
                    if(i*j > num)
                    {
                        num = i*j;
                        iOf = i;
                        jOf = j;
                    }
                }
            }
        }
    }



    cout << "Number = " << num << endl;
    cout << "i = " << iOf << ", j = " << jOf << endl;

    return 0;
}
