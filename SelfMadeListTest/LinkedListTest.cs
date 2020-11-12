using NUnit.Framework;
using SelfMadeList.LinkedLists;
using System;
using System.Collections.Generic;
using System.Text;

namespace SelfMadeListTest
{
    class LinkedListTest
    {
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

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 6 }, 6)]
        [TestCase(new int[] { 1 }, new int[] { 1, -8 }, -8)]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 0 }, 0)]
        public void AddTest(int[] array, int[] expArray, int value)
        {
            LinkedList expected = new LinkedList(expArray);
            LinkedList actual = new LinkedList(array);
            actual.Add(value);
            Assert.AreEqual(expected, actual);
        }
    }
}
