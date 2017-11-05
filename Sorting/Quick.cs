using System;

namespace ADCode.Sorting
{
	public static class Quick
	{
		public static void QuickSort<T>(this T[] a) where T : IComparable
		{
			QuickSort(a, 0, a.Length - 1);
		}

		private static void QuickSort<T>(T[] array, int low, int high) where T : IComparable
		{
			if (low >= high) return;

			int pivot = MedianOfThree(array, low, high);
			QuickSort(array, low, pivot - 1);
			QuickSort(array, pivot + 1, high);
		}

		private static int Partition<T>(T[] array, int low, int high) where T : IComparable
		{
			int i = low - 1;

			for (int j = low; j < high; j++)
			{
				if (array[j].CompareTo(array[high]) <= 0)
				{
					i++;
					Swap(array, i, j);
				}
			}

			Swap(array, i + 1, high);
			return i + 1;
		}

		private static int MedianOfThree<T>(T[] array, int low, int high) where T : IComparable
		{
			int mid = (low + high) / 2;

			if (array[high].CompareTo(array[low]) < 0)
			{
				array.Swap(low, high);
			}

			if (array[mid].CompareTo(array[low]) < 0)
			{
				array.Swap(mid, low);
			}

			if (array[high].CompareTo(array[mid]) < 0)
			{
				array.Swap(high, mid);
			}

			return Partition(array, low, high);
		}

		/// <summary>
		/// Swaps two values in an array.
		/// </summary>
		/// <param name="array">The reference to the array to swap items in.</param>
		/// <param name="a">The index of the first item to swap.</param>
		/// <param name="b">The index of the second item to swap.</param>
		private static void Swap<T>(this T[] array, int a, int b)
		{
			var temp = array[a];
			array[a] = array[b];
			array[b] = temp;
		}
	}
}