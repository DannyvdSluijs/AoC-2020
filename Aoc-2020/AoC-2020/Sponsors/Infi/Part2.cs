using System;
using System.Linq;

namespace Aoc_2020.Sponsors.Infi
{
    public static class Part2
    {
        public static void Execute()
        {
            const long asia = 4541376387;
            const int africa = 1340887139;
            const int europe = 747696495;
            const int southAmerica = 430857959;
            const int northAmerica = 368985565;
            const int oceania = 42707679;

            long[] numberOfPeople = {asia, africa, europe, southAmerica, northAmerica, oceania};

            var bagLengths = numberOfPeople.Select(Utils.GetBagLength);
            var clothNeeded = bagLengths.Select(Utils.GetClothNeededForBagLength);

            Console.WriteLine($"For all the people the elves of Santa need {clothNeeded.Sum()} cloth");
        }
    }
}