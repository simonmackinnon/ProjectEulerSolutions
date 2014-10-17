
#include <stdio.h>
#include <stdlib.h>

#define MAX_TERMS 100

int main()
{
    unsigned long terms[MAX_TERMS];
    unsigned long sum = 2;
    int i = 0;

    terms[0] = 1;
    terms[1] = 2;

    for(i=2; i < MAX_TERMS; i++)
    {
        terms[i] = terms[i-1]+terms[i-2];

        if(terms[i] >= 4000000)
            break;

        if(terms[i]%2==0)
        {
            sum += terms[i];
        }
    }

    printf("SUM = %lu", sum);

    return 0;
}
