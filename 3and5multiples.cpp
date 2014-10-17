#include <iostream>

using namespace std;

int main()
{
    long sum = 0;
    int i = 0;

    for(i=0; i< 1000; i++)
    {
        if((i%3==0)||(i%5==0))
        {
            sum += i;
        }

    }


    cout << "Sum = " << sum << endl;
    return 0;
}
