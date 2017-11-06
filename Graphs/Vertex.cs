using System.Collections.Generic;
using System.Linq;

namespace ADCode.Graphs
{
	public class Vertex : IVertex
	{
		public string name;
		public LinkedList<Edge> neighbors;
		public int dist;
		public Vertex prev;
		public int scratch;

		public Vertex(string name)
		{
			this.name = name;
			neighbors = new LinkedList<Edge>();
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
			           (dist != int.MaxValue ? $"({dist})" : "(-1)") +
			           (neighbors.Any() ? " --> " : string.Empty);

			foreach (Edge edge in neighbors)
			{
				s += edge.dest.name + $"({edge.cost}) ";
			}

			return s;
		}
	}
}