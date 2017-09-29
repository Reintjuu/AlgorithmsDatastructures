using System;
using System.Collections.Generic;
using ADCode.BinaryTrees;
using ADCode.Lists;
using ADCode.Recursion;
using ADCode.Sorting;

namespace ADCode
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			// new ListProgram();
			// new RecursionProgram();
			// new BinaryTreesProgram();
			Console.WriteLine(new QuickSort(new[] {5, 6, 2, 1, 0, 5, 2, 3, 6, 3, 7, 1, 3}));
		}
	}
}