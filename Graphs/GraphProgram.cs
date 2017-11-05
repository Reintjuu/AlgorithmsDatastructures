using System;

namespace ADCode.Graphs
{
	public class GraphProgram
	{
		public GraphProgram()
		{
			Graph g = new Graph();
			g.AddEdge("A", "B", 1);
			g.AddEdge("B", "C", 2);
			g.AddEdge("A", "C", 3);
			g.AddEdge("C", "A", 4);
			g.Unweighted("B");
			g.PrintPath("C");
			Console.WriteLine(g.GetVertex("A"));
			Console.WriteLine(g);
		}
	}
}