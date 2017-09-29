using System;

namespace ADCode.Lists.LinkedList
{
    public class MyLinkedList<T> : ILinkedList<T>
    {
        private readonly Node<T> header;

        public MyLinkedList()
        {
            header = new Node<T>();
        }

        public void AddFirst(T data)
        {
            var newNode = new Node<T>(data);
            newNode.next = header.next;
            header.next = newNode;
        }

        public void Clear()
        {
            header.next = null;
        }

        public void Print()
        {
            var current = header.next;
            Console.Write('[');
            while (current != null)
            {
                Console.Write(current.Data);
                if (current.next != null)
                {
                    Console.Write(", ");
                }

                current = current.next;
            }

            Console.Write("]\n");
        }

        public void Insert(int index, T data)
        {
            var current = header;

            for (int i = 0; i < index; i++)
            {
                current = current.next;
                if (current == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            var newNode = new Node<T>(data);
            newNode.next = current.next;
            current.next = newNode;
        }

        public void RemoveFirst()
        {
            if (header.next == null)
            {
                throw new NullReferenceException();
            }

            var cache = header.next.next;
            header.next = cache;
        }

        public T GetFirst()
        {
            if (header.next == null)
            {
                throw new NullReferenceException();
            }

            return header.next.Data;
        }
    }
}