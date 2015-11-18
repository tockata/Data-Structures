namespace _08_LinkedQueue.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _07_LinkedQueue;
    using System.IO;

    [TestClass]
    public class LinkedQueueTests
    {
        [TestMethod]
        public void EmptyQueueShouldHaveCountEqualToZero()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();
            Assert.AreEqual(0, queue.Count);
            queue.Enqueue(5);
            Assert.AreEqual(1, queue.Count);
            int poppedElement = queue.Dequeue();
            Assert.AreEqual(5, poppedElement);
            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void InsertOneElementIntoEmptyQueueShouldHaveCountEqualToOne()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();
            queue.Enqueue(5);
            Assert.AreEqual(1, queue.Count);
        }

        [TestMethod]
        public void PopElementFromQueueShouldReturnTheProperElementAndDecreaseCountWithOne()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();
            queue.Enqueue(5);
            int poppedElement = queue.Dequeue();
            Assert.AreEqual(5, poppedElement);
            Assert.AreEqual(0, queue.Count);
        }

        [TestMethod]
        public void PushPopThousandElementsShouldIncreaseAndDecreaseCountAndQueueShouldGrowProperly()
        {
            LinkedQueue<string> queue = new LinkedQueue<string>();
            Assert.AreEqual(0, queue.Count);

            var stringsToPush = this.GenerateArray();
            for (int i = 0; i < stringsToPush.Length; i++)
            {
                queue.Enqueue(stringsToPush[i]);
                Assert.AreEqual(i + 1, queue.Count);
            }

            for (int i = 0, j = stringsToPush.Length - 1; i < stringsToPush.Length; i++, j--)
            {
                Assert.AreEqual(stringsToPush[i], queue.Dequeue());
                Assert.AreEqual(j, queue.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyQueueShouldThrowInvalidOperationException()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();
            queue.Dequeue();
        }

        [TestMethod]
        public void ToArrayShouldReturnElementsInReversedOrder()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();
            queue.Enqueue(3);
            queue.Enqueue(5);
            queue.Enqueue(-2);
            queue.Enqueue(7);

            var resultArray = queue.ToArray();
            Assert.AreEqual(3, resultArray[0]);
            Assert.AreEqual(5, resultArray[1]);
            Assert.AreEqual(-2, resultArray[2]);
            Assert.AreEqual(7, resultArray[3]);
        }

        [TestMethod]
        public void ToArrayOnEmptyQueueShouldReturnEmptyArray()
        {
            LinkedQueue<int> stack = new LinkedQueue<int>();
            var resultArray = stack.ToArray();

            Assert.AreEqual(0, resultArray.Length);
        }

        private string[] GenerateArray()
        {
            string[] newStringArray = new string[1000];
            for (int i = 0; i < newStringArray.Length; i++)
            {
                string path = Path.GetRandomFileName();
                path = path.Replace(".", string.Empty);
                newStringArray[i] = path;
            }

            return newStringArray;
        }
    }
}
