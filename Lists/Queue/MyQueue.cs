using System;
using ADCode.Lists.ArrayList;

namespace ADCode.Lists.Queue
{
	public class MyQueue<T> : IQueue<T>
	{
		private MyArrayList<T> arrayList;
		private int currentSize;

		private int capacity = 4;
		private int front;
		private int back;

		public MyQueue()
		{
			arrayList = new MyArrayList<T>(capacity);
			MakeEmpty();
		}

		public bool IsEmpty()
		{
			return currentSize == 0;
		}

		public void Enqueue(T item)
		{
			if (currentSize == capacity - 1)
			{
				DoubleArrayListSize();
			}

			back = Increment(back);
			arrayList.Set(back, item);
			currentSize++;
		}

		public T Dequeue()
		{
			if (IsEmpty())
			{
				throw new NullReferenceException("No more objects in the queue.");
			}
			currentSize--;
			
			var returnValue = arrayList.Get(front);
			front = Increment(front);
			return returnValue;
		}

		public int Size()
		{
			return currentSize;
		}

		public override string ToString()
		{
			string s = string.Empty;

			for (int i = front; i <= back; i++)
			{
				s += (i == front ? string.Empty : ", ") + arrayList.Get(i);
			}

			return s;
		}

		private int Increment(int x)
		{
			if (++x == capacity)
			{
				x = 0;
			}

			return x;
		}

		private void DoubleArrayListSize()
		{
			capacity *= 2;
			var newArrayList = new MyArrayList<T>(capacity);
			for (int i = 0; i < currentSize; i++, front = Increment(front))
			{
				newArrayList.Set(i, arrayList.Get(front));
			}

			arrayList = newArrayList;
			front = 0;
			back = currentSize - 1;
		}

		private void MakeEmpty()
		{
			currentSize = 0;
			front = 0;
			back = -1;
		}
	}
}