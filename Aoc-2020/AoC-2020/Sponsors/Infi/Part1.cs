using System;

namespace Aoc_2020.Sponsors.Infi
{
    public static class Part1
    {
        public static void Execute()
        {
            var numberOfPeople = 17473134;
            var length = Utils.GetBagLength(numberOfPeople);

            Console.WriteLine($"For {numberOfPeople} Santa needs a bag of {length} length");
            // For 17473134 Santa needs a bag of 1581 length
        }
    }
}