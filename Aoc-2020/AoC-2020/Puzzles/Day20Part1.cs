using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc_2020.Puzzles
{
    public static class Day20Part1
    {
        public static void Execute()
        {
            #region input

            var input = @"Tile 1091:
Tile 2311:
..##.#..#.
##..#.....
#...##..#.
####.#...#
##.##.###.
##...#.###
.#.#.#..##
..#....#..
###...#.#.
..###..###

Tile 1951:
#.##...##.
#.####...#
.....#..##
#...######
.##.#....#
.###.#####
###.##.##.
.###....#.
..#.#..#.#
#...##.#..

Tile 1171:
####...##.
#..##.#..#
##.#..#.#.
.###.####.
..###.####
.##....##.
.#...####.
#.##.####.
####..#...
.....##...

Tile 1427:
###.##.#..
.#..#.##..
.#.##.#..#
#.#.#.##.#
....#...##
...##..##.
...#.#####
.#.####.#.
..#..###.#
..##.#..#.

Tile 1489:
##.#.#....
..##...#..
.##..##...
..#...#...
#####...#.
#..#.#.#.#
...#.#.#..
##.#...##.
..##.##.##
###.##.#..

Tile 2473:
#....####.
#..#.##...
#.##..#...
######.#.#
.#...#.#.#
.#########
.###.#..#.
########.#
##...##.#.
..###.#.#.

Tile 2971:
..#.#....#
#...###...
#.#.###...
##.##..#..
.#####..##
.#..####.#
#..#.#..#.
..####.###
..#.#.###.
...#.#.#.#

Tile 2729:
...#.#.#.#
####.#....
..#.#.....
....#..#.#
.##..##.#.
.#.####...
####.#.#..
##.####...
##..#.##..
#.##...##.

Tile 3079:
#.#.#####.
.#..######
..#.......
######....
####.#..#.
.#...#.##.
#.#####.##
..#.###...
..#.......
..#.###...
".Trim().Split("\n\n");

            #endregion

            var tiles = input.ToDictionary(
                tile => int.Parse(tile.Split(":").First().Split(" ").Last()),
                tile => tile.Split(":").Last().Trim().Split("\n")
            );

            var numberOfMatchingSide = tiles.Select(tile =>
            {
                var tilesLeftSides = tiles.Where(t => t.Key != tile.Key).Select(t => GetLeftSideOfTile(t.Value)).ToArray();
                var tilesRightSides = tiles.Where(t => t.Key != tile.Key).Select(t => GetRightSideOfTile(t.Value)).ToArray();
                var tilesTopSides = tiles.Where(t => t.Key != tile.Key).Select(t => t.Value.First()).ToArray();
                var tilesBottomSides = tiles.Where(t => t.Key != tile.Key).Select(t => t.Value.Last()).ToArray();

                var leftSide = GetLeftSideOfTile(tile.Value);
                var leftMatch = tilesLeftSides.Contains(leftSide) || tilesLeftSides.Select(x => String.Join("", x.Reverse())).Contains(leftSide)
                    || tilesRightSides.Contains(leftSide) || tilesRightSides.Select(x => String.Join("", x.Reverse())).Contains(leftSide)
                    || tilesTopSides.Contains(leftSide)  || tilesTopSides.Select(x => String.Join("", x.Reverse())).Contains(leftSide)
                    || tilesBottomSides.Contains(leftSide) || tilesBottomSides.Select(x => String.Join("", x.Reverse())).Contains(leftSide);
                var rightSide = GetRightSideOfTile(tile.Value);
                var rightMatch = tilesLeftSides.Contains(rightSide) || tilesLeftSides.Select(x => String.Join("", x.Reverse())).Contains(rightSide)
                                                                    || tilesRightSides.Contains(rightSide) || tilesRightSides.Select(x => String.Join("", x.Reverse())).Contains(rightSide)
                                                                    || tilesTopSides.Contains(rightSide)  || tilesTopSides.Select(x => String.Join("", x.Reverse())).Contains(rightSide)
                                                                    || tilesBottomSides.Contains(rightSide) || tilesBottomSides.Select(x => String.Join("", x.Reverse())).Contains(rightSide);
                var topSide = tile.Value.First();
                var topMatch = tilesLeftSides.Contains(topSide) || tilesLeftSides.Select(x => String.Join("", x.Reverse())).Contains(topSide)
                                                                || tilesRightSides.Contains(topSide) || tilesRightSides.Select(x => String.Join("", x.Reverse())).Contains(topSide)
                                                                || tilesTopSides.Contains(topSide)  || tilesTopSides.Select(x => String.Join("", x.Reverse())).Contains(topSide)
                                                                || tilesBottomSides.Contains(topSide) || tilesBottomSides.Select(x => String.Join("", x.Reverse())).Contains(topSide);
                var bottomSide = tile.Value.Last();
                var bottomMatch = tilesLeftSides.Contains(bottomSide) || tilesLeftSides.Select(x => x.Reverse()).Contains(bottomSide)
                                                                      || tilesRightSides.Contains(bottomSide) || tilesRightSides.Select(x => String.Join("", x.Reverse())).Contains(bottomSide)
                                                                      || tilesTopSides.Contains(bottomSide)  || tilesTopSides.Select(x => String.Join("", x.Reverse())).Contains(bottomSide)
                                                                      || tilesBottomSides.Contains(bottomSide) || tilesBottomSides.Select(x => String.Join("", x.Reverse())).Contains(bottomSide);

                var count = 0;
                if (leftMatch) count++;
                if (rightMatch) count++;
                if (topMatch) count++;
                if (bottomMatch) count++;

                return new KeyValuePair<int,int>(tile.Key, count);
            }).ToDictionary(i => i.Key, i => i.Value);

            var sum = numberOfMatchingSide.Where(tile => tile.Value == 2).Select(x => x.Key).Aggregate<int, long>(1, (current, i) => current * i);

            Console.WriteLine($"The answer is {sum}"); // 76311769895311 is to low.
        }

        private static string GetLeftSideOfTile(IEnumerable<string> tile)
        {
            return string.Join("", tile.Select(r => r.Substring(0, 1)));
        }

        private static string GetRightSideOfTile(IEnumerable<string> tile)
        {
            return string.Join("", tile.Select(r => r.Substring(9, 1)));
        }
    }
}