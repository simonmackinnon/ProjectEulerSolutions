#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main()
{
    int a = 0;
    int b = 0;
    int found = 0;

    long cSquared;
    float c;

    for(a = 1; a < 1000; a++)
    {
        for(b = 1; b < 1000; b++)
        {
            cSquared = (a*a)+(b*b);
            c = sqrt((float)cSquared);

            if(a+b+c == 1000)
            {
                found = 1;
                break;

            }


        }
        if(found != 0)
        {
            break;
        }
    }

    printf("Pythagorean Triplet you are looking for is %d, %d, %f", a,b,c);

    return 0;
}
