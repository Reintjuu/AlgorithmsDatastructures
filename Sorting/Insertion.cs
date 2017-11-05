using System;

namespace ADCode.Sorting
{
	public static class Insertion
	{
		public static void InsertionSort<T>(this T[] a) where T : IComparable
		{
			for (int i = 1; i < a.Length; i++)
			{
				T temp = a[i];
				int j = i;

				for (; j > 0 && temp.CompareTo(a[j - 1]) < 0; j--)
				{
					a[j] = a[j - 1];
				}
				
				a[j] = temp;
			}
		}
	}
}