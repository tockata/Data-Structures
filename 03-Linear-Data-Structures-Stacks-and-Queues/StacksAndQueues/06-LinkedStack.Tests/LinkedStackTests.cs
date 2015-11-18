namespace _06_LinkedStack.Tests
{
    using System;
    using System.IO;

    using _05_LinkedStack;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
        
    [TestClass]
    public class LinkedStackTests
    {
        [TestMethod]
        public void EmptyStackShouldHaveCountEqualToZero()
        {
            LinkedStack<int> stack = new LinkedStack<int>();
            Assert.AreEqual(0, stack.Count);
            stack.Push(5);
            Assert.AreEqual(1, stack.Count);
            int poppedElement = stack.Pop();
            Assert.AreEqual(5, poppedElement);
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void InsertOneElementIntoEmptyStackShouldHaveCountEqualToOne()
        {
            LinkedStack<int> stack = new LinkedStack<int>();
            stack.Push(5);
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        public void PopElementFromStackShouldReturnTheProperElementAndDecreaseCountWithOne()
        {
            LinkedStack<int> stackOfInts = new LinkedStack<int>();
            stackOfInts.Push(5);
            int poppedElement = stackOfInts.Pop();
            Assert.AreEqual(5, poppedElement);
            Assert.AreEqual(0, stackOfInts.Count);
        }

        [TestMethod]
        public void PushPopThousandElementsShouldIncreaseAndDecreaseCountAndStackShouldGrowProperly()
        {
            LinkedStack<string> stackOfStrings = new LinkedStack<string>();
            Assert.AreEqual(0, stackOfStrings.Count);

            var stringsToPush = this.GenerateArray();
            for (int i = 0; i < stringsToPush.Length; i++)
            {
                stackOfStrings.Push(stringsToPush[i]);
                Assert.AreEqual(i + 1, stackOfStrings.Count);
            }

            for (int i = stringsToPush.Length - 1; i >= 0; i--)
            {
                Assert.AreEqual(stringsToPush[i], stackOfStrings.Pop());
                Assert.AreEqual(i, stackOfStrings.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyStackShouldThrowInvalidOperationException()
        {
            LinkedStack<int> stackOfInts = new LinkedStack<int>();
            stackOfInts.Pop();
        }

        [TestMethod]
        public void ToArrayShouldReturnElementsInReversedOrder()
        {
            LinkedStack<int> stack = new LinkedStack<int>();
            stack.Push(3);
            stack.Push(5);
            stack.Push(-2);
            stack.Push(7);

            var resultArray = stack.ToArray();
            Assert.AreEqual(7, resultArray[0]);
            Assert.AreEqual(-2, resultArray[1]);
            Assert.AreEqual(5, resultArray[2]);
            Assert.AreEqual(3, resultArray[3]);
        }

        [TestMethod]
        public void ToArrayOnEmptyStackShouldReturnEmptyArray()
        {
            LinkedStack<int> stack = new LinkedStack<int>();
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
