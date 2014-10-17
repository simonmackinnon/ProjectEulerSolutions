#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

bool isPrime(unsigned int num);

int main()
{
    long long sum = 0;
    long number = 2;

    while(number < 2000000)
    {
        if(isPrime(number))
        {
            printf("\n%ld", number);
            sum+=number;
        }
        number++;
    }


    return 0;
}


bool isPrime(unsigned int num)
{
    int c;
    for ( c = 2 ; c <= num - 1 ; c++ )
    {
      if ( num%c == 0 )return false;
    }
    if ( c == num ) return true;

    return true;
}
