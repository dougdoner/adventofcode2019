using System;
using System.IO;

namespace AOCDay2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileText = File.ReadAllText(@"MassInput.txt").Split("\n");
            Console.WriteLine(fileText[0]);

            double fuelTotal = 0;

            foreach (string massNum in fileText)
            {
                fuelTotal += CalcFuelGivenMassRecursive(double.Parse(massNum));
            }

            Console.WriteLine($"Total fuel required for trip: {fuelTotal}");

        }


        public static double CalcFuelGivenMassRecursive(double massNumber)
        {
            if (((Math.Floor(massNumber / 3)) - 2) <= 0)
                return 0;

            return ((Math.Floor(massNumber / 3)) - 2) + CalcFuelGivenMassRecursive(((Math.Floor(massNumber / 3)) - 2));
        }
    }
}
