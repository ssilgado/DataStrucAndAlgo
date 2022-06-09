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
}