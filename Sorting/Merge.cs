using System;

namespace ADCode.Sorting
{
	public static class Merge
	{
		public static void MergeSort<T>(this T[] a) where T : IComparable
		{
			T[] tempArray = new T[a.Length];
			MergeSort(a, tempArray, 0, a.Length - 1);
		}

		private static void MergeSort<T>(T[] a, T[] tempArray, int left, int right) where T : IComparable
		{
			if (left < right)
			{
				int center = (left + right) / 2;
				MergeSort(a, tempArray, left, center);
				MergeSort(a, tempArray, center + 1, right);
				MergeArrays(a, tempArray, left, center + 1, right);
			}
		}

		private static void MergeArrays<T>(T[] a, T[] tempArray, int leftPos, int rightPos, int rightEnd)
			where T : IComparable
		{
			int leftEnd = rightPos - 1;
			int tempPos = leftPos;
			int numElements = rightEnd - leftPos + 1;

			while (leftPos <= leftEnd && rightPos <= rightEnd)
			{
				if (a[leftPos].CompareTo(a[rightPos]) <= 0)
				{
					tempArray[tempPos++] = a[leftPos++];
				}
				else
				{
					tempArray[tempPos++] = a[rightPos++];
				}
			}

			// Copy rest of first half.
			while (leftPos <= leftEnd)
			{
				tempArray[tempPos++] = a[leftPos++];
			}

			// Copy rest of right half.
			while (rightPos <= rightEnd)
			{
				tempArray[tempPos++] = a[rightPos++];
			}

			// Copy tempArray back.
			for (int i = 0; i < numElements; i++, rightEnd--)
			{
				a[rightEnd] = tempArray[rightEnd];
			}
		}
	}
}