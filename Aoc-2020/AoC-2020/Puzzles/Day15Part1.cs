using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc_2020.Puzzles
{
    public static class Day15Part1
    {
        private static readonly List<int> input = "0,3,1,6,7,5".Split(",").Select(int.Parse).ToList();
        private static readonly Dictionary<int, (int, int)> spoken = new Dictionary<int, (int, int)>();

        public static void Execute()
        {
            for (int i = 0; i < 2020; i++) // Input is zero based
            {
                if (i < input.Count())
                {
                    spoken.Add(input[i], (i + 1, i + 1)); // Turn number is one-based
                    continue;
                }

                var lastNumberSpoken = input[i - 1];
                spoken.TryGetValue(lastNumberSpoken, out var spokenInfo);
                if (spokenInfo.Item1 == spokenInfo.Item2 || spokenInfo.Item1 == 0 && spokenInfo.Item2 == i)
                {
                    UpdateInputAndSpoken(0, i + 1);
                }
                else
                {
                    var recentlySpokenBefore = spoken.GetValueOrDefault(lastNumberSpoken);
                    var value = recentlySpokenBefore.Item2 - recentlySpokenBefore.Item1;
                    UpdateInputAndSpoken(value, i + 1);
                }
            }

            Console.WriteLine($"The answer is {input.Last()}"); // 852
        }

        private static void UpdateInputAndSpoken(int value, int turn)
        {
            input.Add(value);
            var previous = spoken.GetValueOrDefault(value);
            spoken.Remove(value);
            spoken.Add(value, (previous.Item2, turn));
        }
    }
}