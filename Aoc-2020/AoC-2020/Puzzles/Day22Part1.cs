using System;
using System.Linq;

namespace Aoc_2020.Puzzles
{
    public static class Day22Part1
    {
        public static void Execute()
        {
            #region input

            var input = @"
Player 1:
28
13
25
16
38
3
14
6
29
2
47
20
35
43
30
39
21
42
50
48
23
11
34
24
41

Player 2:
27
37
9
10
17
31
19
33
40
12
32
1
18
36
49
46
26
4
45
8
15
5
44
22
7
".Trim().Split("\n\n");
            #endregion

            var playerOne = input.First()
                .Split("\n")
                .Skip(1)
                .Select(int.Parse)
                .ToList();
            var playerTwo = input.Last()
                .Split("\n")
                .Skip(1)
                .Select(int.Parse)
                .ToList();

            var round = 0;
            while (playerOne.Count != 0 && playerTwo.Count() != 0)
            {
                round++;
                var playerOnePlay = playerOne.First();
                playerOne.Remove(playerOnePlay);
                var playerTwoPlay = playerTwo.First();
                playerTwo.Remove(playerTwoPlay);

                if (playerOnePlay > playerTwoPlay)
                {
                    playerOne.Add(playerOnePlay);
                    playerOne.Add(playerTwoPlay);
                }
                else
                {
                    playerTwo.Add(playerTwoPlay);
                    playerTwo.Add(playerOnePlay);
                }
            }

            var value = 1;
            var winner = playerOne.Any() ? playerOne : playerTwo;
            winner.Reverse();
            var score = winner.Aggregate(0, (current, play) => current + play * value++);
            Console.WriteLine($"The answer is {score}"); //33694
        }
    }
}