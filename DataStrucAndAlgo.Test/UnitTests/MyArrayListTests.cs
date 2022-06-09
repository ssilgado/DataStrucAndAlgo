using System;
using DataStrucAndAlgo.Implementations;
using DataStrucAndAlgo.Interfaces;
using Xunit;

namespace DataStrucAndAlgo.Test.UnitTest;

public class MyArrayListTests : MyListTests
{
    protected override IMyList<int?> GetMyListInstance()
    {
        return new MyArrayList<int?>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_InvalidCapacity_ThrowsException(int initialCapacity)
    {
        // Arrange
        Action action = () => new MyArrayList<int?>(initialCapacity);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(action);
    }

    [Fact]
    public void EnsureCapacity_AddEnoughItems_DoesNotThrowException()
    {
        // Arrange
        var list = new MyArrayList<int?>(initCapacity: 1);
        int numberOfItems = 32;
        var expectedList = new int?[numberOfItems];

        // Act
        for (int i = 0; i < numberOfItems; i++)
        {
            list.Add(i);
            expectedList[i] = i;
        }
        var listEquals = ListEquals(list, expectedList);

        // Assert
        Assert.True(listEquals);
    }
}