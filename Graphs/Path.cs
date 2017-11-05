using System;

namespace ADCode.Graphs
{
	public class Path : IComparable<Path>
	{
		public Vertex dest;
		public double cost;

		public Path(Vertex dest, double cost)
		{
			this.dest = dest;
			this.cost = cost;
		}

		public int CompareTo(Path other)
		{
			return cost < other.cost ? -1 :
				cost > other.cost ? 1 : 0;
		}
	}
}