using System;
using DataStrucAndAlgo.Interfaces;
using Xunit;

namespace DataStrucAndAlgo.Implementations
{
    public abstract class MyListTests
    {
        protected abstract IMyList<int?> GetMyListInstance();

        [Fact]
        public void Count_EmptyList_ZeroCount()
        {
            // Arrange
            var list = GetMyListInstance();

            // Act
            var count = list.Count;

            // Assert
            Assert.Equal(0, count);
        }

        [Theory]
        [InlineData(new int[] {1})]
        [InlineData(new int[] {1, 2})]
        [InlineData(new int[] {1, 2, 6, 10})]
        public void Count_AddEmptyList_CorrectCount(int[] values)
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
        [InlineData(new int[] {1, 2, 3, 4, 5}, 1, 0)]
        [InlineData(new int[] {1, 2, 3, 4, 5}, 3, 2)]
        [InlineData(new int[] {1, 2, 3, 4, 5}, 5, 4)]
        public void Add_ExistingList_CorrectLocation(
            int[] originalList,
            int valueToInsert,
            int index)
        {
            // Arrange
            var list = GetMyListInstance();
            var expectedList = new int?[originalList.Length];
            for (var i = 0; i < originalList.Length; i++)
            {
                if (i != index)
                    list.Add(originalList[i]);
                expectedList[i] = originalList[i];
            }

            // Act
            list.Add(valueToInsert, index);
            var equal = ListEquals(list, expectedList);

            // Assert
            Assert.True(equal);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(10)]
        public void Add_InvalidIndex_ThrowsException(int index)
        {
            // Arrange
            var list = GetMyListInstance();
            list.Add(1);
            list.Add(2);

            // Act
            Action action = () => list.Add(3, index);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public void Add_EndOfList_CorrectLocations()
        {
            // Arrange
            var list = GetMyListInstance();
            var expectedList = new int?[] {1, 20, 35, 42, 56};
            list.Add(1);
            list.Add(20);
            list.Add(35);
            list.Add(42);
            list.Add(56);

            // Act
            var listEqual = ListEquals(list, expectedList);

            // Assert
            Assert.True(listEqual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(4)]
        public void Remove_IntList_CorrectLocations(int index)
        {
            // Arrange
            var list = GetMyListInstance();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            var expectedList = new int?[4];
            var positionCounter = 0;
            for (var i = 0; i < list.Count; i++)
            {
                if (i != index) 
                {
                    expectedList[positionCounter] = i + 1;
                    positionCounter++;
                }
            }

            // Act
            list.Remove(index);
            var listEqual = ListEquals(list, expectedList);

            // Assert
            Assert.True(listEqual);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(5)]
        public void Remove_InvalidIndex_ThrowsException(int index)
        {
            // Arrange
            var list = GetMyListInstance();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            // Act
            Action action = () => list.Remove(index);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(action);
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

        [Theory]
        [InlineData(-10)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        public void Contains_IntList_ReturnsFalse(int value)
        {
            // Arrange
            var list = GetMyListInstance();
            list.Add(-11);
            list.Add(-9);
            list.Add(-2);
            list.Add(2);
            list.Add(9);
            list.Add(11);

            // Act
            var result = list.Contains(value);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Contains_EmptyList_ReturnsFalse()
        {
            // Arrange
            var list = GetMyListInstance();

            // Act
            var result = list.Contains(1);

            // Assert
            Assert.False(result);
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

        [Fact]
        public void Contains_NoNullValue_ReturnsFalse()
        {
            // Arrange
            var list = GetMyListInstance();
            list.Add(1);
            list.Add(2);
            list.Add(10);

            // Act
            var result = list.Contains(null);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Clear_IntList_EmptyList()
        {
            // Arrange
            var list = GetMyListInstance();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(null);

            // Act
            list.Clear();

            // Assert
            Assert.Equal(0, list.Count);
        }

        [Fact]
        public void Clear_EmptyList_EmptyList()
        {
            // Arrange
            var list = GetMyListInstance();

            // Act
            list.Clear();

            // Assert
            Assert.Equal(0, list.Count);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        [InlineData(5)]
        public void Get_IntList_CorrectValue(int index)
        {
            // Arrange
            var list = GetMyListInstance();
            var expectedValues = new int?[] {1, 20, 35, 42, 56, null};
            list.Add(1);
            list.Add(20);
            list.Add(35);
            list.Add(42);
            list.Add(56);
            list.Add(null);

            // Act
            var result = list.Get(index);

            // Assert
            Assert.Equal(expectedValues[index], result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(10)]
        public void Get_InvalidIndex_ThrowsException(int index)
        {
            // Arrange
            var list = GetMyListInstance();
            list.Add(1);
            list.Add(2);

            // Act
            Action action = () => list.Get(index);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }

        private bool ListEquals<T>(IMyList<T> l1, T[] l2)
        {
            if (l1.Count != l2.Length) return false;
            for (var i = 0; i < l1.Count; i++)
            {
                if (!l1.Get(i)!.Equals(l2[i])) return false;
            }

            return true;
        }
    }
}