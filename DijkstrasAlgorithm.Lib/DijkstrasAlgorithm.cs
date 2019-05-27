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

        public List<Vertex> GetShortestPath(Vertex from, Vertex to)
        {
            var pathVertices = new List<Vertex>();
            var verticesToVisit = new HashSet<Vertex>();

            foreach (var vertex in graph.Vertices)
            {
                verticesToVisit.Add(vertex);
            }

            var current = from;
            pathVertices.Add(from);

            while (verticesToVisit.Any())
            {
                if (current == to)
                {
                    break;
                }

                var smallestVertex = current.Edges.First().ConnectedTo;

                foreach (var edge in current.Edges)
                {
                    if (!graph.Vertices.Contains(edge.ConnectedTo))
                        continue;

                    verticesToVisit.Remove(edge.ConnectedTo);

                    var weightOfChoice = current.Value + edge.Weight;

                    if (edge.ConnectedTo.WeightHasBeenCalibrated() == false || weightOfChoice < edge.ConnectedTo.Value)
                    {
                        edge.ConnectedTo.CalibrateWeight(weightOfChoice);
                    }

                    if (smallestVertex.Value > weightOfChoice)
                    {
                        smallestVertex = edge.ConnectedTo;
                    }
                }

                pathVertices.Add(smallestVertex);
                current = smallestVertex;
            }

            return pathVertices;
        }
    }
}
