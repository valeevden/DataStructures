using NUnit.Framework;
using SelfMadeList.LinkedLists;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfMadeListTest
{
    class LinkedListTest
    {

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 6 }, 6)]
        [TestCase(new int[] { 1 }, new int[] { 1, -8 }, -8)]
        [TestCase(new int[] {  }, new int[] { -8 }, -8)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 0 }, 0)]
        public void AddTest(int[] array, int[] expArray, int value)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.Add(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 9, 1, 2, 3, 4, 5 }, 9)]
        [TestCase(new int[] { 0 }, new int[] { 9, 0 }, 9)]
        [TestCase(new int[] {  }, new int[] { 9 }, 9)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { -99, 1, 2, 3, 4, 5 }, -99)]
        public void AddToStartTest(int[] array, int[] expArray, int value)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.AddToStart(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 1, 4, new int[] { 1, 4, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, 4, new int[] { 4, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 3, 4, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, 0, 4, new int[] { 4 })]
        [TestCase(new int[] { 1 }, 0, 4, new int[] { 4, 1 })]
        public void AddByIndexTest(int[] array, int index, int value, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);

            actual.AddByIndex(index, value);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 9, 3, 4, 5 }, -1, 9)]
        [TestCase(new int[] { 1, 2, }, new int[] { -1, 1, 2, 3, 4, 5 }, 3, -1)]
        [TestCase(new int[] { 0 }, new int[] { 1, 2, 3, 4, 5, 44 }, 2, 44)]
        public void AddByIndexNegative(int[] array, int[] expArray, int index, int value)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => {
                actual.AddByIndex(index, value);
            }); ;
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, }, 4)]
        [TestCase(new int[] { 1, 2, 3, }, new int[] { 1, 2, 3, }, -7)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 }, 0)]
        [TestCase(new int[] {1, 2, 3 }, new int[] { }, 9)]
        [TestCase(new int[] { }, new int[] { }, 9)]
        public void DelLastNElementsTest(int[] array, int[] expArray, int number)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.DelLastNElements(number);
            Assert.AreEqual(expected, actual);
        }

       [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
       [TestCase(new int[] { 1 }, new int[] { })]
       [TestCase(new int[] { }, new int[] { })]
        public void DelFirstTest(int[] array, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.DelFirst();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 4, 5, 6, 7 }, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 6, 7 }, 5)]
        [TestCase(new int[] { 1 }, new int[] { }, 3)]
        [TestCase(new int[] { }, new int[] { }, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 }, -3)]
        public void DelFirstNElementsTest(int[] array, int[] expArray, int number)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.DelFirstNElements(number);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 5, 6, 7 }, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 2, 3, 4, 5, 6, 7 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6 }, 6)]
        public void DelIndexTest(int[] array, int[] expArray, int index)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.DelIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 5, 6, 7 }, -3)]
        [TestCase(new int[] { 1, 2, 3,}, new int[] { 2, 3,}, 5)]
        public void DelIndexNegative(int[] array, int[] expArray, int index)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => {
                actual.DelIndex(index);
            }); ;
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 4, 3)]
        [TestCase(new int[] { 0, -3, 99, 6, }, 4, -1)]
        [TestCase(new int[] { 0, -3, 99, 6, }, 99, 2)]
        public void GetIndexByValueTest(int[] array, int value, int expIndex)
        {
            int actual = new LinkedList(array).GetIndexByValue(value);
            int expected = expIndex;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        [TestCase(new int[] { 0, -3, 99, 6, }, 99)]
        [TestCase(new int[] { -11, -3, -1, -7, }, -1)]
        public void GetMaxTest(int[] array, int expValue)
        {
            int actual = new LinkedList(array).GetMax();
            int expected = expValue;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 1)]
        [TestCase(new int[] { 0, -3, 99, 6, }, -3)]
        [TestCase(new int[] { -11, -3, -1, -7, }, -11)]
        public void GetMinTest(int[] array, int expValue)
        {
            int actual = new LinkedList(array).GetMin();
            int expected = expValue;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 0)]
        [TestCase(new int[] { 0, -3, 99, 6, }, 1)]
        [TestCase(new int[] { -11, -3, -1, -17, }, 3)]
        public void GetMinIndexTest(int[] array, int expIndex)
        {
            int actual = new LinkedList(array).GetMinIndex();
            int expected = expIndex;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 3)]
        [TestCase(new int[] { 0, -3, 99, 6, }, 2)]
        [TestCase(new int[] { -11, 7, -1, -17, }, 1)]
        public void GetMaxIndexTest(int[] array, int expIndex)
        {
            int actual = new LinkedList(array).GetMaxIndex();
            int expected = expIndex;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 4, 5, 6, 7 }, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, }, new int[] { 1, 2, 4, 5, 6 }, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, }, new int[] { 2, 3, 4, 5, 6 }, 1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 7 }, 6)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6 }, 7)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 }, 9)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3, }, 1)]
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 2 }, 1)]
        [TestCase(new int[] { 1 }, new int[] { }, 1)]
        public void DelValueTest(int[] array, int[] expArray, int value)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.DelValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 }, 9)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0)]
        [TestCase(new int[] { 1, 2, 1, 4, 1, 1, 7 }, new int[] { 2, 4, 7 }, 1)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 7 }, new int[] { 7 }, 1)]
        [TestCase(new int[] { 1, 1, 1, 7 }, new int[] { 7 }, 1)]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3, }, 1)]
        [TestCase(new int[] { 1, 1, 1 }, new int[] { }, 1)]
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 2 }, 1)]
        [TestCase(new int[] { 1 }, new int[] { }, 1)]
        public void DelAllValueTest(int[] array, int[] expArray, int value)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.DelALLValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void ReverseTest(int[] array, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.Reverse();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] {1}, new int[] { 1, -1, -2, -3 }, new int[] { -1, -2, -3 })]
        [TestCase(new int[] {}, new int[] { -1, -2, -3 }, new int[] { -1, -2, -3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, -1, -2, -3 }, new int[] { -1, -2, -3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, -99, -99, 0 }, new int[] { -99, -99, 0 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 0 }, new int[] { 0 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 }, new int[0])]
        public void AddArrayTest(int[] array, int[] expArray, int[] adArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.AddArray(adArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { -1, -2, -3, 1, 2, 3, 4, 5 }, new int[] { -1, -2, -3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { -1, -2, -3, 1, 2, 3, 4, 5 }, new int[] { -1, -2, -3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 0, 1, 2, 3, 4, 5 }, new int[] { 0 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        public void AddArrayToStartTest(int[] array, int[] expArray, int[] adArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.AddArrayToStart(adArray);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { -1, -2, -3, 1, 2, 3, 4, 5 }, new int[] { -1, -2, -3 }, 0)]
        [TestCase(new int[] { }, new int[] { -1, -2, -3 }, new int[] { -1, -2, -3 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 0, 66, 77, 4, 5 }, new int[] { 0, 66, 77 }, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 11, 0 }, new int[] { 11, 0 }, 5)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 11, 0, 2, 3, 4, 5}, new int[] { 11, 0 }, 1)]
        [TestCase(new int[] { 1 }, new int[] {1}, new int[] {}, 1)]
        public void AddArrayToIndexTest(int[] array, int[] expArray, int[] adArray, int index)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.AddArrayToIndex(adArray, index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { -1, -2, -3, 1, 2, 3, 4, 5 }, new int[] { -1, -2, -3 }, -1)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 0, 66, 77, 4, 5 }, new int[] { 0, 66, 77 }, 8)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 11, 0 }, new int[] { 11, 0 }, -12)]
        public void AddArrayToIndexTestNegative(int[] array, int[] expArray, int[] adArray, int index)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            Assert.Throws<IndexOutOfRangeException>(() => { actual.AddArrayToIndex(adArray, index); });

        }

        [TestCase(new int[] { 3, 1, 2, 0, }, new int[] { 1, 2, 0, 3, })]
        //[TestCase(new int[] { 4, 6, 2, 1, 3 }, new int[] { 1, 2, 3, 4, 6 })]
        //[TestCase(new int[] { -1, 0, 2, 6, -11 }, new int[] { -11, -1, 0, 2, 6 })]
        //[TestCase(new int[] { -15, 0, 12, 0, 1 }, new int[] { -15, 0, 0, 1, 12 })]
        public void SortAcsendingTest(int[] array, int[] expArray)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.SortAscending();
            Assert.AreEqual(expected, actual);
        }
    }
}
