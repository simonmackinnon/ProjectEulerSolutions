#include <stdio.h>
#include <stdlib.h>



int main()
{
    char buffer[1000] = "73167176531330624919225119674426574742355349194\
	93496983520312774506326239578318016984801869478851843858615607891129\
	49495459501737958331952853208805511125406987471585238630507156932909\
	632952274430435576689664895044524452316173185640309871112172238311362\
	229893423380308135336276614282806444486645238749303589072962904915604\
	407723907138105158593079608667017242712188399879790879227492190169972\
	088809377665727333001053367881220235421809751254540594752243525849077\
	116705560136048395864467063244157221553975369781797784617406495514929\
	086256932197846862248283972241375657056057490261407972968652414535100\
	474821663704844031998900088952434506585412275886668811642717147992444\
	292823086346567481391912316282458617866458359124566529476545682848912\
	883142607690042242190226710556263211111093705442175069416589604080719\
	840385096245544436298123098787992724428490918884580156166097919133875\
	499200524063689912560717606058861164671094050775410022569831552000559\
	3572972571636269561882670428252483600823257530420752963450";

    int index = 0;
    char tmp[5];
    long product = 1;
    long largestProduct = 1;
    int i = 0;

    while(index <= 995)
    {
        tmp[0] = buffer[index];
        tmp[1] = buffer[index+1];
        tmp[2] = buffer[index+2];
        tmp[3] = buffer[index+3];
        tmp[4] = buffer[index+4];

        product = 1;

        for(i = 0; i < 5; i++)
        {
            product *= (tmp[i] - '0');
        }

        printf("\nProduct = %ld", product);

        if(product > largestProduct)
        {
            largestProduct = product;
        }
        index++;
    }

    printf("\nLargest Product = %ld", largestProduct);


    return 0;
}