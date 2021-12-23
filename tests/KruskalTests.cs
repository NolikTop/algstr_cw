using NUnit.Framework;
using src;
using src.dynamicArray;
using src.graph;

namespace tests
{
    public class KruskalTests
    {
        [SetUp]
        public void Setup(){}

        [Test]
        public void MainTest()
        {
            var g = new Graph(new DynamicArray<(string v1, string v2, int w)>{
                ("A", "B", 3),
                ("B", "C", 2),
                ("A", "C", 1),
            });

            var mst = KruskalAlgorithm.GetMinimumSpanningTree(g);
            Assert.AreEqual(
@"A C
B C
3", mst.ToStringOnlyEdges());
        }
        
        [Test]
        public void TestSortOutput()
        {
            var g = new Graph(new DynamicArray<(string v1, string v2, int w)>{
                ("A", "B", 2),
                ("B", "C", 1),
                ("A", "C", 3)
            });

            var mst = KruskalAlgorithm.GetMinimumSpanningTree(g);
            Assert.AreEqual(
                @"A B
B C
3", mst.ToStringOnlyEdges());
        }

        [Test]
        public void FirstTestFromWiki()
        {
            var g = new Graph(new DynamicArray<(string v1, string v2, int w)>{
                ("A", "B", 3),
                ("A", "E", 1),
                ("B", "C", 5),
                ("B", "E", 4),
                ("C", "D", 2),
                ("E", "D", 7),
                ("E", "C", 6)
            });

            var mst = KruskalAlgorithm.GetMinimumSpanningTree(g);
            Assert.AreEqual(
@"A B
A E
B C
C D
11", mst.ToStringOnlyEdges());
        }

        [Test]
        public void SecondTestFromWiki()
        {
            var g = new Graph(new DynamicArray<(string v1, string v2, int w)>{
                ("A", "B", 7),
                ("A", "D", 5),
                ("D", "B", 9),
                ("D", "E", 15),
                ("D", "F", 6),
                ("B", "C", 8),
                ("B", "E", 7),
                ("F", "E", 8),
                ("F", "G", 11),
                ("G", "E", 9),
                ("E", "C", 5)
            });

            var mst = KruskalAlgorithm.GetMinimumSpanningTree(g);
            Assert.AreEqual(
@"A B
A D
B E
D F
E C
G E
39", mst.ToStringOnlyEdges());
        }
    }
}