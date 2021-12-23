using NUnit.Framework;
using src;
using src.dynamicArray;
using src.graph;

namespace tests
{
    public class TraversalTests
    {
        [SetUp]
        public void SetUp() {}

        [Test]
        public void BfsTests()
        {
            var g = new Graph(new DynamicArray<(string v1, string v2, int w)>
            {
                ("A", "B", 1),
                ("A", "C", 1),
                ("A", "D", 1),
                ("B", "C", 1),
                ("C", "E", 1),
                ("D", "D", 1),
                ("E", "E", 1),
            });
            
            Assert.AreEqual("A,B,C,D,E", Traversal.Bfs(g).ToElementsString());
        }
        
        [Test]
        public void DfsTests()
        {
            var g = new Graph(new DynamicArray<(string v1, string v2, int w)>
            {
                ("A", "B", 1),
                ("A", "C", 1),
                ("C", "B", 1),
                ("A", "D", 1),
                ("B", "E", 1),
            });
            
            Assert.AreEqual("A,D,C,B,E", Traversal.Dfs(g).ToElementsString());
        }
        
    }
}