using System;
using System.Collections.Generic;

namespace ADCode.Recursion
{
	public static class Recursion
	{
		public static void PrintForward(List<int> list, int i)
		{
			if (i < 0 || i >= list.Count)
			{
				return;
			}
			
			Console.Write(list[i] + (i < list.Count - 1 ? ", " : string.Empty));
			PrintForward(list, i + 1);
		}
		
		public static void PrintBackward(List<int> list, int i)
		{
			if (i < 0 || i >= list.Count)
			{
				return;
			}
			
			Console.Write(list[i] + (i > 0 ? ", " : string.Empty));
			PrintBackward(list, i - 1);
		}
	}
}