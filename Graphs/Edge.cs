namespace ADCode.Graphs
{
	public class Edge
	{
		/// <summary>
		/// Second vertex in Edge.
		/// </summary>
		public Vertex dest;

		/// <summary>
		/// Edge cost.
		/// </summary>
		public int cost;

		public Edge(Vertex dest, int cost)
		{
			this.dest = dest;
			this.cost = cost;
		}
	}
}