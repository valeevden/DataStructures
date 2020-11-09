using NUnit.Framework;
using SelfMadeList;

namespace SelfMadeListTest
{
    public class Tests
    {

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void ReverseTest(int[] array, int[] expArray)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.Reverse();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 2, 7, new int[] { 1, 2, 7, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0, -5, new int[] { -5, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4, 8, new int[] { 1, 2, 3, 4, 8 })]
        public void SetByIndexTest(int[] array, int index, int newValue, int[] expArray)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);

            actual[index] = newValue;

            Assert.AreEqual(expected, actual);
        }

        //[TestCase(new int[] { 1, 2, 3, 4, 5 }, 5, 8)]
        //[TestCase(new int[] { 1, 2, 3, 4, 5 }, -1, 8)]
        //[TestCase(new int[] { 1, 2, 3, 4, 5 }, 500, 8)]
        //public void SetByIndexNegativeTest(int[] array, int index, int newValue)
        //{
        //    ArrayList actual = new ArrayList(array);

        //    Assert.Throws<IndexOutOfRangeException>(() => actual[index] = newValue);
        //}
        [TestCase(new int[] { 1, 2, 3, 4 }, 4, 3)]
        [TestCase(new int[] { 0, -3, 99, 6, }, 4, -1)]
        [TestCase(new int[] { 0, -3, 99, 6, }, 99, 2)]
        public void GetIndexByValueTest(int[] array, int value, int expValue)
        {
            int actual = new ArrayList(array).GetIndexByValue(value);
            int expected = expValue;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        public void TrimLastElementTest(int[] array, int[] expArray)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.TrimLastElement();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 9, 1, 2, 3, 4, 5 }, 9)]
        public void AddToStartTest(int[] array, int[] expArray, int value)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            
            actual.AddToStart(value);
            Assert.AreEqual(expected, actual);
        }
    }
}