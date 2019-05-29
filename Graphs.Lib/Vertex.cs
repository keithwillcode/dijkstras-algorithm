using System;
using System.Collections.Generic;

namespace Graphs.Lib
{
    public class Vertex
    {
        public HashSet<Edge> Edges { get; private set; }
        public String Name { get; private set; }
        public Int32 Value { get; private set; }
        public Vertex Via { get; private set; }

        public Vertex(String name)
        {
            Edges = new HashSet<Edge>();
            Name = name;
            Value = Int32.MaxValue;
        }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }

        public void CalibrateWeight(Int32 value, Vertex via)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            Value = value;
            Via = via;
        }
    }
}
