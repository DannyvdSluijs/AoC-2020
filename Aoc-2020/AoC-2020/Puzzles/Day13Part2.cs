using System;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

namespace Aoc_2020.Puzzles
{
    public static class Day13Part2
    {
        public static void Execute()
        {
            var input = @"
1000655
17,x,x,x,x,x,x,x,x,x,x,37,x,x,x,x,x,571,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,13,x,x,x,x,23,x,x,x,x,x,29,x,401,x,x,x,x,x,x,x,x,x,41,x,x,x,x,x,x,x,x,19"
                .Trim()
                .Split("\n");

            var intermediates = input.Last()
                .Split(",")
                .Select(i => i == "x" ? "0" : i)
                .Select(Int64.Parse)
                .ToList();

            var busLines = intermediates.Select(b => (line: b, offset: intermediates.IndexOf(b)))
                .Where(b => b.line != 0)
                .ToArray();

            // This required some abstract hint to find the correct approach
            var firstBus = busLines.First();
            var nextCycle = firstBus.line;
            var t = nextCycle;
            foreach (var busLine in busLines)
            {
                if (busLine.line == firstBus.line)
                {
                    continue;
                }

                while (true)
                {
                    if ((t + busLine.offset) % busLine.line == 0)
                    {
                        nextCycle *= busLine.line;
                        break;
                    }

                    t += nextCycle;
                }
            }

            Console.WriteLine($"The earliest time stamp = {t}");
        }

    }
}