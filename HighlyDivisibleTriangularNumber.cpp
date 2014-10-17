#include <stdio.h>
#include <stdlib.h>

int main()
{
    long index = 1;
    long triangularNumber = 0;
    int numfactors = 2;

    long i = 0;

    while(1)
    {

        numfactors = 2;
        triangularNumber += index;

        for(i = 2; i <= triangularNumber/2; i++)
        {
            if(triangularNumber % i == 0)
            {
                numfactors++;
                if(numfactors > 500)
                {
                    break;
                }
            }
        }

        if(numfactors > 500)
        {
            break;
        }

        index++;

    }

    printf("%ld", triangularNumber); //76576500

    return 0;
}



