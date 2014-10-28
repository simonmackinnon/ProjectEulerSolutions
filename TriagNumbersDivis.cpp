// TriagNumbersDivis.cpp : Defines the entry point for the console application.
//

#include <stdio.h>

#include "stdafx.h"

long numberOfDivisors(long num);

int _tmain(int argc, _TCHAR* argv[])
{
	long currentTriagNumber = 0;
	long previousTriangularNumber = 0;
	long index = 0;

	while(1)
	{
		index++;
		currentTriagNumber += index;	
		if(numberOfDivisors(currentTriagNumber) > 500)
		{
			break;
		}
	}

	return 0;
}


long numberOfDivisors(long num)
{
	long numberOfDivisors = 1;

	for (long i = 2; i <= num; i++)
	{
		long exponent = 0;
		while (num % i == 0) {
			exponent++; 
			num /= i;
		}   
		numberOfDivisors *= (exponent+1);
	}

	return numberOfDivisors;
}
