using System;

namespace ADCode.Sorting
{
	public class QuickSort
	{
		public QuickSort()
		{
			var array = new int[] {5, 6, 2, 1, 0, 5, 2, 3, 6, 3, 7, 1, 3};
			Sort(array, 0, array.Length - 1);
			Print(array);
		}

		private void Sort(int[] array, int low, int high)
		{
			Print(array);

			if (low < high)
			{
				int pivot = MedianOfThree(array, low, high);
				Sort(array, low, pivot - 1);
				Sort(array, pivot + 1, high);
			}
		}

		private int Partition(int[] array, int low, int high)
		{
			int pivot = array[high];
			int i = low - 1;

			for (int j = low; j < high; j++)
			{
				if (array[j] <= pivot)
				{
					i++;
					Swap(array, i, j);
				}
			}

			Swap(array, i + 1, high);
			return i + 1;
		}

		private int MedianOfThree(int[] array, int low, int high)
		{
			int mid = (low + high) / 2;
			
			if (array[high] < array[low])
			{
				Swap(array, low, high);
			}
			
			if (array[mid] < array[low])
			{
				Swap(array, mid, low);
			}
			
			if (array[high] < array[mid])
			{
				Swap(array, high, mid);
			}
			
			return Partition(array, low, high);
		}


		private void Swap(int[] array, int a, int b)
		{
			var temp = array[a];
			array[a] = array[b];
			array[b] = temp;
		}

		private void Print(int[] array)
		{
			string s = string.Empty;
			for (int a = 0; a < array.Length; a++)
			{
				s += array[a] + " ";
			}

			Console.WriteLine(s);
		}
	}
}