using System;
using System.Collections.Generic;
using System.Text;

namespace SelfMadeList.DoubleLinkedList
{
    public class DoubleLinkedList : IList
    {
        public int Length { get; private set; }

        // Переменная _root для хранения ссылки на первый элемент
        private Node _root;
        // Переменная _tail для хранения ссылки на предыдущий элемент
        private Node _tail;

        public int GetLength()
        {
            return Length;
        }

        // Индексатор класса
        public int this[int index]
        {
            get
            {
                if (index >= Length || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                int startPoint = Length/2;
                if (index < startPoint)
                {
                    Node tmp = _root;
                    for (int i = 1; i <= index; i++)
                    {
                        tmp = tmp.Next;
                    }
                    return tmp.Value;
                }
                else
                {
                    Node tmp = _tail;
                    for (int i = Length-1; i > index; i--)
                    {
                        tmp = tmp.Prev;
                    }
                    return tmp.Value;
                }
            }

            set
            {
                if (index >= Length || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                int startPoint = Length / 2;
                if (index < startPoint)
                {
                    Node tmp = _root;
                    for (int i = 1; i <= index; i++)
                    {
                        tmp = tmp.Next;
                    }
                    tmp.Value = value;
                }
                else
                {
                    Node tmp = _tail;
                    for (int i = Length - 1; i > index; i--)
                    {
                        tmp = tmp.Prev;
                    }
                    tmp.Value = value;
                }
            }
        }

        // Конструктор.Создает пустой лист
        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        // Конструктор на основе одного элемента
        public DoubleLinkedList(int value)
        {
            _root = new Node(value);
            _tail = _root;
            Length = 1;
        }

        // Конструктор на основании массива
        public DoubleLinkedList(int[] array)
        {
            if (array.Length != 0)
            {
                _root = new Node(array[0]);
                Node tmp = _root;

                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
  // У след. элемента в поле ссылки на предыдущий кладем тмп, т.е на текущий элемент
                    tmp.Next.Prev = tmp;
                    tmp = tmp.Next;
                }

                _tail = tmp;
                tmp.Next = null;
                Length = array.Length;
            }
            else
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
        }

        // Перегружаем метод Сравнения для класса
        public override bool Equals(object obj)
        {
            DoubleLinkedList DoubleLinkedList = (DoubleLinkedList)obj;

            if (Length != DoubleLinkedList.Length)
            {
                return false;
            }

            Node tmp1 = _root;
            Node tmp2 = DoubleLinkedList._root;
            while (tmp1 != null)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }

            tmp1 = _tail;
            tmp2 = DoubleLinkedList._tail;
            while (tmp1 != null)
            {
                if (tmp1.Value != tmp1.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Prev;
                tmp2 = tmp2.Prev;
            }
            return true;
        }

        // Задаем стандартный Хэш
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

         //Перегружаем ToString для вывода листа в одну строку вперед
        public override string ToString()
        {
            string s = "";

            if (_root != null)
            {
                Node tmp = _root;

                while (tmp != null)
                {
                    s += tmp.Value + ";";
                    tmp = tmp.Next;
                }
            }
            return s;
        }

        //Перегружаем ToString для вывода листа в одну строку  задом наперед
        //public override string ToString()
        //{
        //    string s = "";

        //    if (_tail != null)
        //    {
        //        Node tmp = _tail;

        //        while (tmp != null)
        //        {
        //            s += tmp.Value + ";";
        //            tmp = tmp.Prev;
        //        }
        //    }
        //    return s;
        //}

        // Метод. Получить ссылку на ноду по ее индексу
        private Node GetNodeByIndex(int index)
        {
            int startPoint = Length / 2;
            if (index < startPoint)
            {
                Node tmp = _root;
                for (int i = 1; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp;
            }
            else
            {
                Node tmp = _tail;
                for (int i = Length - 1; i > index; i--)
                {
                    tmp = tmp.Prev;
                }
                return tmp;
            }
        }

        // Метод добавления 1 значения в конец. 
        public void Add(int value)
        {
            Node tmp;
            tmp = new Node(value);

            if (Length == 0)
            {
                _root = tmp;
                _tail = _root;
                Length++;
            }
            else
            {
                _tail.Next = tmp;
                tmp.Prev = _tail;
                _tail = tmp;
                Length++;
            }
        }

        // Метод. Добавляет 1 значение в начало.
        public void AddToStart(int value)
        {
            Node tmp = new Node(value); // создали новую ноду со значением value

            if (Length == 0)
            {
                _root = tmp;
                _tail = _root;
                Length++;
                return;
            }
            tmp.Next = _root; // Новая нода tmp теперь ведет туда же куда вел рут
            _root.Prev = tmp; // Пред. рут теперь ведет в тмп
            _root = tmp; // рут теперь ведет (ссылается) на новую ноду тмп
            Length++;
        }

        // Метод. Добавляем значение по индексу
        public void AddToIndex(int index, int value)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == Length)
            {
                Add(value);
                return;
            }

            if (index == 0)
            {
                AddToStart(value);
            }
            else
            {
                Node current = GetNodeByIndex(index); // Получаем ссылку на ноду по индексу
                current = current.Prev; // Смещаем указатель на предыдущий элемент
                Node tmp = new Node(value); // Создаем новую ноду tmp сбоку
                tmp.Next = current.Next; // Новая нода tmp теперь ссылается туда же куда ссылается crnt
                current.Next = tmp; // crnt теперь ссылается на новую ноду tmp
                tmp.Next.Prev = tmp; // Следующая за tmp нода теперь ссылается на tmp
                tmp.Prev = current; // tmp теперь ссылается на crnt
                Length++;
            }
        }

