using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Aoc_2020.Puzzles
{
    public static class Day17Part2
    {
        private static Dictionary<(int x, int y , int z, int w), char> space = new Dictionary<(int x, int y , int z, int w), char>();
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
                    space.Add((i - 1, j - 1, 0, 0), input[i][j]);
                }
            }

            for (int cycle = 1; cycle <= 6; cycle++)
            {
                Console.WriteLine($"Starting cycle {cycle}");
                var xMax = space.Max(c => c.Key.x);
                var yMax = space.Max(c => c.Key.y);
                var zMax = space.Max(c => c.Key.z);
                var wMax = space.Max(c => c.Key.w);
                for (int x = (xMax + 1) * -1; x <= xMax + 1; x++)
                {
                    for (int y = (yMax + 1) * -1; y <= yMax + 1; y++)
                    {
                        for (int z = (zMax + 1) * -1; z <= zMax + 1; z++)
                        {
                            for (int w = (wMax + 1) * -1; w <= wMax + 1; w++)
                            {
                                if (x >= xMax * -1 && x <= xMax && y >= yMax * -1 && y <= yMax && z >= zMax * -1 &&
                                    z <= zMax && w >= wMax * -1 && w <= wMax)
                                {
                                    continue;
                                }

                                space.Add((x, y, z, w), inactive);
                            }
                        }
                    }
                }
                Console.WriteLine($" - Expanded universe");

                var clone = new Dictionary<(int x, int y , int z, int w), char>(space);

                foreach (var (key, value) in space)
                {
                    clone.Remove(key);
                    clone.Add(key, determineState(key));
                }

                space = clone;
            }

            var count = space.Count(x => x.Value == active);

            Console.WriteLine($"The answer {count}");
        }

        private static char determineState((int x, int y , int z, int w) coord)
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

        private static IEnumerable<(int x, int y , int z, int w)> GetNeighboursForCoordinate((int x, int y , int z, int w) coord)
        {
            // Same Z-index
            return Enumerable.Range(-1, 3).Select(xOffset =>
            {
                return Enumerable.Range(-1, 3).Select(yOffset =>
                {
                    return Enumerable.Range(-1, 3).Select(zOffset =>
                    {
                        return Enumerable.Range(-1, 3).Select(wOffset =>
                        {
                            return (x: coord.x + xOffset, y: coord.y + yOffset, z: coord.z + zOffset,
                                coord.w + wOffset);
                        });
                    });
                });
            })
                .SelectMany(x => x)
                .SelectMany(x => x)
                .SelectMany(x => x)
                .Where(x => x != coord);
        }
    }
}