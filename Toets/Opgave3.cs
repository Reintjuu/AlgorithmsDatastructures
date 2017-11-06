using System;
using System.Collections.Generic;
using ADCode.BinaryHeap;

namespace ADCode.Toets
{
	public class Opgave3
	{
		public Opgave3()
		{
			PriorityQueue<int> maxHeap1 = new PriorityQueue<int>(new ReverseComparer<int>(), new List<int> {10, 4, 7, 1, 3, 5});
			Console.WriteLine(maxHeap1);
			Console.WriteLine($"Is MaxHeap: {maxHeap1.IsMaxHeap()}");
			Console.WriteLine($"Is complete: {maxHeap1.IsComplete()}");
			
			PriorityQueue<int> maxHeap2 =
				new PriorityQueue<int>(new ReverseComparer<int>(), new List<int> {15, 5, 11, 3, 4, 10, 7, 1});
			Console.WriteLine(maxHeap2);
			Console.WriteLine($"Is MaxHeap: {maxHeap2.IsMaxHeap()}");
			Console.WriteLine($"Is complete: {maxHeap2.IsComplete()}");
		}
	}
}