using System;
using System.Linq;

namespace Aoc_2020.Puzzles
{
    public static class Day13Part1
    {
        public static void Execute()
        {
            var input = @"
1000655
17,x,x,x,x,x,x,x,x,x,x,37,x,x,x,x,x,571,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,13,x,x,x,x,23,x,x,x,x,x,29,x,401,x,x,x,x,x,x,x,x,x,41,x,x,x,x,x,x,x,x,19"
                .Trim()
                .Split("\n");

            var timestamp = int.Parse(input.First());
            var busLines = input.Last()
                .Split(",")
                .Where(i => i != "x")
                .Select(int.Parse)
                .Select(line =>
                {
                    var departure = (timestamp / line + 1) * line;

                    return (line, departure);
                })
                .OrderBy(b => b.departure);

            var firstBus = busLines.First();
            var wait = firstBus.departure - timestamp;

            Console.WriteLine($"Bus {firstBus.line} is departing at {firstBus.departure} so the result is {wait * firstBus.line}"); // 138
        }

    }
}