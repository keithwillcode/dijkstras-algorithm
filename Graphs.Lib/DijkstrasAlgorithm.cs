using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs.Lib
{
    public class DijkstrasAlgorithm
    {
        private readonly WeightedGraph graph;

        public DijkstrasAlgorithm(WeightedGraph graph)
        {
            this.graph = graph;
        }

        public IEnumerable<Vertex> GetShortestPath(Vertex from, Vertex to)
        {
            var verticesToVisit = new HashSet<Vertex>();
            var verticesVisited = new HashSet<Vertex>();
            foreach (var vertex in graph.Vertices)
            {
                verticesToVisit.Add(vertex);
            }

            from.CalibrateWeight(0, null);
            var current = from;

            while (verticesToVisit.Any())
            {
                if (current == to)
                {
                    break;
                }

                var smallestWeightedVertex = current.Edges.First().ConnectedTo;

                foreach (var edge in current.Edges)
                {
                    var potentialNewValue = current.Value + edge.Weight;

                    if (potentialNewValue < edge.ConnectedTo.Value)
                    {
                        edge.ConnectedTo.CalibrateWeight(potentialNewValue, current);
                    }

                    if (potentialNewValue < smallestWeightedVertex.Value)
                    {
                        smallestWeightedVertex = edge.ConnectedTo;
                    }
                }

                verticesVisited.Add(current);
                verticesToVisit.Remove(current);

                current = smallestWeightedVertex;
            }

            var path = new HashSet<Vertex>();
            while (current != null)
            {
                path.Add(current);
                current = current.Via;
            }

            return path.Reverse();
        }
    }
}
