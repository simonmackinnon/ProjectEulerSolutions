// LongestCollatzSeq.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include <iostream>

#define MAX_NUMS 1000000

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	cout << "Begin" << endl;

	int sequence;
	int sequenceLength = 0;
	int startingNumber = 0;

	for(int i = 2; i <= MAX_NUMS; i++)
	{
		int length = 1;
		sequence = i;
		while(sequence != 1)
		{
			if ((sequence % 2) == 0) 
			{
				sequence = sequence / 2;
			} 
			else 
			{
				sequence = sequence * 3 + 1;
			}
			length++;
		}

		if(length > sequenceLength) {
			sequenceLength = length;
			startingNumber = i;
		}
	}

	return 0;
}

