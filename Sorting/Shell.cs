using System;

namespace ADCode.Sorting
{
	public static class Shell
	{
		public static void ShellSort<T>(this T[] a) where T : IComparable
		{
			for (int gap = a.Length / 2; gap > 0; gap = gap == 2 ? 1 : (int) (gap / 2.2f))
			{
				for (int i = gap; i < a.Length; i++)
				{
					T temp = a[i];
					int j = i;

					for (; j >= gap && temp.CompareTo(a[j - gap]) < 0; j -= gap)
					{
						a[j] = a[j - gap];
					}
					
					a[j] = temp;
				}
			}
		}
	}
}