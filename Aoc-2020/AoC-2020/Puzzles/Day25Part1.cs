using System;

namespace Aoc_2020.Puzzles
{
    public static class Day25Part1
    {
        public static int cardPublicKey = 10705932;
        public static int doorPublicKey = 12301431;
        public static int magic = 20201227;

        public static void Execute()
        {
            long result = 0;
            var loopSize = 0;
            while (result != cardPublicKey)
            {
                Console.WriteLine($"Testing with loop size {loopSize}");
                result = Transform(7, loopSize++);
            }

            var cardLoopSize = loopSize - 1;
            Console.WriteLine($"Found card loop size is {cardLoopSize}");


            Console.WriteLine($"The answer is {Transform(doorPublicKey, cardLoopSize)}"); // 11328376; But implementation is brute-force. Didn't get the math behind it.
        }

        private static long Transform(long subjectNumber, long loopSize)
        {
            long value = 1;
            for (var i = 0; i < loopSize; i++)
            {
                value *= subjectNumber;
                value %= magic;
            }

            return value;
        }
    }
}