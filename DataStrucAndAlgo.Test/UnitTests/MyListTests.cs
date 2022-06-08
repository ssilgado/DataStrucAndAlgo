using DataStrucAndAlgo.Interfaces;
using Xunit;

namespace DataStrucAndAlgo.Implementations
{
    public abstract class MyListTests
    {
        protected abstract IMyList<int?> GetMyListInstance();

        [Fact]
        public void Constructor_EmptyList_ZeroCount()
        {
            // Arrange
            var list = GetMyListInstance();

            // Assert
            Assert.Equal(0, list.Count);
        }

        [Theory]
        [InlineData(new int[] {1})]
        [InlineData(new int[] {1, 2})]
        [InlineData(new int[] {1, 2, 6, 10})]
        public void Add_EmptyList_CorrectCount(int[] values)
        {
            // Arrange
            var list = GetMyListInstance();

            // Act
            foreach (var value in values)
            {
                list.Add(value);
            }

            // Assert
            Assert.Equal(values.Length, list.Count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(10)]
        [InlineData(90)]
        public void Contains_IntList_ReturnsTrue(int value)
        {
            // Arrange
            var list = GetMyListInstance();
            list.Add(1);
            list.Add(11);
            list.Add(25);
            list.Add(2);
            list.Add(10);
            list.Add(10);
            list.Add(90);

            // Act
            var result = list.Contains(value);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Contains_SingleNullValue_ReturnsTrue()
        {
            // Arrange
            var list = GetMyListInstance();
            list.Add(1);
            list.Add(2);
            list.Add(null);
            list.Add(10);

            // Act
            var result = list.Contains(null);

            // Assert
            Assert.True(result);
        }
    }
}