using NUnit.Framework;
using src;
using src.dynamicArray;
using src.graph;

namespace tests
{
    public class LexicographicOrderComparerTests
    {

        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void OneCharTest()
        {
            var ar = new DynamicArray<string>
                {
                    "B", 
                    "E",
                    "C",
                    "A"
                };
            
            BubbleSort.Sort(ar, new LexicographicOrderComparer());
            
            Assert.AreEqual("A,B,C,E", ar.ToElementsString());
        }

        [Test]
        public void ManyCharsSameLenTest()
        {
            var ar = new DynamicArray<string>
                {
                    "BAG",
                    "AAA",
                    "ABA",
                    "AAB",
                    "ABB",
                    "BBB",
                    "BAB",
                    "BAA",
                    "CAA"
                };
            
            BubbleSort.Sort(ar, new LexicographicOrderComparer());
            
            Assert.AreEqual("AAA,AAB,ABA,ABB,BAA,BAB,BAG,BBB,CAA", ar.ToElementsString());
        }

        [Test]
        public void ManyCharsDiffLenTest()
        {
            var ar = new DynamicArray<string>
                {
                    "BAG",
                    "AAA",
                    "AB",
                    "ABA",
                    "AAAB",
                    "AAB",
                    "ABB",
                    "BBB",
                    "A",
                    "BAB",
                    "BA",
                    "BAA",
                    "CAA"
                };
            
            BubbleSort.Sort(ar, new LexicographicOrderComparer());
            
            Assert.AreEqual("A,AAA,AAAB,AAB,AB,ABA,ABB,BA,BAA,BAB,BAG,BBB,CAA", ar.ToElementsString());
        }
        
    }
}