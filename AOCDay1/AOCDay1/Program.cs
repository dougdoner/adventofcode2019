using System;
using System.IO;

namespace AOCDay1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileText = File.ReadAllText(@"MassInput.txt").Split("\n");
            Console.WriteLine(fileText[0]);

            double fuelTotal = 0;

            foreach(string massNum in fileText)
            {
                fuelTotal += CalcFuelGivenMass(double.Parse(massNum));
            }

            Console.WriteLine($"Total fuel required for trip: {fuelTotal}");
        }


        public static double CalcFuelGivenMass(double massNumber)
        {
            return ((Math.Floor(massNumber / 3)) - 2);
        }
    }
}
