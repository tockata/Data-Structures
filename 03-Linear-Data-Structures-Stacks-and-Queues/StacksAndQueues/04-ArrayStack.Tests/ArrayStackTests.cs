namespace _03_ArrayStack.Tests
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ArrayStackTests
    {
        [TestMethod]
        public void EmptyStackShouldHaveCountEqualToZero()
        {
            ArrayStack<int> stackOfInts = new ArrayStack<int>();
            Assert.AreEqual(0, stackOfInts.Count);
            stackOfInts.Push(5);
            Assert.AreEqual(1, stackOfInts.Count);
            int poppedElement = stackOfInts.Pop();
            Assert.AreEqual(5, poppedElement);
            Assert.AreEqual(0, stackOfInts.Count);
        }

        [TestMethod]
        public void InsertOneElementIntoEmptyStackShouldHaveCountEqualToOne()
        {
            ArrayStack<int> stackOfInts = new ArrayStack<int>();
            stackOfInts.Push(5);
            Assert.AreEqual(1, stackOfInts.Count);
        }

        [TestMethod]
        public void PopElementFromStackShouldReturnTheProperElementAndDecreaseCountWithOne()
        {
            ArrayStack<int> stackOfInts = new ArrayStack<int>();
            stackOfInts.Push(5);
            int poppedElement = stackOfInts.Pop();
            Assert.AreEqual(5, poppedElement);
            Assert.AreEqual(0, stackOfInts.Count);
        }

        [TestMethod]
        public void PushPopThousandElementsShouldIncreaseAndDecreaseCountAndStackShouldGrowProperly()
        {
            ArrayStack<string> stackOfStrings = new ArrayStack<string>();
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
            ArrayStack<int> stackOfInts = new ArrayStack<int>();
            stackOfInts.Pop();
        }

        [TestMethod]
        public void TestStackWithInitialCapacityOfOneElement()
        {
            ArrayStack<int> stack = new ArrayStack<int>(1);
            Assert.AreEqual(0, stack.Count);

            stack.Push(5);
            Assert.AreEqual(1, stack.Count);

            stack.Push(10);
            Assert.AreEqual(2, stack.Count);

            Assert.AreEqual(10, stack.Pop());
            Assert.AreEqual(1, stack.Count);

            Assert.AreEqual(5, stack.Pop());
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void ToArrayShouldReturnElementsInReversedOrder()
        {
            ArrayStack<int> stack = new ArrayStack<int>();
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
            ArrayStack<int> stack = new ArrayStack<int>();
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
