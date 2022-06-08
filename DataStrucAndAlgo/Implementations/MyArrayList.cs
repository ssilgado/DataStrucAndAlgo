using DataStrucAndAlgo.Interfaces;

namespace DataStrucAndAlgo.Implementations
{
    public class MyArrayList<T> : IMyList<T>
    {
        private T[] _items;
        private int _count;

        public MyArrayList(int initCapacity = 16)
        {
            if (initCapacity <= 0)
                throw new System.ArgumentException(
                    "Capacity cannot be less than or equal to zero"
                );

            _items = new T[initCapacity];
            _count = 0;
        }

        /// <summary>
        /// Checks if the list if full and if so, doubles the size of the list.
        /// </summary>
        private void EnsureCapacity()
        {
            if (_count == _items.Length)
            {
                var newItems = new T[_items.Length * 2];
                Array.Copy(_items, newItems, _items.Length);
                _items = newItems;
            }
        }

        /// <inheritdoc />
        public int Count { get { return _count; } }

        /// <inheritdoc />
        public void Add(T item, int index)
        {
            if (index < 0 || index > _count)
                throw new ArgumentOutOfRangeException(nameof(index));

            EnsureCapacity();

            if (index == _count)
            {
                _items[_count] = item;
                _count++;
            }
            else
            {
                for (int i = _count; i > index; i--)
                {
                    _items[i] = _items[i - 1];
                }
                _items[index] = item;
                _count++;
            }
        }

        /// <inheritdoc />
        public void Add(T item)
        {
            Add(item, _count);
        }

        /// <inheritdoc />
        public void Remove(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();

            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _count--;
        }

        /// <inheritdoc />
        public bool Contains(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_items[i].Equals(item)) return true;
            }

            return false;
        }

        /// <inheritdoc />
        public void Clear()
        {
            _items = new T[_items.Length];
            _count = 0;
        }

        /// <inheritdoc />
        public T Get(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();

            return _items[index];
        }

    }


}