using System;
using ADCode.Graphs;

namespace ADCode.Toets
{
	public class Opgave4
	{
		public Opgave4()
		{
			Graph g = new Graph();
			g.AddEdge("A", "B", 1);
			g.AddEdge("A", "G", 1);
			g.AddEdge("C", "B", 1);
			g.AddEdge("D", "F", 1);
			g.AddEdge("D", "G", 1);
			g.AddEdge("E", "C", 1);
			g.AddEdge("F", "F", 1);
			g.AddEdge("G", "D", 1);
			g.AddEdge("G", "F", 1);
			g.AddEdge("G", "H", 1);
			g.AddEdge("H", "K", 1);
			g.AddEdge("H", "E", 1);
			g.AddEdge("K", "G", 1);

			g.Unweighted("G");
			Console.WriteLine($"G can go to: {g.GetVertex("G")}");
			Console.WriteLine();
			Console.WriteLine(g);
			Console.WriteLine();
			Console.WriteLine($"A has a cyle: {g.HasCycle("A")}");
			Console.WriteLine();
			
			g.ShowCycles();
		}
	}
}