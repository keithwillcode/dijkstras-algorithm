using System;
using System.Linq;
using Graphs.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Graphs.UnitTests
{
    [TestClass]
    public class VertexTests
    {
        [TestMethod]
        public void Constructor_WithNoParameters_SetsInitialValueToMaxInt()
        {
            var a = new Vertex("A");

            Assert.AreEqual(Int32.MaxValue, a.Value);
        }

        [TestMethod]
        public void AddVertex_AddsEdgeWithWeight()
        {
            var a = new Vertex("A");
            var b = new Vertex("B");

            a.AddEdge(new Edge(b, 5));

            Assert.AreEqual(5, a.Edges.First().Weight);
        }
    }
}
