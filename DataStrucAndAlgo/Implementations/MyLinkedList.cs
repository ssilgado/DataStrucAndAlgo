using DataStrucAndAlgo.Interfaces;

namespace DataStrucAndAlgo.Implementations
{
    /// <summary>
    /// My linked node based list implementation.
    /// </summary>
    public class MyLinkedList<T> : IMyList<T>
    {
        private Node<T>? _head;

        /// <inheritdoc />
        public int Count { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyLinkedList{T}"/>
        /// class.
        /// </summary>
        public MyLinkedList()
        {
            _head = null;
            Count = 0;
        }

        /// <inheritdoc />
        public void Add(T item, int index)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            
            var newNode = new Node<T>(item);

            if (index == 0)
            {
                newNode.Next = _head;
                _head = newNode;
            }
            else
            {
                var current = _head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current!.Next;
                }
                newNode.Next = current!.Next;
                current.Next = newNode;
            }

            Count++;
        }

        /// <inheritdoc />
        public void Add(T item)
        {
            Add(item, Count);
        }

        /// <inheritdoc />
        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        /// <inheritdoc />
        public bool Contains(T item)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Value!.Equals(item)) return true;
                current = current.Next;
            }
            return false;
        }

        /// <inheritdoc />
        public T Get(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            
            var current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current!.Next;
            }

            return current!.Value;
        }

        /// <inheritdoc />
        public void Remove(int index)
        {
            if (index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            
            if (index == 0)
            {
                _head = _head!.Next;
            }
            else
            {
                var current = _head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current!.Next;
                }
                current!.Next = current.Next!.Next;
            }

            Count--;
        }
    }

    /// <summary>
    /// Node class for a linked list.
    /// </summary>
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T>? Next { get; set; }

        public Node(T value)
        {
            Value = value;
        }
    }
}