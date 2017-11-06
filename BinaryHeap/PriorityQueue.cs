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

		public bool IsMaxHeap()
		{
			T left = heap[2];
			T right = heap[3];

			T compareWith;
			// Check if left node exists.
			if (left != null)
			{
				// Set left node to compare with.
				compareWith = left;
			}
			else if (right != null)
			{
				// Else set the right node.
				compareWith = right;
			}
			else
			{
				throw new Exception("Not a Max- or MinHeap.");
			}

			return ((IComparable) heap[1]).CompareTo(compareWith) > 0;
		}

		public bool IsComplete()
		{
			int numberOfRows = (int) Math.Ceiling(Math.Log(currentSize + 1, 2));
			bool even = numberOfRows % 2 == 0;
			int maxAllowed = (int) Math.Pow(numberOfRows, 2) - (even ? 1 : 2);
			
			return currentSize <= maxAllowed;
		}

//		public override string ToString()
//		{
//			return string.Join(", ", heap);
//		}

		// Stolen from Tim.
		public override string ToString()
		{
			string s = String.Empty;
			string spacing = "  ";
			
			int numberOfRows = (int) Math.Ceiling(Math.Log(currentSize + 1, 2));
			int lengthOfLastRow = (int) Math.Pow(2, numberOfRows - 1);
			for (int i = 1; i < currentSize + 1; i++)
			{
				if (Math.Log(i, 2).CompareTo(Math.Round(Math.Log(i, 2))) == 0)
				{
					s += '\n';
					int offset = OffsetFactor((int) Math.Ceiling(Math.Log(i, 2)) + 1, lengthOfLastRow);
					for (int j = 0; j < offset; j++)
					{
						s += spacing;
					}
				}

				s += heap[i];
				int spacingFactor = SpacingFactor((int) Math.Floor(Math.Log(i, 2)) + 1, lengthOfLastRow);

				for (int j = 0; j < spacingFactor; j++)
				{
					s += spacing;
				}
			}

			return s;
		}

		private int OffsetFactor(int currentRow, int lengthOfBottomRow)
		{
			if (currentRow == 1)
			{
				return (lengthOfBottomRow + (lengthOfBottomRow - 1)) / 2;
			}

			return OffsetFactor(currentRow - 1, lengthOfBottomRow) / 2;
		}

		private int SpacingFactor(int currentRow, int lengthOfBottomRow)
		{
			if (currentRow == 1)
			{
				return lengthOfBottomRow + (lengthOfBottomRow - 1);
			}

			return SpacingFactor(currentRow - 1, lengthOfBottomRow) / 2;
		}
	}
}