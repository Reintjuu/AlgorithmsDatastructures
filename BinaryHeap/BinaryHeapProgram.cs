using System;
using System.Collections.Generic;

namespace ADCode.BinaryHeap
{
	public class BinaryHeapProgram
	{
		public BinaryHeapProgram()
		{
			List<int> list = new List<int> {5, 3, 2, 1, 9, 3, 2, 1};
			PriorityQueue<int> minHeap = new PriorityQueue<int>(list);
			Console.WriteLine(minHeap);

			PriorityQueue<int> maxHeap = new PriorityQueue<int>(new ReverseComparer<int>(), list);
			Console.WriteLine(maxHeap);
		}
	}
}