        // Метод. Удаляет number элементов c конца.
        public void DelLastNElements(int number=1)
        {
            if (number <= 0)
            {
                return;
            }
            if (number >= Length)
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
            else
            {
                Node current = _tail;
                for (int i = Length; i > Length - number; i--)
                {
                    current = current.Prev;
                    current.Next = null; // Убиваем ссылку на след. элемент, чтобы он не завис в памяти
                }
                _tail = current;
                Length -= number;
            }
        }

        public void DelLast()
        {
            
            if (Length <= 1)
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
            else
            {
                Node current = _tail;
                for (int i = Length; i > Length - 1; i--)
                {
                    current = current.Prev;
                    current.Next = null; // Убиваем ссылку на след. элемент, чтобы он не завис в памяти
                }
                _tail = current;
                Length--;
            }
        }

        // Метод. Удаляет number элементов c начала.
        public void DelFirstNElements(int number = 1)
        {
            if (number <= 0)
            {
                return;
            }
            if (number >= Length)
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
            else
            {
                Node current = _root;
                for (int i = 0; i < number; i++)
                {
                    current = current.Next;
                    current.Prev = null; // Убиваем ссылку на след. элемент, чтобы он не завис в памяти
                }
                _root = current;
                Length -= number;
            }
        }

        public void DelFirst()
        {

            if (Length <= 1)
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
            else
            {
                _root = _root.Next;
                _root.Prev = null;
                Length --;
            }
            
        }

        // Метод. Удаляет по индексу
        public void DelIndex(int index)
        {

            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == Length -1)
            {
                DelLastNElements();
                return;
            }
            if (index == 0)
            {
                _root.Next.Prev = null;
                _root = _root.Next;
                Length--;
            }
            else
            {
                if (Length <= 1)
                {
                    Length = 0;
                    _root = null;
                    _tail = null;
                    return;
                }
                Node current = _root; // создаем node current и кладем туда такую же ссылку как в _root
                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
                //Node current = GetNodeByIndex(index);
                current.Prev.Next = current.Next;
                current.Next.Prev = current.Prev;
                Length--;
            }
        }

        // Метод. Возвращает индекс по значению
        public int GetIndexByValue(int value)
        {
            Node tmp = _root;
            for (int i = 0; i < Length; i++)
            {
                if (tmp.Value == value)
                {
                    return i;
                }
                tmp = tmp.Next;
            }
            return -1;
        }

        public int GetValueByIndex(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            int startPoint = Length / 2;
            if (index < startPoint)
            {
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }
            else
            {
                Node tmp = _tail;
                for (int i = Length - 1; i > index; i--)
                {
                    tmp = tmp.Prev;
                }
                return tmp.Value;
            }
        }

