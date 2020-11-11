using System;
using System.Linq;

namespace SelfMadeList
{
    public class ArrayList
    {
        // Свойство. Длина Списка. Можем получить значение, не можем изменить снаружи
        public int ListLength { get; private set; }

        private const double LengthUpMultiplier = 1.33;
        private const double LengthDownMultiplier = 0.67;

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
        // Создание индексаторов для класса
        public int this[int i]
        {
            get
            {
                if (i >= ListLength || i < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return _array[i];
            }
            set
            {
                if (i >= ListLength || i < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                _array[i] = value;
            }
        }
        // Конструктор класса. Внутри создает массив на 9 элементов по умолчанию, длина 0
        public ArrayList()
        {
            _array = new int[9];
            ListLength = 0;
        }
        // Конструктор класса2. В качестве входа int. Cоздает внутри класса пустой массив на N элементов по умолчанию, длина 0
        public ArrayList(int N)
        {
            _array = new int[N];
            ListLength = 0;
        }
        // Конструктор класса3. В качестве входного параметра принимает массив. Сразу же увеличивает его на 33% и присвает Длинне класса длинну массива
        public ArrayList(int[] array)
        {
            _array = new int[(int)(array.Length * LengthUpMultiplier)];
            ListLength = array.Length;
            Array.Copy(array, _array, array.Length);
        }

        // Метод возвращает длинну Списка
        public int GetLength() 
        {
          return ListLength;
        }

        // Метод возвращает индекс по значению. Если значение не найдено возвращает -1
        public int GetIndexByValue(int value)
        {
            for (int i = 0; i < ListLength; i++)
            {
                if (_array[i] == value)
                {
                    return i;
                }
            }
            return -1; 
        }

        // Метод. Изменяет  элемент по индексу
        public void SetIndex(int index, int value)
        {
            if (index > ListLength || index < 0)
            {
                throw new Exception("Out of range exception");
            }
            _array[index] = value;
        }

        // Метод. Возвращает Значение по Индексу (доступ по Индексу)
        public int GetValueByIndex(int index)
        {
             if (index > ListLength  || index < 0)
             {
                throw new Exception("Out of range exception");
             }
            int value = _array[index];
            return value;
        }

        // Метод. Реверс
        public void Reverse()
        {
            for (int i = 0; i < ListLength / 2; i++)
            {
                int a = _array[i];
                _array[i] = _array[ListLength - i - 1];
                _array[ListLength - i - 1] = a;
            }
        }

        // Метод. Добавляет 1 значение в конец. При необходимости увеличивает размер массива вложенным методом. Изменяет длинну Листа на 1 элемент
        public void Add(int value)
        {
            if (_ArrayLength <= ListLength)
            {
                IncreaseLength();
            }
            _array[ListLength] = value;
            ListLength++;
        }

        // Метод. Добавляет новый массив в конец. При необходимости увеличивает размер массива вложенным методом и на каждой итерации цикла. Изменяет длинну листа на длинну добавляемого массива
        public void AddArray(int [] adArray)
        {
            if (_ArrayLength <= ListLength)
            {
                IncreaseLength(adArray.Length);
            }

            for (int i = 0; i < adArray.Length; i++)
            {
                _array [i + ListLength] = adArray[i];
                 IncreaseLength();
            }
            ListLength+=adArray.Length;
        }

        // Метод. Добавляет 1 значение в начало массива вложенным методом. При необходимости увеличивает размер массива вложенным методом. Изменяет длинну Листа на 1 элемент
        public void AddToStart(int value)
        {
            if (_ArrayLength <= ListLength)
            {
                IncreaseLength();
            }
            MoveForwardFrom0toNumber();
            _array[0] = value;
            ListLength++;
        }

        // Метод. Добавляет массив в начало.
        public void AddArrayToStart(int [] adArray)
        {
            if (_ArrayLength <= ListLength)
            {
                IncreaseLength();
            }
            MoveForwardFrom0toNumber(adArray.Length);
            for (int i = 0; i < adArray.Length; i++)
            {
                _array[i] = adArray[i];
                IncreaseLength();
            }
            ListLength++;
        }

        // Метод. Добавляет 1 значение в список по индексу вложенным методом. При необходимости увеличивает размер массива вложенным методом. Изменяет длинну Листа на 1 элемент
        public void AddToIndex(int index, int value)
        {
            if (index > ListLength || index < 0)
            {
                throw new Exception("Out of range exception");
            }
            if (_ArrayLength <= ListLength)
            {
                IncreaseLength();
            }
            MoveForwardFromIndex(_array, index);
            _array[index] = value;
            ListLength++;
        }

        // Метод. Удаляет с конца один элемент. Изменяет длинну Листа на -1 элемент. При необходимости сокращает размер массива вложенным методом. 
        public void DelLast()
        {
            ListLength--;
            if (_ArrayLength >= ListLength)
            {
                DecreaseLength();
            }
        }

        // Метод.  Удаляет N элементов с конца
        public void DelLastNElements(int number)
        {
            if (number < 0)
            {
                number = 0;
            }
            if (number >= ListLength)
            {
                ListLength = 0;
                //_array = new int[9];
            }
            else
            {
                ListLength -= number;
                if (_ArrayLength >= ListLength)
                {
                    DecreaseLength();
                }
            }
        }

        // Метод. Удаляет с начала один элемент. При необходимости сокращает размер массива вложенным методом. Изменяет длинну Листа на -1 элемент
        public void DelFirst()
        {
            DelFistElement();
            ListLength--;
            if (_ArrayLength >= ListLength)
            {
                DecreaseLength();
            }
        }

        // Метод. Удаляет с начала N элементов. При необходимости сокращает размер массива вложенным методом. Изменяет длинну Листа на N элемент
        public void DelFirstNElements(int number)
        {
            if (number < 0)
            {
                number = 0;
            }
            if (number >= ListLength)
            {
                ListLength = 0;
                //_array = new int[9];
            }
            else
            {
                DelFistNumberElements(number);
                ListLength -= number;
                if (_ArrayLength >= ListLength)
                {
                DecreaseLength();
                }
            }
        }

        // Метод. Удаляет элемент по индексу. При необходимости сокращает размер массива вложенным методом. Изменяет длинну Листа на -1 элемент
        public void DelIndex(int index)
        {
            if (index > ListLength  || index < 0)
            {
                throw new Exception("Out of range exception");
            }
            DecreaseByIndex(index);
            ListLength--;
            if (_ArrayLength >= ListLength)
            {
                DecreaseLength();
            }
        }
        
        // Метод. Удаляет элемент по индексу. При необходимости сокращает размер массива вложенным методом. Изменяет длинну Листа на -1 элемент
        public void DelElementStartFromIndex(int index, int number)
        {
            if (index > ListLength  || index < 0)
            {
                throw new Exception("Out of range exception");
            }
            if (number < 0)
            {
                number = 0;
            }
            int maxToTheEnd = ListLength - index;
            if (number > maxToTheEnd)
            {
                number = maxToTheEnd;
            }
            DecreaseNumberElementsByIndex(index, number);
            ListLength -= number;
            if (_ArrayLength >= ListLength)
            {
                DecreaseLength();
            }
        }

        // Метод. Удаляет первый по значению элемент. При необходимости сокращает размер массива вложенным методом. Изменяет длинну Листа на -1 элемент
        public void DelFirstValue(int value)
        {
            int index = GetIndexByValue(value);
            if (index == -1)
            {
                throw new Exception("No matches");
            }
            DelIndex(index);
        }

        // Метод. Удаляет все элементы заданного значения. При необходимости сокращает размер массива вложенным методом. Изменяет длинну обекта класса
        public void DelAllValue(int value)
        {
            for (int i = 0; i < ListLength; i++)
            {
            int index = GetIndexByValue(value);
            if (index >= 0)
                {
                DelIndex(index);
                }
            }
        }

        // Метод. возвращаем максимальное значение
        public int GetMax()
        {
            int max = _array[0];
            for (int i = 0; i < ListLength; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                }
            }
            return max;
        }
        // Метод. возвращаем минимальное значение
        public int GetMin()
        {
            int min = _array[0];
            for (int i = 0; i < ListLength; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                }
            }
            return min;
        }
        // Метод возвращаем индекс минимального значения
        public int GetMinIndex()
        {
            int min = _array[0]; 
            int index = 0; 

            for (int i = 0; i < ListLength; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i]; 
                    index = i;
                }
            }
            return index;
        }
        // Метод возвращаем индекс максимального значения
        public int GetMaxIndex()
        {
            int max = _array[0];
            int index = 0;

            for (int i = 0; i < ListLength; i++)
            {
                if (_array[i] > max)
                {
                    max = _array[i];
                    index = i;
                }
            }
            return index;
        }
        // Сортируем по Возрастанию
        public void SortAscending()
        {
            for (int i = 0; i < ListLength - 1; i++) 
            {
                int minIndex = i;

                for (int j = i; j < ListLength; j++) 
                {
                    if (_array[j] < _array[minIndex]) 
                    {
                        minIndex = j;
                    }
                }
                int tmp = _array[i];
                _array[i] = _array[minIndex];
                _array[minIndex] = tmp;
            }
        }
        // Сортируем по убыванию другим методом
        public void SortDescending()
        {
            int temp;
            for (int i = 0; i < ListLength - 1; i++) // Для каждого индекса по внешнему счетчику c 0 до предпоследнего элемента
            {
                for (int j = i + 1; j < ListLength; j++) // Перебираем элементы по внутреннему счетчику начиная с 0+1 элемента
                {
                    if (_array[i] < _array[j]) // Если найден элемент меньше, то меняем местами индексы
                    {
                        temp = _array[i];
                        _array[i] = _array[j];
                        _array[j] = temp;
                    }
                }
            }
        }

        //Пересоздание метода Assert.Equals для тестов
        public override bool Equals(object obj)
        {
            ArrayList arrayList = (ArrayList)obj;

            if (ListLength != arrayList.ListLength)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < ListLength; i++)
                {
                    if (_array[i] != arrayList._array[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // Переcоздаем метод ToString() для удобного вывода объектов класса в одну строку
        public override string ToString()
        {
            return string.Join(";", _array.Take(ListLength));
        }

        // КОНЕЦ ПУБЛИЧНЫХ МЕТОДОВ ДЛЯ КЛАССА ===================================================================================

        // Метод. Увеличивает размер массива и класса на number элементов
        private void IncreaseLength(int number = 1)
        {
            int newListLength = _ArrayLength;
            while (newListLength <= ListLength + number)
            {
                newListLength = (int)(newListLength * LengthUpMultiplier + 1 + number);
            }
            int[] newArray = new int[newListLength];
            Array.Copy(_array, newArray, _ArrayLength);
            _array = newArray;
        }

        // Метод. Уменьшает размер Листа и массива
        private void DecreaseLength()
        {
            int newListLength = _ArrayLength;
            while (newListLength >= 2* ListLength )
            {
                newListLength = (int)(newListLength * LengthDownMultiplier + 1 );
            }
            int[] newArray = new int[newListLength];
            Array.Copy(_array, newArray, ListLength); // Копируем на длину Списка
            _array = newArray;
        }

        // Метод. Сдвигает  вперед на number элементов
        private void MoveForwardFrom0toNumber(int number=1)
        {
            for (int i = ListLength - 1; i >= 0; i--)
            {
                _array[i + number] = _array[i];
            }
        }

        // Метод. Сдвигает вперед на 1 элемент начиная с определенного индекса
        private void  MoveForwardFromIndex(int[] _array, int index)
        {
            for (int i = ListLength - 1; i >= index; i--)
            {
                _array[i + 1] = _array[i];
            }
        }

        // Метод. Удаляет первый элемент
        private void DelFistElement()
        {
            for (int i = 0; i < ListLength; i++)
            {
                _array[i] = _array[i + 1];
            }
        }

        // Метод. Удаляет с начала N элементов
        private void DelFistNumberElements(int number)
        {
            for (int i = 0; i < ListLength - number; i++)
            {
                _array[i] = _array[i + number];
            }
        }

        // Метод. Удаляет элемент по индексу
        private void DecreaseByIndex(int index)
        {
            for (int i = index; i < ListLength; i++)
            {
                _array[i] = _array[i + 1];
            }
        }

        // Метод. Удаляет N элементов по индексу
        private void DecreaseNumberElementsByIndex(int index, int number)
        {
            for (int i = index; i < ListLength - number; i++)
            {
                _array[i] = _array[i + number];
            }
        }
    }
}
