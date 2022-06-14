using System;
using DataStrucAndAlgo.Implementations;
using Xunit;

namespace DataStrucAndAlgo.Test.UnitTests
{
    public class MyStackTests
    {
        [Fact]
        public void Count_EmptyStack_ZeroCount()
        {
            // Arrange
            var list = new MyArrayList<int?>();
            var stack = new MyStack<int?>(list);
            var expectedCount = 0;

            // Act
            var count = stack.Count;

            // Assert
            Assert.Equal(expectedCount, count);
        }

        [Fact]
        public void Count_NonEmptyList_ZeroCount()
        {
            // Arrange
            var list = new MyArrayList<int?>();
            list.Add(1);
            list.Add(2);
            var stack = new MyStack<int?>(list);
            var expectedCount = 0;

            // Act
            var count = stack.Count;

            // Assert
            Assert.Equal(expectedCount, count);
        }

        [Fact]
        public void Count_NonEmptyStack_CorrectCount()
        {
            // Arrange
            var list = new MyLinkedList<int?>();
            var stack = new MyStack<int?>(list);
            var items = new int?[] { 1, 2, 3, 4, 5 };
            foreach (var item in items)
            {
                stack.Push(item);
            }

            // Act
            var count = stack.Count;

            // Assert
            Assert.Equal(items.Length, count);
        }

        [Fact]
        public void PushPop_EmptyStack_CorrectOrder()
        {
            // Arrange
            var stack = new MyStack<int?>(new MyLinkedList<int?>());
            var items = new int? [] {1, 2, 3, 4, 5};

            // Act
            foreach (var item in items)
            {
                stack.Push(item);
            }
            Array.Reverse(items);

            // Assert
            var i = 0;
            while (stack.Count > 0)
            {
                Assert.Equal(items[i], stack.Pop());
                i++;
            }
            Assert.Equal(items.Length, i); // Ensure we iterated over all items
            Assert.Equal(0, stack.Count); // Ensure stack is empty
        }

        [Fact]
        public void Pop_EmptyStack_ThrowsException()
        {
            // Arrange
            var stack = new MyStack<int?>(new MyLinkedList<int?>());

            // Act
            Action action = () => stack.Pop();

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void Peek_NonEmptyStack_CorrectValue()
        {
            // Arrange
            var stack = new MyStack<int?>(new MyLinkedList<int?>());
            var items = new int?[] { 1, 2, 3, 4, 5 };
            foreach (var item in items)
            {
                stack.Push(item);
            }

            // Act
            var peekedItem = stack.Peek();

            // Assert
            Assert.Equal(items[items.Length - 1], peekedItem);
            Assert.Equal(items.Length, stack.Count);
        }

        [Fact]
        public void Peek_EmptyStack_ThrowsException()
        {
            // Arrange
            var stack = new MyStack<int?>(new MyLinkedList<int?>());

            // Act
            Action action = () => stack.Peek();

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Fact]
        public void IsEmpty_EmptyStack_True()
        {
            // Arrange
            var stack = new MyStack<int?>(new MyLinkedList<int?>());

            // Act
            var isEmpty = stack.IsEmpty();

            // Assert
            Assert.True(isEmpty);
        }

        [Fact]
        public void IsEmpty_NonEmptyStack_False()
        {
            // Arrange
            var stack = new MyStack<int?>(new MyLinkedList<int?>());
            stack.Push(1);

            // Act
            var isEmpty = stack.IsEmpty();

            // Assert
            Assert.False(isEmpty);
        }
    }
}