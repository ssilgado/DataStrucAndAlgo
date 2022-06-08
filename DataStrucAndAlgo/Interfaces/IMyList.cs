namespace DataStrucAndAlgo.Interfaces
{
    /// <summary>
    /// Interface for my generic list.
    /// </summary>
    public interface IMyList<T>
    {
        /// <summary>
        /// Gets the number of items in the list.
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Adds an item at a specific index of the list.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <param name="index">The index to add the item at.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the index is out of range.
        /// </exception>
        void Add(T item, int index);

        /// <summary>
        /// Adds an item to the end of the list.
        /// </summary>
        /// <param name="item">The item to add.</param>
        void Add(T item);

        /// <summary>
        /// Removes the item at the specified index.
        /// </summary>
        /// <param name="index">The index of the item to remove.</param>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown if the <paramref name="index"/> is out of range.
        /// </exception>
        void Remove(int index);

        /// <summary>
        /// Checks if the list contains the specified item.
        /// </summary>
        /// <param name="item">The item to check for.</param>
        /// <returns>
        /// True if the list contains the item, false otherwise.
        /// </returns>
        bool Contains(T item);

        /// <summary>
        /// Clears the list.
        /// </summary>
        void Clear();

        /// <summary>
        /// Gets the item at the specified index.
        /// </summary>
        /// <param name="index">The index of the item to get.</param>
        /// <returns>The item at the specified index.</returns>
        /// <exception cref="IndexOutOfRangeException">
        /// Thrown if the <paramref name="index"/> is out of range.
        /// </exception>
        T Get(int index);
    }
}