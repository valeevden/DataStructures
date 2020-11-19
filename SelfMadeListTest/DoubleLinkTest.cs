using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SelfMadeList.DoubleLinkedList;

namespace SelfMadeListTest
{
    class DoubleLinkTest
    {
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 6 }, 6)]
        [TestCase(new int[] { 1 }, new int[] { 1, -8 }, -8)]
        [TestCase(new int[] { }, new int[] { -8 }, -8)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 0 }, 0)]
        public void AddTest(int[] array, int[] expArray, int value)
        {
             DoubleLinkedList expected = new  DoubleLinkedList(expArray);
             DoubleLinkedList actual = new  DoubleLinkedList(array);
            actual.Add(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 9, 1, 2, 3, 4, 5 }, 9)]
        [TestCase(new int[] { 0 }, new int[] { 9, 0 }, 9)]
        [TestCase(new int[] { }, new int[] { 9 }, 9)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { -99, 1, 2, 3, 4, 5 }, -99)]
        public void AddToStartTest(int[] array, int[] expArray, int value)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.AddToStart(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 1, 4, new int[] { 1, 4, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, 9, new int[] { 1, 2, 9, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, 4, new int[] { 4, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, 0, 4, new int[] { 4 })]
        [TestCase(new int[] { 1 }, 0, 4, new int[] { 4, 1 })]
        public void AddByIndexTest(int[] array, int index, int value, int[] expArray)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);

            actual.AddByIndex(index, value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 9, 3, 4, 5 }, -1, 9)]
        [TestCase(new int[] { 1, 2, }, new int[] { -1, 1, 2, 3, 4, 5 }, 3, -1)]
        [TestCase(new int[] { 0 }, new int[] { 1, 2, 3, 4, 5, 44 }, 2, 44)]
        public void AddByIndexNegative(int[] array, int[] expArray, int index, int value)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => {
                actual.AddByIndex(index, value);
            }); ;
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, }, 4)]
        [TestCase(new int[] { 1, 2, 3, }, new int[] { 1, 2, 3, }, -7)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 }, 0)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { }, 9)]
        [TestCase(new int[] { }, new int[] { }, 9)]
        public void DelLastNElementsTest(int[] array, int[] expArray, int number)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.DelLastNElements(number);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 4, 5, 6, 7 }, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 6, 7 }, 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 3, 4, 5, 6, 7 }, 2)]
        [TestCase(new int[] { 1 }, new int[] { }, 3)]
        [TestCase(new int[] { }, new int[] { }, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 }, -3)]
        public void DelFirstNElementsTest(int[] array, int[] expArray, int number)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.DelFirstNElements(number);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 5, 6, 7 }, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 2, 3, 4, 5, 6, 7 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 7 }, 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 3, 4, 5, 6, 7 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6 }, 6)]
        public void DelIndexTest(int[] array, int[] expArray, int index)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            actual.DelIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 5, 6, 7 }, -3)]
        [TestCase(new int[] { 1, 2, 3, }, new int[] { 2, 3, }, 5)]
        public void DelIndexNegative(int[] array, int[] expArray, int index)
        {
            DoubleLinkedList expected = new DoubleLinkedList(expArray);
            DoubleLinkedList actual = new DoubleLinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => {
                actual.DelIndex(index);
            }); ;
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 4, 3)]
        [TestCase(new int[] { 0, -3, 99, 6, }, 4, -1)]
        [TestCase(new int[] { 0, -3, 99, 6, }, 99, 2)]
        public void GetIndexByValueTest(int[] array, int value, int expIndex)
        {
            int actual = new DoubleLinkedList(array).GetIndexByValue(value);
            int expected = expIndex;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        [TestCase(new int[] { 0, -3, 99, 6, }, 99)]
        [TestCase(new int[] { -11, -3, -1, -7, }, -1)]
        public void GetMaxTest(int[] array, int expValue)
        {
            int actual = new DoubleLinkedList(array).GetMax();
            int expected = expValue;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 1)]
        [TestCase(new int[] { 0, -3, 99, 6, }, -3)]
        [TestCase(new int[] { -11, -3, -1, -7, }, -11)]
        public void GetMinTest(int[] array, int expValue)
        {
            int actual = new DoubleLinkedList(array).GetMin();
            int expected = expValue;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 0)]
        [TestCase(new int[] { 0, -3, 99, 6, }, 1)]
        [TestCase(new int[] { -11, -3, -1, -17, }, 3)]
        public void GetMinIndexTest(int[] array, int expIndex)
        {
            int actual = new DoubleLinkedList(array).GetMinIndex();
            int expected = expIndex;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 3)]
        [TestCase(new int[] { 0, -3, 99, 6, }, 2)]
        [TestCase(new int[] { -11, 7, -1, -17, }, 1)]
        public void GetMaxIndexTest(int[] array, int expIndex)
        {
            int actual = new DoubleLinkedList(array).GetMaxIndex();
            int expected = expIndex;
            Assert.AreEqual(expected, actual);
        }

    }
}
