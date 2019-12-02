using System;
using System.IO;
using System.Linq;

namespace AOCDay2Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = File.ReadAllText(@"./IntcodeInput.txt").Split(",").Select(item => int.Parse(item)).ToArray<int>();
            Console.WriteLine($"Starting position 1: {inputArray[1]} Starting position 2: {inputArray[2]}");
            Console.WriteLine(FindIntcodeOutputGivenInput((0,0), 19690720));
        }

        private static int RestoreGravityComputerRecursive(int[] inputArray, int index)
        {
            if (index == inputArray.Length || inputArray[index] == 99)
                return inputArray[0];

            if (inputArray[index] == 1)
            {
                inputArray[inputArray[index + 3]] = inputArray[inputArray[index + 1]] + inputArray[inputArray[index + 2]];
            }
            else if (inputArray[index] == 2)
            {
                inputArray[inputArray[index + 3]] = inputArray[inputArray[index + 1]] * inputArray[inputArray[index + 2]];
            }

            return RestoreGravityComputerRecursive(inputArray, index + 4);
        }

        private static (int noun, int verb) FindIntcodeOutputGivenInput((int noun, int verb) predicate, int target)
        {
            if(predicate.noun == 100)
            {
                predicate.noun = 0;
                predicate.verb++;
            }
            if (predicate.verb == 100)
            {
                return (-1, -1);
            }

            Console.WriteLine($"{predicate.noun} {predicate.verb}");

            int[] inputArr2 = File.ReadAllText(@"./IntcodeInput.txt").Split(",").Select(item => int.Parse(item)).ToArray<int>();

            inputArr2[1] = predicate.noun;
            inputArr2[2] = predicate.verb;

            RestoreGravityComputerRecursive(inputArr2, 0);

            if (inputArr2[0] == target)
                return predicate;

            return FindIntcodeOutputGivenInput((predicate.noun+1, predicate.verb), target); 
        }
    }
}
