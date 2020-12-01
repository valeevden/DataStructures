using System;
using System.Collections.Generic;
using System.Text;

namespace SelfMadeList
{
    interface IList
    {
        public int Length { get; }
        public int this[int index] { get; set; }

        public int GetLength();

       // public void Add(int value);

        public void AddArray(int[] array);

        public void AddToStart(int value);

        public void AddArrayToStart(int[] array);

        public void AddToIndex(int index, int value);

        public void AddArrayToIndex(int[] array, int index);

        public void DelLast();

        public void DelLastNElements(int number);

        public void DelFirst();

        public void DelFirstNElements(int number);

        public void DelIndex(int index);

        public void DelElementStartFromIndex(int index, int number);

        public int GetValueByIndex(int index);

        public int GetIndexByValue(int value);

        public void Reverse();

        public int GetMax();

        public int GetMin();

        public int GetMinIndex();

        public int GetMaxIndex();

        public void SortAscending();

        public void SortDescending();

        public void DelFirstValue(int value);

        public void DelAllValue(int value);

    }
}
