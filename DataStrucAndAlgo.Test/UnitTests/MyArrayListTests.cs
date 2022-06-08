using DataStrucAndAlgo.Implementations;
using DataStrucAndAlgo.Interfaces;

namespace DataStrucAndAlgo.Test.UnitTest;

public class MyArrayListTests : MyListTests
{
    protected override IMyList<int?> GetMyListInstance()
    {
        return new MyArrayList<int?>();
    }
}