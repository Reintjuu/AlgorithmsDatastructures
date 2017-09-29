using System;
using ADCode.Lists.ArrayList;

namespace ADCode.Lists.Queue
{
	public class MyQueue<T> : IQueue<T>
	{
		private int capacity = 4;
		private int current;
		
		private MyArrayList<T> arrayList;
		
		public MyQueue()
		{
			arrayList = new MyArrayList<T>(capacity);
			current = 0;
		}


		public bool IsEmpty()
		{
			try
			{
				arrayList.Get(0);
				return false;
			}
			catch (NullReferenceException)
			{
				return true;
			}
		}

		public void Enqueue(T item)
		{
			try
			{
				arrayList.Add(item);
				current++;
			}
			catch (IndexOutOfRangeException)
			{
				// TODO: Fix
//				capacity *= 2;
//				MyArrayList<T> temp = arrayList;
//				temp = new MyArrayList<T>(capacity);
//				for (int i = 0; i < capacity / 2; i++)
//				{
//					arrayList.Add(temp.Get(i));
//				}
			}
			
		}

		public T Dequeue()
		{
			throw new System.NotImplementedException();
		}

		public int Size()
		{
			throw new System.NotImplementedException();
		}
	}
}