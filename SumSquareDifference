#include <stdio.h>
#include <stdlib.h>

int main()
{
    long diff = 0;
    long sum = 0;
    long sumSquared = 0;
    long squareOfSum = 0;

    int counter = 0;

    for(counter = 1; counter <= 100; counter++)
    {
        sum += counter;
    }

    sumSquared = sum * sum;

    sum = 0;

    for(counter = 1; counter <= 100; counter++)
    {
        sum += (counter*counter);
    }
    squareOfSum = sum;



    printf("difference = %ld", squareOfSum - sumSquared);
    return 0;
}
