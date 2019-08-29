#include <stdio.h>
#include <stdlib.h>

#include <stdbool.h>


bool isPrime(long num);

int main()
{
    int index = 0;
    long number = 1;

    while(1)
    {
        number++;
        if(isPrime(number))
        {
            index++;
        }

        if(index == 10001)
        {
            break;
        }
    }


    printf("\n10001st Prime Number: %ld", number);
    return 0;
}


bool isPrime(long lNumerator)
{
    long lDivisor;
    for (lDivisor = 2; lDivisor <= lNumerator - 1; lDivisor++)
    {
      if (lNumerator % lDivisor == 0 )return false;
    }
    if (lDivisor == lNumerator) return true;

    return true;
}

