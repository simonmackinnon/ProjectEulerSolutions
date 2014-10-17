#include <iostream>
#include <string>

using namespace std;
string intToLetters(int num);

int main()
{
    int i = 0;
    string lettersFromNumber;
    int numberOfLetters = 0;
    long totalNumberOfLetters = 0;

    for(i = 1; i <= 1000; i++)
    {
        lettersFromNumber = intToLetters(i);
        numberOfLetters = (lettersFromNumber.length());
        totalNumberOfLetters += numberOfLetters;
        cout << lettersFromNumber << endl;
    }

    cout << "Total number of letters: " << totalNumberOfLetters << endl; //21213

    return 0;
}


string intToLetters(int num)
{
    if(num > 1000)
        return NULL;

    if(num == 10)
        return "ten";

    if(num == 11)
        return "eleven";

    if(num == 12)
        return "twelve";

    if(num == 13)
        return "thirteen";

    if(num == 14)
        return "fourteen";

    if(num == 15)
        return "fifteen";

    if(num == 16)
        return "sixteen";

    if(num == 17)
        return "seventeen";

    if(num == 18)
        return "eighteen";

    if(num == 19)
        return "nineteen";



    string letters;

    int hundreds = num/100;
    int tens = num % 100 / 10;
    int ones = num %10;

    if(hundreds != 0)
    {
        if(hundreds == 1)
            letters = "onehundred";
        else if(hundreds == 2)
            letters = "twohundred";
        else if(hundreds == 3)
            letters = "threehundred";
        else if(hundreds == 4)
            letters = "fourhundred";
        else if(hundreds == 5)
            letters = "fivehundred";
        else if(hundreds == 6)
            letters = "sixhundred";
        else if(hundreds == 7)
            letters = "sevenhundred";
        else if(hundreds == 8)
            letters = "eighthundred";
        else if(hundreds == 9)
            letters = "ninehundred";
    }

    if((hundreds != 0) && ((tens != 0) || (ones != 0)))
    {
        letters.append("and");
    }

    if(tens == 1)
    {
        if(ones == 0)
        {
            letters.append("ten");
            return letters;
        }

        if(ones == 1)
        {
            letters.append("eleven");
            return letters;
        }

        if(ones == 2)
        {
            letters.append("twelve");
            return letters;
        }

        if(ones == 3)
        {
            letters.append("thirteen");
            return letters;
        }

        if(ones == 4)
        {
            letters.append("fourteen");
            return letters;
        }

        if(ones == 5)
        {
            letters.append("fifteen");
            return letters;
        }

        if(ones == 6)
        {
            letters.append("sixteen");
            return letters;
        }

        if(ones == 7)
        {
            letters.append("seventeen");
            return letters;
        }

        if(ones == 8)
        {
            letters.append("eighteen");
            return letters;
        }

        if(ones == 9)
        {
            letters.append("nineteen");
            return letters;
        }


    }


    if(tens != 0)
    {
        if(tens == 2)
            letters.append("twenty");
        else if(tens == 3)
            letters.append("thirty");
        else if(tens == 4)
            letters.append("fourty");
        else if(tens == 5)
            letters.append("fifty");
        else if(tens == 6)
            letters.append("sixty");
        else if(tens == 7)
            letters.append("seventy");
        else if(tens == 8)
            letters.append("eighty");
        else if(tens == 9)
            letters.append("ninety");
    }

    if(ones != 0)
    {
        if(ones == 1)
            letters.append("one");
        else if(ones == 2)
            letters.append("two");
        else if(ones == 3)
            letters.append("three");
        else if(ones == 4)
            letters.append("four");
        else if(ones == 5)
            letters.append("five");
        else if(ones == 6)
            letters.append("six");
        else if(ones == 7)
            letters.append("seven");
        else if(ones == 8)
            letters.append("eight");
        else if(ones == 9)
            letters.append("nine");
    }

    return letters;
}
