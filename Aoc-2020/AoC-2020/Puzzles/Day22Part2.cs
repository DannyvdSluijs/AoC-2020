using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc_2020.Puzzles
{
    public static class Day22Part2
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
".Trim().Split("\n\n"); // 31835
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

            var winner = PlayGame(playerOne, playerTwo, out var playerOneWins);

            var value = 1;
            winner.Reverse();
            var score = winner.Aggregate(0, (current, play) => current + play * value++);
            Console.WriteLine($"The answer is {score}");
        }

        private static List<int> PlayGame(List<int> playerOne, List<int> playerTwo , out bool playerOneWins)
        {
            var playerOneDeck = new List<string>();
            var playerTwoDeck = new List<string>();
            while (playerOne.Count != 0 && playerTwo.Count() != 0)
            {
                // New rule 1
                if (playerOneDeck.Contains(string.Join(",", playerOne)) ||
                    playerTwoDeck.Contains(string.Join(",", playerTwo)))
                {
                    playerOneWins = true;
                    return playerOne;
                }

                playerOneDeck.Add(string.Join(",", playerOne));
                playerTwoDeck.Add(string.Join(",", playerTwo));

                var playerOnePlay = playerOne.First();
                playerOne.Remove(playerOnePlay);
                var playerTwoPlay = playerTwo.First();
                playerTwo.Remove(playerTwoPlay);

                // New rule 3
                if (playerOne.Count() >= playerOnePlay && playerTwo.Count() >= playerTwoPlay)
                {
                    var winner = PlayGame(playerOne.Take(playerOnePlay).ToList(), playerTwo.Take(playerTwoPlay).ToList(), out var oneWins);
                    if (oneWins)
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
                else
                {
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
            }

            playerOneWins = playerOne.Any();
            return playerOne.Any() ? playerOne : playerTwo;
        }
    }
}