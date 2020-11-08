using System;

namespace SelfMadeList
{
    public class ArrayList
    {
        // Свойство. Длина Списка. Можем получить значение, не можем изменить снаружи
        public int ListLength { get; private set; }

        // Поле. Массив на основе которого создается список
        private int[] _array;
        // Поле. Размер массива, при обращении выдает длинну массива 
        private int _arrayLength
        {
            get
            {
                return _array.Length;
            }
        }
        // Конструктор для создания нового листа. Внутри создает массив на 9 элементов по умолчанию, длина Листа 0
        public ArrayList()
        {
            _array = new int[9];
            ListLength = 0;
        }

        // Метод. Добавляет 1 значение в конец массива. При необходимости увеличивает размер массива вложенным методом. Изменяет длинну Листа на 1 элемент
        public void Add(int value)
        {
            if (_arrayLength >= ListLength)
            {
                IncreaseListLength();
            }
            _array[ListLength] = value;
            ListLength++;
        }
        // Метод. Добавляет 1 значение в начало массива. При необходимости увеличивает размер массива вложенным методом. Изменяет длинну Листа на 1 элемент
        public void AddToStart(int value)
        {
            if (_arrayLength <= ListLength)
            {
                IncreaseListLength();
            }
            _array = MoveArrayForwardFrom0toValue(_array, value);
            ListLength++;
        }
        // Метод. Увеличивает размер массива на number элементов
        private void IncreaseListLength(int number = 1)
        {
            int newListLength = _arrayLength;
            while (newListLength <= ListLength + number)
            {
                newListLength = (int)(newListLength * 1.33 + 1);
            }

            int[] newArray = new int[newListLength];
            Array.Copy(_array, newArray, _arrayLength);

            _array = newArray;
        }

        //public override bool Equals(object obj)
        //{
        //    ArrayList arrayList = (ArrayList)obj;

        //    if (DlinaSpiska!=arrayList.DlinaSpiska)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        for(int i=0; i<DlinaSpiska; i++)
        //        {
        //            if (_array[i] != arrayList._array[i])
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}

        private int[] MoveArrayForwardFrom0toValue(int[] _array, int value)
        {
            int[] newArray = new int[_array.Length + value];

            for (int i = 0; i < _array.Length; i++)
            {
                newArray[i + value] = _array[i];
            }
            _array = newArray;
            return _array;
        }

    }
}
