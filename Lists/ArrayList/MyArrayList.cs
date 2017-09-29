using System;

namespace ADCode.Lists.ArrayList
{
    public class MyArrayList<T> : IArrayList<T>
    {
        private T[] array;
        private int currentIndex;

        private readonly int capacity;

        public MyArrayList(int capacity)
        {
            this.capacity = capacity;
            Clear();
        }

        public void Add(T item)
        {
            if (currentIndex > array.Length)
            {
                throw new IndexOutOfRangeException();
            }

            array[currentIndex] = item;
            currentIndex++;
        }

        public T Get(int index)
        {
            if (index > currentIndex)
            {
                throw new IndexOutOfRangeException();
            }

            return array[index];
        }

        public void Set(int index, T item)
        {
            if (index >= currentIndex)
            {
                throw new IndexOutOfRangeException();
            }

            array[index] = item;
        }

        public void Print()
        {
            for (int i = 0; i < currentIndex; i++)
            {
                Console.Write((i > 0 ? ", " : "") + array[i]);
            }
            
            Console.Write('\n');
        }

        public void Clear()
        {
            array = new T[capacity];
            currentIndex = 0;
        }

        public int CountOccurences(T item)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(item))
                {
                    count++;
                } 
            }
            
            return count;
        }
    }
}