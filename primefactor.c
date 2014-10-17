#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>


bool isPrime(unsigned int num);

int main()
{
    unsigned long long the_number = 600851475143;
    unsigned int factor = 2;
    unsigned int largest_prime_factor = 0;

    while(factor < sizeof(unsigned int))
    {
        if(isPrime(factor))
        {
            if(the_number % factor == 0)
            {
                largest_prime_factor = factor;
            }
        }
        factor++;
    }

    printf("Largest prime factor is %u", largest_prime_factor);

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
}
