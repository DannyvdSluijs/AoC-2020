namespace Aoc_2020.Sponsors.Infi
{
    public static class Utils
    {
        public static long GetBagSize(int length)
        {
            long total = 0;
            var line = 1;
            // 2 times "pyramid"-shape for top and bottom
            while (line <= length)
            {
                total += (length + ((line - 1) * 2)) * 2;
                line++;
            }

            // And the center section
            var maxWidth = length + (length * 2);
            total += length * maxWidth;

            return total;
        }

        public static long GetBagLength(long neededSize)
        {
            var length = 0;

            while (true)
            {
                length++;
                var bagSize = GetBagSize(length);

                if (bagSize < neededSize) continue;

                return length;
            }
        }

        public static long GetClothNeededForBagLength(long length)
        {
            return length * 8;
        }
    }
}