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
        // Метод возвращает длинну Списка
        public int GetLength() 
        {
          return ListLength;
        }

        // Метод возвращает значение по Индексу
        public int GetIndexValue(int index)
        {
            int value = _array[index];
            return value;
        }

        // Метод. Возвращает индекс по Значению
        public int GetValueIndex(int value)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == value)
                {
                    return i;
                }
            }
            throw new Exception("No match Found");
        }


        // Метод. Добавляет 1 значение в конец массива. При необходимости увеличивает размер массива вложенным методом. Изменяет длинну Листа на 1 элемент
        public void Add(int value)
        {
            if (_arrayLength <= ListLength)
            {
                IncreaseListLength();
            }
            _array[ListLength] = value;
            ListLength++;
        }
        // Метод. Добавляет 1 значение в начало массива вложенным методом. При необходимости увеличивает размер массива вложенным методом. Изменяет длинну Листа на 1 элемент
        public void AddToStart(int value)
        {
            if (_arrayLength <= ListLength)
            {
                IncreaseListLength();
            }
            _array = MoveArrayForwardFrom0toValue(_array, value);
            ListLength++;
        }

        // Метод. Удаляет с конца один элемент. При необходимости сокращает размер массива вложенным методом. Изменяет длинну Листа на -1 элемент
        public void Del()
        {
            _array = ShrinkLastElement(_array);
            ListLength--;
            if (_arrayLength >= ListLength)
            {
                DecreaseListLength();
            }
        }

        // Метод. Удаляет с начала один элемент. При необходимости сокращает размер массива вложенным методом. Изменяет длинну Листа на -1 элемент
        public void DelFirstElement()
        {
            _array = ShrinkFistElement(_array);
            ListLength--;

            if (_arrayLength >= ListLength)
            {
                DecreaseListLength();
            }
        }

        // Метод. Удаляет элемент по индексу. При необходимости сокращает размер массива вложенным методом. Изменяет длинну Листа на -1 элемент
        public void DelIndexElement(int index)
        {
            _array = DecreaseByIndex(_array, index);
            ListLength--;

            if (_arrayLength >= ListLength)
            {
                DecreaseListLength();
            }
        }


        // Метод. Добавляет 1 значение в список по индексу вложенным методом. При необходимости увеличивает размер массива вложенным методом. Изменяет длинну Листа на 1 элемент
        public void AddToIndex(int index, int value)
        {
            if (_arrayLength <= ListLength)
            {
                IncreaseListLength();
            }
            _array = MoveArrayForwardFromIndex(_array, index);
            _array[index] = value; ;
            ListLength++;
        }
        // Метод. Увеличивает размер массива и листа на number элементов
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

        // Метод. Уменьшает размер Листа и массива
        private void DecreaseListLength()
        {
            int newListLength = _arrayLength;
            while (newListLength *2 > ListLength )
            {
                newListLength = (int)(newListLength * 0.67 );
            }

            int[] newArray = new int[newListLength];
            Array.Copy(_array, newArray, _arrayLength);

            _array = newArray;
        }

        //Пересоздание метода Assert.Equals для тестов
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

        // Метод. Сдвигает массив вперед на value элементов
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

        // Метод. Сдвигает массив вперед на 1 элемент начиная с определенного индекса
        public static  int[] MoveArrayForwardFromIndex(int[] _array, int index)
        {
            int[] newArray = new int[_array.Length + 1];
            Array.Copy(_array, newArray, _array.Length);
                    
            for (int i = index; i < _array.Length; i++)
            {
                newArray[i + 1] = _array[i];
            }
            _array = newArray;
            return _array;
        }

        // Метод. Удаляет из массива последний элемент
        public static int[] ShrinkLastElement(int[] _array)
        {
            int[] newArray = new int[_array.Length - 1];
            Array.Copy(_array, newArray, _array.Length-1);
            _array = newArray;
            return _array;
        }

        // Метод. Удаляет из массива первый элемент
        public static int[] ShrinkFistElement(int[] _array)
        {
            int[] newArray = new int[_array.Length - 1];
            for (int i = 1; i < _array.Length; i++)
            {
                newArray[i-1] = _array[i];
            }

            _array = newArray;
            return _array;
        }

        // Метод. Удаляет из массива элемент по индексу
        public static int[] DecreaseByIndex(int[] _array, int index)
        {
            int[] newArray = new int[_array.Length - 1];
            for (int i = 0; i < index; i++)
            {
                newArray[i] = _array[i];
            }
            for (int i = _array.Length-1; i > index; i--)
            {
                 newArray[i-1] = _array[i];
            }
            _array = newArray;
            return _array;
        }
    }
}
