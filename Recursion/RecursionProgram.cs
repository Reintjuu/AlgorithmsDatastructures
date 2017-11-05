using System;
using System.Collections.Generic;

namespace ADCode.Recursion
{
	public class RecursionProgram
	{
		public RecursionProgram()
		{
			// Console.WriteLine(Factorial.RecursiveFactorial(5));
			var list = new List<int> {1, 2, 3, 4, 5};
			Recursion.PrintForward(list, 0);
			Console.WriteLine();
			Recursion.PrintBackward(list, list.Count - 1);
		}
	}
}