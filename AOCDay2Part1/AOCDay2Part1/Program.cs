using System;
using System.IO;
using System.Linq;

namespace AOCDay2Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = File.ReadAllText(@"./IntcodeInput.txt").Split(",").Select(item => int.Parse(item)).ToArray<int>();
            Console.WriteLine($"Starting position 1: {inputArray[1]} Starting position 2: {inputArray[2]}");
            Console.WriteLine(RestoreGravityComputerRecursive(inputArray, 0));
        }

        private static int RestoreGravityComputerRecursive(int[] inputArray, int index)
        {
            if (index == inputArray.Length || inputArray[index] == 99)
                return inputArray[0];

            if(inputArray[index] == 1)
            {
                inputArray[inputArray[index + 3]] = inputArray[inputArray[index + 1]] + inputArray[inputArray[index + 2]];
            }
            else if(inputArray[index] == 2)
            {
                inputArray[inputArray[index + 3]] = inputArray[inputArray[index + 1]] * inputArray[inputArray[index + 2]];
            }

            return RestoreGravityComputerRecursive(inputArray, index + 4);
        }
    }
}
