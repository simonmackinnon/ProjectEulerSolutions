#include <stdio.h>
#include <stdlib.h>

int main()
{
    int i = 1;
    unsigned long long num = 1;
    int lengthOfFactorial = 0;
    int sum = 0;
    char buffer[100];

    for(i = 1; i <= 100; i++)
    {
        num *= i;
//        printf("\n%lu", num);
    }

/*
    lengthOfFactorial = sprintf(buffer, "%lu", num);

    for(i = 0; i < lengthOfFactorial; i++)
    {
        sum += buffer[i]-0x30;
    }

    printf("Sum is %d", sum);

    */
    return 0;
}
