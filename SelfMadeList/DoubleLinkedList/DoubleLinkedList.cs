using System;
using System.Collections.Generic;
using System.Text;

namespace SelfMadeList.DoubleLinkedList
{
    public class DoubleLinkedList
    {
        public int Length { get; private set; }

        // Переменная _root для хранения ссылки на первый элемент
        private Node _root;
        // Переменная _tail для хранения ссылки на предыдущий элемент
        private Node _tail;

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
        public void AddByIndex(int index, int value)
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
                tmp.Next.Prev = tmp;
                tmp.Prev = current;
                Length++;
            }
        }

        // Метод. Удаляет number элементов.
        public void DelLastNElements(int number = 1)
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
                if (number > Length / 2)
                {
                    Node current = _root;
                    for (int i = 0; i < Length - number; i++)
                    {
                        current = current.Next;
                    }
                    current.Next = null;
                    _tail = current;
                    Length -= number;
                }
                else
                {
                    Node current = _tail;
                    for (int i = Length; i > Length - number; i--)
                    {
                        current = current.Prev;
                    }
                    current.Next = null;
                    _tail = current;
                    Length -= number;
                }
            }
        }


    }
}
