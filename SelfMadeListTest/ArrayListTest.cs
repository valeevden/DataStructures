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
        public void SetIndexTest(int[] array, int index, int value, int[] expArray)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);

            actual.SetIndex(index, value);

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
        public void GetIndexByValueTest(int[] array, int value, int expIndex)
        {
            int actual = new ArrayList(array).GetIndexByValue(value);
            int expected = expIndex;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 4)]
        [TestCase(new int[] { 0, -3, 99, 6, }, 99)]
        [TestCase(new int[] { -11, -3, -1, -7, }, -1)]
        public void GetMaxTest(int[] array, int expValue)
        {
            int actual = new ArrayList(array).GetMax();
            int expected = expValue;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 1)]
        [TestCase(new int[] { 0, -3, 99, 6, }, -3)]
        [TestCase(new int[] { -11, -3, -1, -7, }, -11)]
        public void GetMinTest(int[] array, int expValue)
        {
            int actual = new ArrayList(array).GetMin();
            int expected = expValue;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 0)]
        [TestCase(new int[] { 0, -3, 99, 6, }, 1)]
        [TestCase(new int[] { -11, -3, -1, -17, }, 3)]
        public void GetMinIndexTest(int[] array, int expIndex)
        {
            int actual = new ArrayList(array).GetMinIndex();
            int expected = expIndex;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 3)]
        [TestCase(new int[] { 0, -3, 99, 6, }, 2)]
        [TestCase(new int[] { -11, 7, -1, -17, }, 1)]
        public void GetMaxIndexTest(int[] array, int expIndex)
        {
            int actual = new ArrayList(array).GetMaxIndex();
            int expected = expIndex;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 0, 1)]
        [TestCase(new int[] { 0, -3, 99, 6, }, 2, 99)]
        [TestCase(new int[] { 0, -3, 99, 6, }, 1, -3)]
        public void GetValueByIndex(int[] array, int index, int expValue)
        {
            int actual = new ArrayList(array).GetValueByIndex(index);
            int expected = expValue;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 4, 6, 2, 1, 3 }, new int[] { 1, 2, 3, 4, 6 })]
        [TestCase(new int[] { -1, 0, 2, 6, -11 }, new int[] { -11, -1, 0, 2, 6 })]
        public void SortAcsendingTest(int[] array, int[] expArray)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.SortAscending();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 4, 6, 2, 1, 3 }, new int[] { 6, 4, 3, 2, 1 })]
        [TestCase(new int[] { -1, 3, 2, 6, -11 }, new int[] { 6, 3, 2, -1, -11 })]
        public void SortDescendingTest(int[] array, int[] expArray)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.SortDescending();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        public void DelLastTest(int[] array, int[] expArray)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.DelLast();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, }, 4)]
        public void DelLastNElementsTest(int[] array, int[] expArray, int number)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.DelLastNElements(number);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5}, new int[] { 2, 3, 4, 5 })]
        public void DelFirstTest(int[] array, int[] expArray)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.DelFirst();
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 4, 5, 6, 7 }, 3)]
        public void DelFirstNElementsTest(int[] array, int[] expArray, int number)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.DelFirstNElements(number);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 5, 6, 7 }, 3)]
        public void DelIndexTest(int[] array, int[] expArray, int index)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.DelIndex(index);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 4, 5, 6, 7 }, 3)]
        //[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 4, 5, 6, 7 }, 9)] // негативный
        //[TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 4, 5, 6, 7 }, 0)] // негативный
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 2, 3, 4, 5, 6, 7 }, 1)]
        public void DelFistValueTest(int[] array, int[] expArray, int value)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.DelFirstValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 4, 5, 6, 7 }, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 3 }, new int[] { 1, 2, 4, 5, 6 }, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 }, 9)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 }, 0)] 
        [TestCase(new int[] { 1, 1, 1, 4, 5, 6, 7 }, new int[] { 4, 5, 6, 7 }, 1)]
        public void DelAllValueTest(int[] array, int[] expArray, int value)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.DelAllValue(value);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 1, 2, 3, 7, 8 }, 3, 3)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 1, 2, 3 }, 3, 9)]
        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4 }, 3, -2)]
        public void DelElementStartFromIndexTest(int[] array, int[] expArray, int index, int number)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.DelElementStartFromIndex(index, number);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5, 6 }, 6)]
        public void AddTest(int[] array, int[] expArray, int value)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            actual.Add(value);
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

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 9, 3, 4, 5 }, 2, 9)]
        public void AddToIndexTest(int[] array, int[] expArray, int index, int value)
        {
            ArrayList expected = new ArrayList(expArray);
            ArrayList actual = new ArrayList(array);
            
            actual.AddToIndex(index, value);
            Assert.AreEqual(expected, actual);
        }
    }
}
