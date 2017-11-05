using System;

namespace ADCode.Sorting
{
	public class SortingProgram
	{
		public SortingProgram()
		{
			int[] insertion = {5, 6, 2, 1, 0, 5, 2, 3, 6, 3, 7, 1, 3};
			insertion.InsertionSort();
			Console.WriteLine($"InsertionSort:\t{string.Join(", ", insertion)}");
			
			int[] shell = {5, 6, 2, 1, 0, 5, 2, 3, 6, 3, 7, 1, 3};
			shell.ShellSort();
			Console.WriteLine($"ShellSort:\t{string.Join(", ", shell)}");

			int[] merge = {5, 6, 2, 1, 0, 5, 2, 3, 6, 3, 7, 1, 3};
			merge.MergeSort();
			Console.WriteLine($"MergeSort:\t{string.Join(", ", merge)}");
			
			int[] quick = {5, 6, 2, 1, 0, 5, 2, 3, 6, 3, 7, 1, 3};
			quick.QuickSort();
			Console.WriteLine($"QuickSort:\t{string.Join(", ", quick)}");
		}
	}
}