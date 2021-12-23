
using System;
using NUnit.Framework;
using src.queue;

namespace tests
{
    public class QueueTests
    {

        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void MainTest()
        {
            var q = new Queue<string>();
            
            q.Enqueue("a");
            q.Enqueue("b");
            q.Enqueue("c");
            
            Assert.AreEqual("a", q.Dequeue());
            Assert.AreEqual("b", q.Dequeue());
            Assert.AreEqual("c", q.Dequeue());

            Assert.Catch<NullReferenceException>(() => q.Dequeue());
        }
        
    }
}