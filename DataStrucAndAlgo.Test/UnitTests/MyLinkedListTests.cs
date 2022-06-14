using DataStrucAndAlgo.Implementations;
using DataStrucAndAlgo.Interfaces;

namespace DataStrucAndAlgo.Test.UnitTests;

public class MyLinkedListTests : MyListTests
{
    protected override IMyList<int?> GetMyListInstance()
    {
        return new MyLinkedList<int?>();
    }
}