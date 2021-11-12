using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc_2020.Puzzles
{
    public static class Day23Part1
    {
        public static void Execute()
        {
            #region input
            var input = @"476138259".ToCharArray().Select(c => Int32.Parse(c.ToString())).ToArray();
            #endregion

            var cups = new Dictionary<int, int >();
            var pickup = new int[3];
            var current = input.First();
            for (var i = 0; i < input.Length; i++)
                cups[input[i]] = input[(i + 1) % input.Length];


            for (var turn = 1; turn <= 100; turn++)
            {
                var destination = current - 1;
                if (destination == 0)
                {
                    destination = cups.Count;
                }
                for (var i = 0; i <= 2; i++)
                {
                    var id = RemoveAfter(cups, current);
                    pickup[i] = id;
                }

                while (pickup.Contains(destination))
                {
                    destination--;
                    if (destination == 0)
                    {
                        destination = cups.Count + 3;
                    }
                }

                for (var i = 0; i <= 2; i++)
                {
                    InsertAfter(cups, destination, pickup[i]);
                    destination = cups[destination];
                }

                current = cups[current];
            }

            current = 1;
            var result = string.Empty;
            while (cups[current] != 1)
            {
                result += cups[current].ToString();
                current = cups[current];
            }

            Console.WriteLine($"Answer {result}"); // 97245386
        }

        private static int RemoveAfter(IDictionary<int, int> cups, int current)
        {
            var idToRemove = cups[current];
            var newPointer = cups[idToRemove];
            cups.Remove(idToRemove);
            cups[current] = newPointer;
            return idToRemove;
        }

        private static void InsertAfter(IDictionary<int, int> dict, int pos, int newId)
        {
            var nextId = dict[pos];
            dict[pos] = newId;
            dict.Add(newId, nextId);
        }
    }
}