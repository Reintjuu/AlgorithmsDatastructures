using System.Collections.Generic;
using System.Linq;

namespace ADCode.Graphs
{
	public class Vertex : IVertex
	{
		public string name;
		public LinkedList<Edge> adj;
		public int dist;
		public Vertex prev;
		public int scratch;

		public Vertex(string name)
		{
			this.name = name;
			adj = new LinkedList<Edge>();
			Reset();
		}

		public void Reset()
		{
			dist = int.MaxValue;
			prev = null;
			scratch = 0;
		}

		public override string ToString()
		{
			string s = name +
			           (dist != int.MaxValue ? $"({dist})" : string.Empty) +
			           (adj.Any() ? " --> " : string.Empty);

			foreach (Edge edge in adj)
			{
				s += edge.dest.name + $"({edge.cost}) ";
			}

			return s;
		}
	}
}