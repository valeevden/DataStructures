using System;

namespace SelfMadeList
{
    public class ArrayList
    {
        // Свойство. Длина Списка. Можем получить значение, не можем изменить снаружи
        public int ListLength { get; private set; }

        // Поле. Массив на основе которого создается список
        private int[] _array;
        // Свойство. Размер массива, при обращении выдает длинну массива 
        private int _ArrayLength
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
        private int GetIndexByValue(int index)
        {
            if (index > _array.Length || index < 0)
            {
                throw new Exception("Out of range exception");
            }
            int value = _array[index];
            return value;
        }

        // Метод. Изменяет в массиве элемент по индексу
        public void ChangeElementByIndex(int[] _array, int index, int value)
        {
            _array[index] = value;
        }

        // Метод. Возвращает индекс по Значению
        public int GetValueByIndex(int value)
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

        // Метод. Реверс
        public void Reverse(int[] _array)
        {
            int[] newArray = new int[_array.Length];
            for (int i = 0; i < _array.Length; i++)
            {
                newArray[newArray.Length - 1 - i] = _array[i];
            }
            _array = newArray;
        }

        // Метод. Добавляет 1 значение в конец массива. При необходимости увеличивает размер массива вложенным методом. Изменяет длинну Листа на 1 элемент
        public void Add(int value)
        {
            if (_ArrayLength <= ListLength)
            {
                IncreaseListLength();
            }
            _array[ListLength] = value;
            ListLength++;
        }
        // Метод. Добавляет 1 значение в начало массива вложенным методом. При необходимости увеличивает размер массива вложенным методом. Изменяет длинну Листа на 1 элемент
        public void AddToStart(int value)
        {
            if (_ArrayLength <= ListLength)
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
            if (_ArrayLength >= ListLength)
            {
                DecreaseListLength();
            }
        }

        // Метод. Удаляет с начала один элемент. При необходимости сокращает размер массива вложенным методом. Изменяет длинну Листа на -1 элемент
        public void DelFirstElement()
        {
            _array = ShrinkFistElement(_array);
            ListLength--;

            if (_ArrayLength >= ListLength)
            {
                DecreaseListLength();
            }
        }

        // Метод. Удаляет элемент по индексу. При необходимости сокращает размер массива вложенным методом. Изменяет длинну Листа на -1 элемент
        public void DelIndexElement(int index)
        {
            _array = DecreaseByIndex(_array, index);
            ListLength--;

            if (_ArrayLength >= ListLength)
            {
                DecreaseListLength();
            }
        }


        // Метод. Добавляет 1 значение в список по индексу вложенным методом. При необходимости увеличивает размер массива вложенным методом. Изменяет длинну Листа на 1 элемент
        public void AddToIndex(int index, int value)
        {
            if (_ArrayLength <= ListLength)
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
            int newListLength = _ArrayLength;
            while (newListLength <= ListLength + number)
            {
                newListLength = (int)(newListLength * 1.33 + 1);
            }

            int[] newArray = new int[newListLength];
            Array.Copy(_array, newArray, _ArrayLength);

            _array = newArray;
        }

        // Метод. Уменьшает размер Листа и массива
        private void DecreaseListLength()
        {
            int newListLength = _ArrayLength;
            while (newListLength *2 > ListLength )
            {
                newListLength = (int)(newListLength * 0.67 );
            }

            int[] newArray = new int[newListLength];
            Array.Copy(_array, newArray, _ArrayLength);

            _array = newArray;
        }

        //Пересоздание метода Assert.Equals для тестов
        //public override bool Equals(object obj)
        //{
        //    ArrayList arrayList = (ArrayList)obj;

        //    if (ListLength!=arrayList.ListLength)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        for(int i=0; i<ListLength; i++)
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
        // Метод. возвращаем максимальное значение
        public int FindMaxValue(int[] _array)
        {
            int max = _array[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                }
            }
            return max;
        }
        // Метод. возвращаем минимальное значение
        public int FindMinValue(int[] _array)
        {
            int min = _array[0];
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                }
            }
            return min;
        }
        // Метод возвращаем индекс минимального значения
        public int FindMinValueIndex(int[] array)
        {
            int min = array[0]; 
            int index = 0; 

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i]; 
                    index = i;
                }
            }
            return index;
        }
        // Метод возвращаем индекс максимального значения
        public int FindMaxValueIndex(int[] array)
        {
            int max = array[0];
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    index = i;
                }
            }
            return index;
        }
        // Сортируем по Возрастанию
        public void SortArrayAscending(int[] array1)
        {
            int[] array2 = new int[array1.Length];
            array2 = array1;

            for (int i = 0; i < array2.Length - 1; i++) 
            {
                int minIndex = i;

                for (int j = i; j < array2.Length; j++) 
                {
                    if (array2[j] < array2[minIndex]) 
                    {
                        minIndex = j;
                    }
                }
                int tmp = array2[i];
                array2[i] = array2[minIndex];
                array2[minIndex] = tmp;
            }
            array1 = array2;
        }
        // Сортируем по ubi
        public void SortArrayDescending(int[] array1)
        {
            int[] array2 = new int[array1.Length];
            array2 = array1;
            int temp;

            for (int i = 0; i < array2.Length - 1; i++) // Для каждого индекса по внешнему счетчику c 0 до предпоследнего элемента
            {
                for (int j = i + 1; j < array2.Length; j++) // Перебираем элементы по внутреннему счетчику начиная с 0+1 элемента
                {
                    if (array2[i] < array2[j]) // Если найден элемент меньше, то меняем местами индексы
                    {
                        temp = array2[i];
                        array2[i] = array2[j];
                        array2[j] = temp;
                    }
                }
            }
            array1 = array2;
        }

        //public static int[] DelFistEqualValue(int[] array, int value)
        //{
        //    int index = 0;
        //    GetIndexByValue(value);
        //   array = DecreaseByIndex(array, index);
        //}
    }
}
