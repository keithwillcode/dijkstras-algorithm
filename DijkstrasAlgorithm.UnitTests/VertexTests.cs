using System.Linq;
using Graphs.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Graphs.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Constructor_WithNoParameters_SetsInitialValueToMaxInt()
        {
            var a = new Vertex("A", 0);

            Assert.AreEqual(0, a.Value);
        }

        [TestMethod]
        public void AddVertex_AddsEdgeWithWeight()
        {
            var a = new Vertex("A", 0);
            var b = new Vertex("B", 0);

            a.AddEdge(new Edge(b, 5));

            Assert.AreEqual(5, a.Edges.First().Weight);
        }
    }
}
