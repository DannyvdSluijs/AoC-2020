using System;
using System.Linq;

namespace Aoc_2020.Puzzles
{
    public static class Day3Part2
    {
        public static void Execute()
        {
            var input = @"....#.#..#.#.#.#......#....##.#
..##..#.#..#.##.....#.....#....
....#..#...#..#..####.##.#.##..
...............#.....##..##..#.
##...####..##.#..#...####...#.#
..#.#....##....##.........#...#
.#..#.##..............#.....###
##..##..#.....#..#...#....#....
.#.........#..#...#.#.#.....#..
......#...#..#.##..#.....#.#...
.#...#.#.#.##.##.....###...#...
..........#.......#...#....#..#
.....##..#.#...#...##.##.......
...#.###.#.#..##...#.#.........
###.###....#...###.#.##...#....
...........#....#.....##....###
#..#.......#.....#.....##....#.
.##.#....#...#....#......#..##.
..#....#..#..#......#..........
#..#.........#.#....#.##...#.#.
#....#.#.......#.#.#.#.......#.
.#....#....#..##.##.#....#.#...
............#....#.#.#........#
#..#..#.....#....#.##.##.#....#
....#......#..##..#....#...#...
.............#.##....####...##.
#.##..##..##.#.....#...........
#.#...#......####.##..#.#......
.......#.#..#...#.#.###.......#
#..#..........#...#....#.......
###...#.....#....#...#..#...#..
...##..#.#.....#..#..#...#.#.##
#.......#......##...##......#..
.....#..#.....#......#.....##..
..#.....###......#.#..###....#.
....##........#...##.#..#..#...
#...#.##...##..#####...##..##..
...#.#.#.#.....#.#.........##..
.............#......#..##...#..
.#..#...##....#......#......#..
#.....#...##......#............
.#.#....##.#.#..##..#####..##..
..#..#.....#..#.##..#.#......##
.......#...#...#..#..##.#..##..
...#.##....#....#..#..#..#.....
.....#......#.....#.....#..#.#.
..........#####.#..#....##...##
....#...#...#....#.......#.....
#.......#........#.##.####..###
.#........#...##...#.....#....#
...#.............#........#.#.#
..##........#..##..##.##...#.#.
......##......#####.........##.
...##.....#.#.##....#####......
.#.#........####.......#.#....#
.....#..#.#.#.......##...#...#.
.....####.#...#.#..#...#..#...#
#..#.....#...#..#..#.#....#..#.
.....#.......#..#.##..#.#.....#
.......#..##..###......#.......
.......##.#.##..##.#.###...##..
..#.....#.....#....##.##.#..#.#
###.#...#..##..#....#.#.#..#.#.
#...#.#.........##........#....
#...#.#..###.....###..##.......
.....##..#.#...#.....#....#...#
##...##..#.#.#..#.#.##..#....##
.#.......#.#.........#.##..#...
....##.#............###.#...##.
#.....##.###.#..#....##.....#..
....#.#......##.####....#....#.
.....#......##.#...#....##.#...
##...#.............#...#.......
..#..#......#.#..#..#.....###..
....#...#.#...#...#.....#..###.
.....#.......#....#...#...#...#
..####......#.#..###...........
..........#....###.#.#.....###.
#.............#...#..#.###.#..#
.......#...#.#.#.#...##...#..#.
...#.#..#..#...###.#.#.........
#.###.#..#...#..#....#..#.#....
...#.#.##..#...#.#......###.##.
.##..#..##..#.....##.##....#.##
..##.........####..............
.#.#..###...#.........#...##.#.
....##.........#.........##...#
...#.#.......#..#...###.#.##.#.
..#....###......#.##...........
.......#...#.....#.#..#.#...#..
.##..#...#..#...#..#...#.#..##.
.##...#..##..##.#.#...##.......
.#.##.#...#..#..#..........#.#.
#.#.#...#......##...##..##.....
.##..#............#.##....#.#..
.##.........##..#.....#...#...#
##.#.#.#.#...#.....##....##.#..
#..##......#..##.........#.#...
...#....#.#.#.##.....##........
...#...#...#.##.#.#.#..#..#....
.......#..#.......##...#....##.
#.....#.#......#.......#.##.#.#
.##..#.....#.....#.#####.#....#
......#.#....#..............##.
##..#...........#.#.#.......#..
..##...###...#.#.........#....#
..##..#.#....##.....#.#.......#
....###...#.###....###.......#.
..#.#.....#..#..#...........##.
.###..#.#........#..#.....##.#.
#.##........###.#..#.....#....#
.#.#.....#.#.#..#...##.#...#...
#.#.#...#.#........#..##..##...
..#.##....###.#.......#.#.#....
.....#...##...................#
#..####.....###.#..........#...
#.##.........###.#........#..#.
..##........#.......#..###..#.#
##..##..#.#..#..#.....#.#..#...
....#......#....#...#.#.#..##.#
.##....#.##.#.#..###..#......##
###....###.##....##......###..#
.##....#..###..##..#.###...##..
.#.......##..##.............##.
.###..#.....#.....#.#.#..#...##
......##.###.#........#..#.....
#####.....##.#.#...#...#.#.#...
##..##.####...##....#...#.#...#
.#.##...#...#..#...............
##.##.#..#........#...#........
..#.##.#....#...#.#.###..#....#
.......#.#..#.....##.#.#...#.#.
..#.##...#...#......#...#.#.#..
.##.......##......#.....#......
.#....................#.#...###
..#.....#..##.#......##..#....#
.....#.#...#...........#.#...##
...#..#....#.#..#.......#..#..#
.#..#.#...#.#.#.....###........
.#.#.....#..#.##..#.#..##......
..##..#..#.....###.##..#.....##
.#..#.#...#.....#..#......##.#.
.##.##.#.#.#.#.#...###..##...#.
......#.##.#..#.##.#...#.#..#.#
..#.....#.##....#......#..#....
.#.....#..###.............#...#
.#.....#...#...#.#.#.#..#.#....
.#.....#......##.....#...#.#..#
.#.#......##...#......#......#.
##....#...#..##.#...#..#.......
....#.#......#.##...#.........#
#.#.##.#..#......#....#.......#
.#..#.##..#..#........#.#...#..
..#..#.#.#...#....#...#..#..###
....#....#..#......#..........#
#.....#.......#..#....#.#.#..#.
....#.#..###.#.....#.####......
##.#.#....##.#.#........#..#..#
#.#...#...#.#...##..#.#..#.#...
##.#......###.##.......#..#....
#..#...#.......##....#.###.....
.####.##....#..#..####.#....#.#
#...#.#..#.....................
..###..#...##.....##...........
..#....#...###.#.........##.##.
......#.....#....#.#....##...##
#..#.....#...#..##.....#....#.#
..#.#..#....##...###.#..##....#
#....#..#..#..#.##.##.....#...#
......#.#..#..##.#.....#.#..###
.....##...##..#...##..#...#....
##....#...#..#...##..#...###..#
.##.####..#......#.#..#.##....#
..###........###..#....##.#....
...#.....##...##..##..##..#....
.#..#.#..##..#..#..##.....#...#
##.#..##...#..#...........##...
....#..#..###.....#....#..#..##
......##..#....##........#.#.##
.#.##....##.#......#..##..#..##
.....##.#..#.#.##.##.##..#...#.
.#..##.#.....#####...#.........
....#....#...#..##.#.#..##...#.
...#..#...#............#..#....
....#.#.#.##....##.###..#.#....
.........#...###.........#..#.#
...........#...##.#..#.#.#..#..
#..#.###..#.#..#..##.....#....#
.#.#....#.#....#...............
...#.#..#.#..##.#.#.#.......#..
.#......#...#.####......#..#...
..##..#.#...#..#.......###.....
.#.....#.#..##....##.####.##.#.
.............##.#.#.....#..#.#.
#.....##.#...#.#.#.######.##...
.##...........#..#..##.####....
#.#............#....#.........#
..#.##.##.#..#....##....#..#.##
#...#.##..##.##.#.....##.#....#
##.#..##.###..#.#.#..........#.
...##...#..#...#.#.#.###.###...
#.....##......#...#.#...#......
#.#.#.#.#.#...#..#....###...#..
...##.#...#.......#..#...##.#..
..#..#..##.....#......##...###.
.............#.##...#.#.###..#.
..#.#.....##..#.##..#...##..#..
..#...#.##..###..........#..#..
#.##.##...###...........#....#.
#.....##...#.#..............#..
##..##.....#...#..####.#...##..
...........#......##.###..####.
#...#..##.##.######.....#.....#
#.##.........##.#.#....##...#..
.##.#.......###.#.....#.....###
###.#.#.#.#.#.##......#..#..#.#
....#.###...#....#.##...##.##..
....#..#.....#.#.#..#..##.#....
....#..#..#.....#.#..##........
..........#..##..##......##..#.
#...##.......#...##.#...###..#.
..#.#.##.....##....#..#.##...#.
.#.#.....#.......##.....##...#.
#......#.........#.#.........#.
.......#...##......#.........#.
..##..........#....#..#.......#
.......#............#..#.#...#.
#..#....#.#..#....##..#........
....#..###.##..#.#..#.##..###..
....###............##.#....#.#.
..#..#.##...#....#..####...#...
..#....#...#...##...#.#.#..#...
..#.........#.#.......#........
.........##.##.#..#.#...#.#..##
#.....#.#....##.#####.......##.
.#..#....#......#.##..#....#...
........#....#...........#...#.
.......#......#..........#..##.
.###.#......#..#.##..#...#.#...
.....#..#..###...........#...#.
..#...##....###......#....#....
...#.#..#.#.#......#.##.###.#.#
.##....#...#..#.#..#........#..
......##.###...##.#.#.........#
.#...#..####..#.#..##........#.
#..#...#..#..#.#...#..##...#..#
..###...###....#.#.#.##....#..#
.#.#....#.#.#......##....#..#.#
##.#.#.####....#........#....#.
...#......#........#...........
#.#............##......#.##....
..##.#...#.....#.#..#.#..#.#.#.
#.......##.....##...#.#.#...###
............#..#..#....#......#
.#.##...###...#...###..#.......
...............#....#...#.#.#..
#..##..##.###...#..##...#.#.##.
..#..#.......#.##......#..#..#.
#.....#............#......#...#
.###.##......##.#...#.#.##..#..
.#..##..#..#..#.............#..
#...#...##..##........#........
...#........#..###...........#.
#.#..#.#...................#.##
#...#.#..#.......##...###..#.#.
..####......#....#.#....#..#..#
....#...........#...#..#.......
...#..#....#.#.##...#.#.#.#....
#...##.#.##..#.......#.....#...
.##....#...#.#....#....#.#...#.
##.#...#.#...##..#..##...##..#.
#..#.#.........#.......#.......
.....##.....#..#......##....#.#
.###...##.#.#.#....#....#....#.
#.#.#.............#.#..#.......
#.......#..............#...#.##
.#.#...#....#.........###...#.#
..##..###..#...#...#.#....##..#
.#..#.#...#..#.....#....#..##..
##.......##....#....###..#.#..#
#.#.#####..........#.#...##..##
......#..#..#...#...##...#....#
#..#......#...#...#..###.......
...####.....#.......#.#...##.#.
......#..#.....##..#...........
#........#..#...#.....#...#.#..
..#.....#..#......#.#.#.....#..
..#.........#..##...#...#...#..
##..##......#.........#........
..#..#....#.##.#....###.#..#.##
..##..#..#.......###....#..#...
...#.#...#.....####.#..........
........#..#..#.#.....#........
...##..........#.#.#.....#..#..
..#....#.......#...............
.#..#.#.#.##..#..#.....#.......
#.##.#.#..#..............#.....
.#.#..#.....##..##....##.....#.
.##.#..#........##.##...##.....
#....##..#............#....#...
...............##.#...#..#.....
..#..##.##...#.#.....#.........
.##..#.#.#.##.....#.#.#..#..##.
......#####.#...#..........##..
..........##.##...#.....#.#....
..##......#..#.###..#...#.##...
.#...........#.....#.#........#
.#...#................#......#.
#...#.#..##.#####..##....#.....
...##...##..#.#..........#.....
##............#......##..##...#
###.#.......#..#...#..#..#...#.
.#..##.....###.#.#............#
##.###.#.........#.......#.#..#
...#..##..#.....#.......#......
......#.#..#.....##..#..##.....
...#........##..###.#....#..#..
..#...##.##....#.##..###......#
..#...#.....#.####.....#...#.##
..........##....###..#...#####.
....#.#.#.#.#.##.............##
.#.#.#.##......#......#....#.#.
.##...##....#...#....#..###.#.#";

            var lines = input.Split("\n");
            var map = lines.Select(l => l.ToCharArray()).ToArray();
            long result = 1;

            result *= FindTreesInPath(1, 1, map);
            result *= FindTreesInPath(1, 3, map);
            result *= FindTreesInPath(1, 5, map);
            result *= FindTreesInPath(1, 7, map);
            result *= FindTreesInPath(2, 1, map);

            Console.WriteLine($"Found sum of trees {result} while traversing down with all options"); // 2124702224
        }

        private static int FindTreesInPath(int xIncrease, int yIncrease, char[][] map)
        {
            int x = 0, y = 0, trees = 0;
            var maxWidth = map.First().Length;
            var maxDepth = map.Length;

            while (x < maxDepth - 1)
            {
                x += xIncrease;
                y += yIncrease;
                if (y >= maxWidth)
                {
                    y -= maxWidth;
                }

                if (map[x][y] == '#')
                {
                    trees++;
                }
            }

            Console.WriteLine($"For x: {xIncrease} and y: {yIncrease} the number of trees is {trees}");
            return trees;
        }
    }
}