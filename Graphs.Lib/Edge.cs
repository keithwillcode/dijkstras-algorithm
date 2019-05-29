using System;

namespace Graphs.Lib
{
    public class Edge
    {
        public Vertex ConnectedTo { get; private set; }
        public Int32 Weight { get; private set; }

        public Edge(Vertex connectedTo, Int32 weight)
        {
            ConnectedTo = connectedTo;
            Weight = weight;
        }
    }
}
