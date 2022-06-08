using DataStrucAndAlgo.Interfaces;

namespace DataStrucAndAlgo.Implementations
{
    /// <summary>
    /// My array based list implementation.
    /// </summary>
    public class MyArrayList<T> : IMyList<T>
    {
        private T[] _items;

        /// <inheritdoc />
        public int Count { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyArrayList{T}"/>
        /// class.
        /// </summary>
        /// <param name="initCapacity">The initial capacity of the list.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="initCapacity"/> is less than zero.
        /// </exception>
        public MyArrayList(int initCapacity = 16)
        {
            if (initCapacity <= 0)
                throw new System.ArgumentException(
                    "Capacity cannot be less than or equal to zero"
                );

            _items = new T[initCapacity];
            Count = 0;
        }

        /// <summary>
        /// Checks if the list if full and if so, doubles the size of the list.
        /// </summary>
        private void EnsureCapacity()
        {
            if (Count == _items.Length)
            {
                var newItems = new T[_items.Length * 2];
                Array.Copy(_items, newItems, _items.Length);
                _items = newItems;
            }
        }       

        /// <inheritdoc />
        public void Add(T item, int index)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            EnsureCapacity();

            if (index == Count)
            {
                _items[Count] = item;
                Count++;
            }
            else
            {
                for (int i = Count; i > index; i--)
                {
                    _items[i] = _items[i - 1];
                }
                _items[index] = item;
                Count++;
            }
        }

        /// <inheritdoc />
        public void Add(T item)
        {
            Add(item, Count);
        }

        /// <inheritdoc />
        public void Remove(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            for (int i = index; i < Count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            Count--;
        }

        /// <inheritdoc />
        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i].Equals(item)) return true;
            }

            return false;
        }

        /// <inheritdoc />
        public void Clear()
        {
            _items = new T[_items.Length];
            Count = 0;
        }

        /// <inheritdoc />
        public T Get(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            return _items[index];
        }

    }
}