        // Метод. Получаем максимальное значение в списке
        public int GetMax()
        {
            if (Length <= 0)
            {
                throw new InvalidOperationException();
            }
            int max = _root.Value;
            Node tmp = _root;
            while (tmp != null) // пройти до последнего элемента. tmp.next!=null это предпоследний
            {
                if (tmp.Value > max)
                {
                    max = tmp.Value;
                }
                tmp = tmp.Next;
            }
            return max;
        }
        // Метод. Получаем минимальное значение в списке
        public int GetMin()
        {
            int min = _root.Value;
            Node tmp = _root;

            while (tmp != null)
            {
                if (tmp.Value < min)
                {
                    min = tmp.Value;
                }
                tmp = tmp.Next;
            }
            return min;
        }
        // Метод возвращаем индекс минимального значения
        public int GetMinIndex()
        {
            int min = _root.Value;
            Node tmp = _root;
            int index = 0;

            for (int i = 0; i < Length; i++)
            {
                if (tmp.Value < min)
                {
                    min = tmp.Value;
                    index = i;
                }
                tmp = tmp.Next;
            }
            return index;
        }
        // Метод возвращаем индекс максимального значения
        public int GetMaxIndex()
        {
            int max = _root.Value;
            Node tmp = _root;
            int index = 0;

            for (int i = 0; i < Length; i++)
            {
                if (tmp.Value > max)
                {
                    max = tmp.Value;
                    index = i;
                }
                tmp = tmp.Next;
            }
            return index;
        }

        public void AddArray(int[] array)
        {
            if (array.Length < 1)
            {
                return;
            }

            Node tmp = _tail;
            int a = 0;

            if (Length == 0)
            {
                _root = new Node(array[0]);
                tmp = _root;
                a = 1;
            }
            for (int i = a; i < array.Length; i++)
            {
                tmp.Next = new Node(array[i]);
                tmp.Next.Prev = tmp;
                tmp = tmp.Next;
            }

            _tail = tmp;
            Length += array.Length;
        }
    

        public void AddArrayToStart(int[] array)
        {
            if (array.Length < 1)
            {
                return;
            }

            Node tmp = _root;
            int a = 0;

            if (Length == 0)
            {
                _root = new Node(array[array.Length-1]);
                tmp = _root;
                _tail = tmp;
                a =  1;
            }
            for (int i = array.Length - 1 - a ; i >= 0; i--)
            {
                tmp.Prev = new Node(array[i]);
                tmp.Prev.Next = tmp;
                tmp = tmp.Prev;
            }

            _root = tmp;
            Length += array.Length;

        }

        public void AddArrayToIndex(int[] array, int index)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                AddArrayToStart(array);
                return;
            }

           if (index == Length)
           {
                AddArray(array);
                return;
           }

            Node current = GetNodeByIndex(index-1);
           
            Node tmp = current.Next;
            //current = current.Prev;

            for (int i = 0; i < array.Length; i++)
            {
                current.Next = new Node(array[i]);
                current.Next.Prev = current;
                current = current.Next;
            }
            current.Next = tmp;
            tmp.Prev = current;
            Length += array.Length;
        }

        public void DelElementStartFromIndex(int index, int number)
        {
            if (index < 0 || index > Length )
            {
                throw new IndexOutOfRangeException();
            }
            if (number < 0)
            {
                return;
            }

            if (index == 0)
            {
                DelFirstNElements(number);
            }

            if (Length <= 1)
            {
                Length = 0;
                _root = null;
                _tail = null;
                return;
            }

            if (index == Length - 1)
            {
                DelLast();
                return;
            }

            //int maxToTheEnd = Length - index;
            //if (number > maxToTheEnd)
            //{
            //    number = maxToTheEnd;
            //}

            Node current = GetNodeByIndex(index);
            current = current.Next;
            for (int i = 0; i < number; i++)
            {
                current.Next.Prev = current.Prev;
                current.Prev.Next = current.Next;
                current = current.Next;
            }
            Length -= number;

        }

        public void Reverse()
        {
            if (Length > 1)
            {
                Node current = _root;
                Node tmp;
                while (current != null)
                {
                    tmp = current.Next;
                    current.Next = current.Prev;
                    current.Prev = tmp;
                    current = current.Prev;
                }
                tmp = _root;
                _root = _tail;
                _tail = tmp;
            }
        }

        public void SortAscending()
        {
            throw new NotImplementedException();
        }

        public void SortDescending()
        {
            throw new NotImplementedException();
        }

        public void DelFirstValue(int value)
        {
            if (_root != null)
            {
                Node current = _root;
                for (int i = 0; i < Length; i++)
                {
                    if (current.Value == value)
                    {
                        DelIndex(i);
                        return;
                    }
                    current = current.Next;
                }
            }
        }
        public void DelAllValue(int value)
        {
            if (_root != null)
            {
                Node current = _root;
                for (int i = 0; i < Length; i++)
                {
                    if (current.Value == value)
                    {
                        DelIndex(i);
                        i--;
                    }
                    current = current.Next;
                }
            }
        }
   
    }
}
