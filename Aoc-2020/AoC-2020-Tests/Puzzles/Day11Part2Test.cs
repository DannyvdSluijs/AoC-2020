using Aoc_2020.Puzzles;
using Xunit;

namespace AoC_2020_Tests.Puzzles
{
    public class Day11Part2Test
    {
        [Fact]
        public void FirstExample()
        {
            var input = @"
.......#.
...#.....
.#.......
.........
..#L....#
....#....
.........
#........
...#.....    ";
            var map = Day11Part2.MapToCharArray(input.Trim());
            Assert.Equal('L', Day11Part2.GetCharFromMap(map, 4,3));
            Assert.Equal(8, Day11Part2.NumberOfOccupiedSeatsInSight(map, 4, 3));
            Assert.True(Day11Part2.IsOccupiedInOffsetsDirection(map, 4, 3, -1, -1));
            Assert.True(Day11Part2.IsOccupiedInOffsetsDirection(map, 4, 3, -1, 0));
            Assert.True(Day11Part2.IsOccupiedInOffsetsDirection(map, 4, 3, -1, 1));
            Assert.True(Day11Part2.IsOccupiedInOffsetsDirection(map, 4, 3, 0, -1));
            Assert.True(Day11Part2.IsOccupiedInOffsetsDirection(map, 4, 3, 0, 1));
            Assert.True(Day11Part2.IsOccupiedInOffsetsDirection(map, 4, 3, 1, -1));
            Assert.True(Day11Part2.IsOccupiedInOffsetsDirection(map, 4, 3, 1, 0));
            Assert.True(Day11Part2.IsOccupiedInOffsetsDirection(map, 4, 3, 1, 1));
        }
    }
}