using NUnit.Framework;
using src.disjointSet;
using src.graph;

namespace tests
{
    public class DisjointSetTests
    {
        public DisjointSetElement Element1; 
        public DisjointSetElement Element2;
        public DisjointSetElement Element3;
        public DisjointSetElement Element4;

        [SetUp]
        public void Setup()
        {
            Element1 = new DisjointSetElement(new Vertex("A"));
            Element2 = new DisjointSetElement(new Vertex("B"));
            Element3 = new DisjointSetElement(new Vertex("C"));
            Element4 = new DisjointSetElement(new Vertex("D"));
        }

        [Test]
        public void Representative()
        {
            Element2.Parent = Element1;
            Element3.Parent = Element2;
            
            Assert.AreSame(Element1, Element3.Representative);
        }

        [Test]
        public void Union2_1()
        {
            Element2.Union(Element1);
            Element2.Union(Element3);
            
            Assert.AreSame(Element1, Element3.Parent);
            Assert.AreSame(Element1, Element3.Representative);
        }

        [Test]
        public void Union1_2()
        {
            Element2.Union(Element1);
            Element3.Union(Element2);
            
            Assert.AreSame(Element1, Element3.Parent);
            Assert.AreSame(Element1, Element3.Representative);
        }

        [Test]
        public void Union1_1()
        {
            Element2.Union(Element1);
            
            Assert.AreEqual(null, Element1.Parent);
            Assert.AreSame(Element1, Element2.Parent);
        }

        [Test]
        public void Union2_2()
        {
            Element2.Union(Element1);
            Element4.Union(Element3);

            Element2.Union(Element3);
            
            Assert.AreEqual(2, Element3.Rank);
            
            Assert.AreSame(Element3, Element1.Representative);
            Assert.AreSame(Element3, Element2.Representative);
            Assert.AreSame(Element3, Element3.Representative);
            Assert.AreSame(Element3, Element4.Representative);
            
            Assert.AreSame(Element3, Element4.Representative);
        }
    }
}