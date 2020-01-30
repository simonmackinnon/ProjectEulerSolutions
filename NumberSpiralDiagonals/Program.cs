using System;

namespace NumberSpiralDiagonals
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 1;
            int SecondSquareIndex = 1;
            int SecondSquare = 1;
            int LevelGap = 0;
            int SpiralWidth = 1001;

            while (SecondSquareIndex < SpiralWidth)
            {
                SecondSquareIndex += 2;
                SecondSquare = SecondSquareIndex*SecondSquareIndex;
                LevelGap += 2;  
                sum += SecondSquare + (SecondSquare-LevelGap) + (SecondSquare-(LevelGap*2)) + (SecondSquare-(LevelGap*3));
            }

            Console.WriteLine("Sum: " + sum);
        }
    }
}
