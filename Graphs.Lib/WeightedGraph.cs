using System;
using System.Collections.Generic;

namespace Graphs.Lib
{
    public class WeightedGraph
    {
        public HashSet<Edge> Edges { get; private set; }
        public HashSet<Vertex> Vertices { get; private set; }

        public WeightedGraph()
        {
            Vertices = new HashSet<Vertex>();
        }

        public void AddVertex(Vertex vertex)
        {
            if (vertex == null)
                throw new ArgumentNullException(nameof(vertex));

            Vertices.Add(vertex);
        }
    }
}
