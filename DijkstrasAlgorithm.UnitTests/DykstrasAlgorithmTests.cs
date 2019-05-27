using System.Linq;
using Graphs.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Graphs.UnitTests
{
    [TestClass]
    public class DykstrasAlgorithmTests
    {
        [TestMethod]
        public void GetShortestPath_ReturnsPath_WhenTwoNodesAreInGraph()
        {
            var graph = new WeightedGraph();
            var a = new Vertex("A", 0);
            var b = new Vertex("B", 0);

            a.AddEdge(new Edge(b, 10));

            graph.AddVertex(a);
            graph.AddVertex(b);

            var dijkstrasAlgorithm = new DijkstrasAlgorithm(graph);
            var path = dijkstrasAlgorithm.GetShortestPath(a, b);

            Assert.AreEqual(2, path.Count);
            Assert.AreEqual(10, path.Last().Value);
            Assert.IsTrue(path.Contains(a));
            Assert.IsTrue(path.Contains(b));
        }

        [TestMethod]
        public void GetShortestPath_ReturnsCorrectPath_WhenThreeNodesAreInGraph()
        {
            var graph = new WeightedGraph();
            var a = new Vertex("A", 0);
            var b = new Vertex("B", 0);
            var c = new Vertex("C", 0);

            a.AddEdge(new Edge(b, 10));
            b.AddEdge(new Edge(c, 5));

            graph.AddVertex(a);
            graph.AddVertex(b);
            graph.AddVertex(c);

            var dijkstrasAlgorithm = new DijkstrasAlgorithm(graph);
            var path = dijkstrasAlgorithm.GetShortestPath(a, c);

            Assert.AreEqual(3, path.Count);
            Assert.AreEqual(15, path.Last().Value);
            Assert.IsTrue(path.Contains(a));
            Assert.IsTrue(path.Contains(b));
            Assert.IsTrue(path.Contains(c));
        }

        [TestMethod]
        public void GetShortestPath_ReturnsCorrectPath_WhenTwoPossiblePathsExist()
        {
            var graph = new WeightedGraph();
            var a = new Vertex("A", 0);
            var b = new Vertex("B", 0);
            var c = new Vertex("C", 0);
            var d = new Vertex("D", 0);

            a.AddEdge(new Edge(b, 10));
            a.AddEdge(new Edge(c, 3));
            b.AddEdge(new Edge(d, 5));
            c.AddEdge(new Edge(d, 1));

            graph.AddVertex(a);
            graph.AddVertex(b);
            graph.AddVertex(c);
            graph.AddVertex(d);

            var dijkstrasAlgorithm = new DijkstrasAlgorithm(graph);
            var path = dijkstrasAlgorithm.GetShortestPath(a, d);

            Assert.AreEqual(3, path.Count);
            Assert.AreEqual(4, path.Last().Value);
            Assert.IsTrue(path.Contains(a));
            Assert.IsTrue(path.Contains(c));
            Assert.IsTrue(path.Contains(d));
        }

        [TestMethod]
        public void GetShortestPath_ReturnsCorrectPath_ForComplexGraph()
        {
            var graph = new WeightedGraph();
            var a = new Vertex("A", 0);
            var b = new Vertex("B", 0);
            var c = new Vertex("C", 0);
            var d = new Vertex("D", 0);
            var e = new Vertex("E", 0);
            var f = new Vertex("F", 0);
            var g = new Vertex("G", 0);

            a.AddEdge(new Edge(b, 10));
            a.AddEdge(new Edge(c, 3));
            b.AddEdge(new Edge(d, 5));
            c.AddEdge(new Edge(d, 1));
            d.AddEdge(new Edge(e, 2));
            d.AddEdge(new Edge(f, 4));
            d.AddEdge(new Edge(g, 5));
            e.AddEdge(new Edge(f, 19));
            e.AddEdge(new Edge(g, 7));
            e.AddEdge(new Edge(b, 23));

            graph.AddVertex(a);
            graph.AddVertex(b);
            graph.AddVertex(c);
            graph.AddVertex(d);
            graph.AddVertex(e);
            graph.AddVertex(f);
            graph.AddVertex(g);

            var dijkstrasAlgorithm = new DijkstrasAlgorithm(graph);
            var path = dijkstrasAlgorithm.GetShortestPath(a, g);

            Assert.AreEqual(5, path.Count);
            Assert.AreEqual(13, path.Last().Value);
            Assert.IsTrue(path.Contains(a));
            Assert.IsTrue(path.Contains(c));
            Assert.IsTrue(path.Contains(d));
            Assert.IsTrue(path.Contains(e));
            Assert.IsTrue(path.Contains(g));
        }

        [TestMethod]
        public void GetShortestPath_ReturnsCorrectPath_ForGraphWithManyLowCostEdges()
        {
            var graph = new WeightedGraph();
            var a = new Vertex("A", 0);
            var b = new Vertex("B", 0);
            var c = new Vertex("C", 0);
            var d = new Vertex("D", 0);
            var e = new Vertex("E", 0);
            var f = new Vertex("F", 0);
            var g = new Vertex("G", 0);

            a.AddEdge(new Edge(b, 1));
            a.AddEdge(new Edge(g, 3));
            b.AddEdge(new Edge(c, 1));
            c.AddEdge(new Edge(d, 1));
            d.AddEdge(new Edge(e, 1));
            e.AddEdge(new Edge(f, 1));
            f.AddEdge(new Edge(g, 1));

            graph.AddVertex(a);
            graph.AddVertex(b);
            graph.AddVertex(c);
            graph.AddVertex(d);
            graph.AddVertex(e);
            graph.AddVertex(f);
            graph.AddVertex(g);

            var dijkstrasAlgorithm = new DijkstrasAlgorithm(graph);
            var path = dijkstrasAlgorithm.GetShortestPath(a, g);

            Assert.AreEqual(2, path.Count);
            Assert.AreEqual(3, path.Last().Value);
            Assert.IsTrue(path.Contains(a));
            Assert.IsTrue(path.Contains(g));
        }
    }
}
