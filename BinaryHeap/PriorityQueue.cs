using System;
using System.Collections.Generic;

namespace ADCode.BinaryHeap
{
	public class PriorityQueue<T>
	{
		private const int DEFAULT_CAPACITY = 100;

		/// <summary>
		/// Number of elements in the heap.
		/// </summary>
		private int currentSize;

		private T[] heap;
		private readonly IComparer<T> comparer;

		/// <summary>
		/// Construct an empty PriorityQueue.
		/// </summary>
		public PriorityQueue()
		{
			currentSize = 0;
			heap = new T[DEFAULT_CAPACITY + 1];
		}

		/// <summary>
		/// Construct a PriorityQueue with a specified comparer.
		/// </summary>
		/// <param name="comparer">The comparer</param>
		public PriorityQueue(IComparer<T> comparer) : this()
		{
			this.comparer = comparer;
		}

		public PriorityQueue(IComparer<T> comparer, ICollection<T> collection)
		{
			this.comparer = comparer;
			AddFreely(collection);
		}

		/// <summary>
		/// Construct a PriorityQueue from another Collection.
		/// </summary>
		/// <param name="collection">The collection</param>
		public PriorityQueue(ICollection<T> collection)
		{
			AddFreely(collection);
		}

		public void AddFreely(ICollection<T> collection)
		{
			currentSize = collection.Count;

			heap = new T[(currentSize + 2) * 11 / 10];

			int i = 1;
			foreach (var item in collection)
			{
				heap[i++] = item;
			}

			BuildHeap();
		}

		public int Size()
		{
			return currentSize;
		}

		public bool IsEmpty()
		{
			return currentSize == 0;
		}

		public void Clear()
		{
			currentSize = 0;
		}
		
		public void BuildHeap()
		{
			for (int i = currentSize / 2; i > 0; i--)
			{
				PercolateDown(i);
			}
		}

		/// <returns>The highest item in the priority queue.</returns>
		/// <exception cref="NullReferenceException">If empty.</exception>
		public T FindHighestPriority()
		{
			if (IsEmpty())
			{
				throw new NullReferenceException("There are no items in the heap.");
			}

			return heap[1];
		}

		/// <summary>
		/// Adds an item to the PriorityQueue.
		/// </summary>
		/// <param name="item">The item to add.</param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public bool Add(T item)
		{
			if (currentSize + 1 == heap.Length)
			{
				DoubleArray();
			}

			// Percolate up.
			int hole = ++currentSize;
			heap[0] = item;

			for (; Compare(item, heap[hole / 2]) < 0; hole /= 2)
			{
				heap[hole] = heap[hole / 2];
			}

			heap[hole] = item;

			return true;
		}

		/// <summary>
		/// Removes the item with the highest priority.
		/// </summary>
		/// <returns>The item with the highest priority.</returns>
		public T Remove()
		{
			T minItem = FindHighestPriority();
			heap[1] = heap[currentSize--];
			PercolateDown(1);

			return minItem;
		}

		/// <summary>
		/// Percolate down in the heap.
		/// </summary>
		/// <param name="hole">The index at which the percolate begins.</param>
		private void PercolateDown(int hole)
		{
			int child;
			T temp = heap[hole];

			for (; hole * 2 <= currentSize; hole = child)
			{
				child = hole * 2;
				if (child != currentSize && Compare(heap[child + 1], heap[child]) < 0)
				{
					child++;
				}

				if (Compare(heap[child], temp) < 0)
				{
					heap[hole] = heap[child];
				}
				else
				{
					break;
				}
			}

			heap[hole] = temp;
		}

		private void DoubleArray()
		{
			Array.Resize(ref heap, heap.Length * 2);
		}

		private int Compare(T left, T right)
		{
			return comparer?.Compare(left, right) ?? ((IComparable) left).CompareTo(right);
		}

		public override string ToString()
		{
			return string.Join(", ", heap);
		}
		
//		// Stolen from Tim.
//		public override string ToString()
//		{
//			string res = "";
//			string spacing = "  "; // mostly length of elements (string length) + 1 space is enough
//			int noOfRows = (int) Math.Ceiling(Math.Log(Convert.ToDouble(currentSize), 2.0));
//			int lengthOfLastRow = (int) Math.Pow(2, noOfRows - 1);
//			for (int i = 1; i < currentSize; i++)
//			{
//				if (Math.Log(Convert.ToDouble(i), 2.0) == Math.Round(Math.Log(Convert.ToDouble(i), 2.0)))
//				{
//					res += '\n';
//					int offset = OffsetFactor((int) Math.Ceiling(Math.Log(i, 2))+1, lengthOfLastRow);
//					for (int j = 0; j < offset; j++)
//					{
//						res += spacing;
//					}
//				}
//               
//				res += heap[i];
//				int spacingFactor = SpacingFactor((int) Math.Floor(Math.Log(i, 2)) + 1, lengthOfLastRow);
//				//Console.WriteLine("index: {0} rowNumb: {1} with spacing: {2}", i, (int) Math.Ceiling(Math.Log(i, 2)) + 1, spacingFactor);
//				for (int j = 0; j < spacingFactor; j++)
//				{
//					res += spacing;
//				}
//			}
//			return res;
//		}
//		
//		// current row number and length of bottom row; helper function for ToString
//		private int OffsetFactor(int currRow, int lobr)
//		{
//			if (currRow == 1)
//				return (lobr + (lobr - 1)) / 2;
//			return OffsetFactor(currRow - 1, lobr) / 2;
//		}
//
//		// helper function for ToString
//		private int SpacingFactor(int currRow, int lobr)
//		{
//			if (currRow == 1)
//				return lobr + (lobr - 1);
//			return SpacingFactor(currRow - 1, lobr) / 2;
//		}
	}
}