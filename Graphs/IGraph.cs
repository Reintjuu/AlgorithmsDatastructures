namespace ADCode.Graphs
{
	public interface IGraph
	{
		Vertex GetVertex(string name);
		void AddEdge(string source, string dest, int cost);
		string ToString();
	}
}