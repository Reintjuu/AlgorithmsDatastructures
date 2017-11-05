using System;
using System.Collections.Generic;
using System.Linq;
using ADCode.BinaryHeap;

namespace ADCode.Graphs
{
	public class Graph : IGraph
	{
		private readonly Dictionary<string, Vertex> vertices = new Dictionary<string, Vertex>();

		/// <summary>
		/// Adds a new edge to the graph.
		/// </summary>
		public void AddEdge(string sourceName, string destName, int cost)
		{
			Vertex v = GetVertex(sourceName);
			Vertex w = GetVertex(destName);
			v.adj.AddLast(new Edge(w, cost));
		}

		public void PrintPath(string destName)
		{
			if (!vertices.TryGetValue(destName, out Vertex w))
			{
				throw new NullReferenceException("There's no vertex with that name.");
			}

			if (w.dist == int.MaxValue)
			{
				Console.WriteLine($"{destName} is unreachable.");
			}
			else
			{
				Console.Write($"(Cost is: {w.dist}) ");
				PrintPath(w);
				Console.WriteLine();
			}
		}

		public void Unweighted(string startName)
		{
			ClearAll();

			if (!vertices.TryGetValue(startName, out Vertex start))
			{
				throw new NullReferenceException("Start vertex not found.");
			}

			Queue<Vertex> q = new Queue<Vertex>();
			q.Enqueue(start);
			start.dist = 0;

			while (q.Any())
			{
				Vertex v = q.Dequeue();

				foreach (Edge e in v.adj)
				{
					Vertex w = e.dest;

					if (w.dist == int.MaxValue)
					{
						w.dist = v.dist + 1;
						w.prev = v;
						q.Enqueue(w);
					}
				}
			}
		}

		public void Dijkstra(string startName)
		{
			PriorityQueue<Path> pq = new PriorityQueue<Path>();
			
			if (!vertices.TryGetValue(startName, out Vertex start))
			{
				throw new NullReferenceException("Start vertex not found.");
			}
			
			ClearAll();
			pq.Add(new Path(start, 0));
			start.dist = 0;

			int nodesSeen = 0;
			while (!pq.IsEmpty() && nodesSeen < vertices.Count)
			{
				Path vrec = pq.Remove();
				Vertex v = vrec.dest;
				
				// Already processed.
				if (v.scratch != 0)
				{
					continue;
				}

				v.scratch = 1;
				nodesSeen++;

				foreach (Edge edge in v.adj)
				{
					Vertex w = edge.dest;
					int cost = edge.cost;

					if (cost < 0)
					{
						throw new Exception("Graph has negative edges.");
					}

					if (w.dist > v.dist + cost)
					{
						w.dist = v.dist + cost;
						w.prev = v;
						pq.Add(new Path(w, w.dist));
					}
				}
			}
		}

		/// <summary>
		/// If vertexName is not present, add it to the vertices dictionary.
		/// </summary>
		/// <param name="vertexName">The name of the vertex to get.</param>
		/// <returns>The vertex.</returns>
		public Vertex GetVertex(string vertexName)
		{
			if (!vertices.TryGetValue(vertexName, out Vertex v))
			{
				v = new Vertex(vertexName);
				vertices.Add(vertexName, v);
			}

			return v;
		}

		/// <summary>
		/// Recursive routine to print shortest path to dest after running shortest path algorithm. The path is know to exist.
		/// </summary>
		private void PrintPath(Vertex dest)
		{
			if (dest.prev != null)
			{
				PrintPath(dest.prev);
				Console.Write(" to ");
			}

			Console.Write(dest.name);
		}

		/// <summary>
		/// Initializes the vertex ouput info prior to running any shortes path algorithm.
		/// </summary>
		private void ClearAll()
		{
			foreach (var vertex in vertices)
			{
				vertex.Value.Reset();
			}
		}

		public override string ToString()
		{
			return string.Join("\n", vertices.Values);
		}
	}
}