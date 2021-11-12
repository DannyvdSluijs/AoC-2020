using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc_2020.Puzzles
{
    public static class Day23Part2
    {
        public static void Execute()
        {
            #region input
            var input = @"476138259".ToCharArray().Select(c => long.Parse(c.ToString())).ToArray();
            #endregion

            var cups = new Dictionary<long, long>();
            var move = new long[3];
            var current = input.First();
            for (var i = 0; i < input.Length; i++)
                cups[input[i]] = input[(i + 1) % input.Length];
            cups[input.Last()] = 10;
            for (var i = 10; i < 1_000_000; i++)
                    cups.Add(i, i + 1);
            cups[1_000_000] = current;

            for (var turn = 1; turn <= 10_000_000; turn++)
            {
                var dest = current - 1;
                if (dest == 0) dest = cups.Count;
                for (var i = 0; i <= 2; i++)
                {
                    var id = RemoveAfter(cups, current);
                    move[i] = id;
                }

                while (move.Contains(dest))
                {
                    dest--;
                    if (dest == 0) dest = cups.Count + 3;
                }
                for (var i = 0; i <= 2; i++)
                {
                    InsertAfter(cups, dest, move[i]);
                    dest = cups[dest];
                }
                current = cups[current];
            }

            long answer = cups[1] * cups[cups[1]];
            Console.WriteLine($"The answer is {cups[1]} * {cups[cups[1]]} = {answer}"); // 156180332979, but didnt find this without hints.
        }

        private static long RemoveAfter(IDictionary<long, long> cups, long current)
        {
            var idToRemove = cups[current];
            var newPointer = cups[idToRemove];
            cups.Remove(idToRemove);
            cups[current] = newPointer;
            return idToRemove;
        }

        private static void InsertAfter(IDictionary<long, long> dict, long pos, long newId)
        {
            var nextId = dict[pos];
            dict[pos] = newId;
            dict.Add(newId, nextId);
        }
    }
}