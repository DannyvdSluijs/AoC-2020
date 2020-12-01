using Aoc_2020.Sponsors.Infi;
using Xunit;

namespace AoC_2020_Tests.Sponsors.Infi
{
    public class UtilsTests
    {
        [Theory]
        [InlineData(1, 5)]
        [InlineData(2, 24)]
        [InlineData(3, 57)]
        [InlineData(4, 104)]
        [InlineData(10, 680)]
        [InlineData(25, 4325)]
        public void GetBagSize_WithLength_ReturnsExpectedSize(int length, int expectedSize)
        {
            var size = Utils.GetBagSize(length);

            Assert.Equal(expectedSize, size);
        }

        [Theory]
        [InlineData(17473134, 1581)]
        [InlineData(4451376387, 25218)]
        [InlineData(1340887139, 13841)]
        [InlineData(747696495, 10336)]
        [InlineData(430857959, 7846)]
        [InlineData(368985565, 7261)]
        [InlineData(42707679, 2471)]
        public void GetBagLength_WithSize_ReturnsExpectedLength(long size, int expectedLength)
        {
            var length = Utils.GetBagLength(size);

            Assert.Equal(expectedLength, length);
        }

        [Theory]
        [InlineData(1, 8)]
        [InlineData(4, 32)]
        [InlineData(25, 200)]
        public void GetClothNeededForBagLength_WithLength_ReturnsExpectedClothNeeded(int length, int expectedClothNeeded)
        {
            var clothNeeded = Utils.GetClothNeededForBagLength(length);

            Assert.Equal(expectedClothNeeded, clothNeeded);
        }
    }
}