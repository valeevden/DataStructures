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
    }
}
