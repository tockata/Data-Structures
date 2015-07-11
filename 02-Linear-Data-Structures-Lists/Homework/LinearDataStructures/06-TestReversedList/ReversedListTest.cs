namespace _06_TestReversedList
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    using _06_ReversedList;

    [TestClass]
    public class ReversedListTest
    {
        private ReversedList<int> reveresedList;

        [TestInitialize]
        public void TestInitialize()
        {
            this.reveresedList = new ReversedList<int>();
        }

        [TestMethod]
        public void CountShouldBeZeroAndCapacityShouldBeFourForEmptyList()
        {
            Assert.AreEqual(0, this.reveresedList.Count);
            Assert.AreEqual(4, this.reveresedList.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TryingToAccesNotExistingIndexShouldThrowException()
        {
            int n = this.reveresedList[5];
        }

        [TestMethod]
        public void AddingOneElementToListShouldReturnCountOne()
        {
            this.reveresedList.Add(5);
            Assert.AreEqual(1, this.reveresedList.Count);
        }

        [TestMethod]
        public void AddingOneElementToListShouldReturnCapacityFour()
        {
            this.reveresedList.Add(5);
            Assert.AreEqual(4, this.reveresedList.Capacity);
        }

        [TestMethod]
        public void AddingTwoElementToListShouldReturnCountTwo()
        {
            this.reveresedList.Add(1);
            this.reveresedList.Add(2);
            Assert.AreEqual(2, this.reveresedList.Count);
        }

        [TestMethod]
        public void AccessingIndexZeroShouldReturnLastAddedElement()
        {
            this.reveresedList.Add(1);
            this.reveresedList.Add(2);
            this.reveresedList.Add(3);
            this.reveresedList.Add(4);
            this.reveresedList.Add(5);

            Assert.AreEqual(5, this.reveresedList[0]);
        }

        [TestMethod]
        public void AccessingLastIndexShouldReturnFirstAddedElement()
        {
            this.reveresedList.Add(1);
            this.reveresedList.Add(2);
            this.reveresedList.Add(3);
            this.reveresedList.Add(4);
            this.reveresedList.Add(5);

            Assert.AreEqual(1, this.reveresedList[this.reveresedList.Count - 1]);
        }

        [TestMethod]
        public void ChangingElementValueTest()
        {
            this.reveresedList.Add(1);
            this.reveresedList.Add(2);
            this.reveresedList.Add(3);
            this.reveresedList.Add(4);
            this.reveresedList.Add(5);

            this.reveresedList[4] = 10;

            Assert.AreEqual(10, this.reveresedList[4]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ChangingElementValueOnNonExistingIndexShouldThrowError()
        {
            this.reveresedList.Add(1);
            this.reveresedList.Add(2);
            this.reveresedList.Add(3);
            this.reveresedList.Add(4);
            this.reveresedList.Add(5);

            this.reveresedList[99] = 10;
        }

        [TestMethod]
        public void WhenRemovingElementCountShouldDecrementByOne()
        {
            this.reveresedList.Add(1);
            this.reveresedList.Add(2);
            this.reveresedList.Add(3);
            this.reveresedList.Add(4);
            this.reveresedList.Add(5);

            this.reveresedList.Remove(4);

            Assert.AreEqual(4, this.reveresedList.Count);
        }

        [TestMethod]
        public void WhenRemovingElementItShouldBeTheRightOne()
        {
            this.reveresedList.Add(1);
            this.reveresedList.Add(2);
            this.reveresedList.Add(3);
            this.reveresedList.Add(4);
            this.reveresedList.Add(5);

            this.reveresedList.Remove(3);

            Assert.AreEqual(3, this.reveresedList[2]);
            Assert.AreEqual(1, this.reveresedList[3]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void WhenRemovingElementAtNonExistingIndexShouldThrowError()
        {
            this.reveresedList.Add(1);
            this.reveresedList.Add(2);
            this.reveresedList.Add(3);
            this.reveresedList.Add(4);
            this.reveresedList.Add(5);

            this.reveresedList.Remove(99);
        }
    }
}
