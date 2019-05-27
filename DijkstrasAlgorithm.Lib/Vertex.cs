using System;
using System.Collections.Generic;

namespace Graphs.Lib
{
    public class Vertex
    {
        public HashSet<Edge> Edges { get; private set; }
        public String Name { get; private set; }
        public Int32 Value { get; private set; }

        public Vertex(String name, Int32 value)
        {
            Edges = new HashSet<Edge>();
            Name = name;
            Value = value;
        }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }

        public void CalibrateWeight(Int32 value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            Value = value;
        }

        public Boolean WeightHasBeenCalibrated()
        {
            return Value < 0;
        }
    }
}
