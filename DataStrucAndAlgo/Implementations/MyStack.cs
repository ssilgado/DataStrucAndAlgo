using DataStrucAndAlgo.Interfaces;

namespace DataStrucAndAlgo.Implementations
{
    /// <summary>
    /// My stack implementation.
    /// </summary>
    public class MyStack<T>
    {
        private IMyList<T> _list;

        /// <summary>
        /// Initialize a new instance of the <see cref="MyStack{T}"/> class.
        /// </summary>
        /// <param name="list">
        /// The list to use for the stack. The list will be cleared before use.
        ///</param>
        public MyStack(IMyList<T> list)
        {
            list.Clear();
            _list = list;
        }

        /// <summary>
        /// Gets the size of the stack.
        /// </summary>
        public int Count => _list.Count;

        /// <summary>
        /// Push an item onto the stack.
        /// </summary>
        public void Push(T item)
        {
            _list.Add(item, 0);
        }

        /// <summary>
        /// Pop an item off the stack.
        /// </summary>
        /// <returns>The item popped off the stack.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the stack is empty.
        /// </exception>
        public T Pop()
        {
            try
            {
                var item = _list.Get(0);
                _list.Remove(0);
                return item;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

        }

        /// <summary>
        /// Peek at the top item on the stack. Does not remove the item.
        /// </summary>
        /// <returns>The top item on the stack.</returns>
        public T Peek()
        {
            try
            {
                return _list.Get(0);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new InvalidOperationException("The stack is empty.");
            }
        }

        /// <summary>
        /// Checks if the stack is empty.
        /// </summary>
        /// <returns>True if the stack is empty, false otherwise.</returns>
        public bool IsEmpty() => _list.Count == 0;
    }
}