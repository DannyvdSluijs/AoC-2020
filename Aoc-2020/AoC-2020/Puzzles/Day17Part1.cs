using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Aoc_2020.Puzzles
{
    public static class Day17Part1
    {
        private static Dictionary<(int x, int y , int z), char> space = new Dictionary<(int x, int y , int z), char>();
        private static char active = '#';
        private static char inactive = '.';
        public static void Execute()
        {
            var input = @"
##......
.##...#.
.#######
..###.##
.#.###..
..#.####
##.####.
##..#.##
"
                .Trim()
                .Split("\n")
                .Select(x => x.ToCharArray())
                .ToArray();
            for (var i = 0; i < input.Count(); i++)
            {
                for (var j = 0; j < input.First().Length; j++)
                {
                    space.Add((i - 1, j - 1, 0), input[i][j]);
                }
            }

            for (int cycle = 1; cycle <= 6; cycle++)
            {
                var xMax = space.Max(c => c.Key.x);
                var yMax = space.Max(c => c.Key.y);
                var zMax = space.Max(c => c.Key.z);
                for (int x = (xMax + 1) * -1; x <= xMax + 1; x++)
                {
                    for (int y = (yMax + 1) * -1; y <= yMax + 1; y++)
                    {
                        for (int z = (zMax + 1) * -1; z <= zMax + 1; z++)
                        {
                            if (space.Count(c => c.Key.Equals((x, y, z))) == 0)
                            {
                                space.Add((x, y, z), inactive);
                            }
                        }
                    }
                }

                var clone = new Dictionary<(int x, int y , int z), char>(space);

                foreach (var (key, value) in space)
                {
                    clone.Remove(key);
                    clone.Add(key, determineState(key));
                }

                space = clone;
            }

            var count = space.Count(x => x.Value == active);

            Console.WriteLine($"The answer {count}"); // 306
        }

        private static char determineState((int x, int y , int z) coord)
        {
            var state = space.GetValueOrDefault(coord, '.');
            var neighbours = GetNeighboursForCoordinate(coord);
            var activeNeighbours = neighbours
                .Select(c => space.GetValueOrDefault(c, '.'))
                .Count(c => c == active);

            if (state == active && (activeNeighbours == 2 || activeNeighbours == 3))
            {
                return active;
            }

            if (state == inactive && activeNeighbours == 3)
            {
                return active;
            }

            return inactive;
        }

        private static IEnumerable<(int x, int y , int z)> GetNeighboursForCoordinate((int x, int y , int z) coord)
        {
            // Same Z-index
            return Enumerable.Range(-1, 3).Select(xOffset =>
            {
                return Enumerable.Range(-1, 3).Select(yOffset =>
                {
                    return Enumerable.Range(-1, 3)
                        .Select(zOffset => (x: coord.x + xOffset, y: coord.y + yOffset, z: coord.z + zOffset));
                });
            })
                .SelectMany(x => x)
                .SelectMany(x => x)
                .Where(x => x != coord);
        }
    }
}