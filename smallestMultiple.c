#include <stdio.h>
#include <stdlib.h>

int main()
{
    long theNumber = 0;
    int i;

    while(1)
    {
        theNumber += 2520;

        for(i = 19; i >= 2; i--)
        {
            if(theNumber % i != 0)
            {
                break;
            }
        }

        printf("\ngot to %d before break", i);

        if(i < 2)
        {
            break;
        }
    }

    printf("Smallest multiple %ld", theNumber);
    return 0;
}
