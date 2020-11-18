using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SelfMadeList.LinkedLists
{
    public class LinkedList
    {
        public int Length { get; private set; }

        // Переменная _root для хранения ссылки на первый элемент
        private Node _root;
        // Индексатор класса
        public int this[int index]
        {
            get
            {
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }

            set
            {
                Node tmp = _root;
                for (int i = 1; i <= index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }
        // Конструктор.Создает пустой лист
        public LinkedList()
        {
            Length = 0;
            _root = null;
        }
        // Конструктор на основе одного элемента
        public LinkedList(int value)
        {
            _root = new Node(value);
            Length = 1;
        }
        // Конструктор на основании массива
        public LinkedList(int[] array)
        {
            if (array.Length != 0)
            {
                _root = new Node(array[0]);
                Node tmp = _root;

                for (int i = 1; i < array.Length; i++)
                {
                    tmp.Next = new Node(array[i]);
                    tmp = tmp.Next;
                }
                tmp.Next = null;
                Length = array.Length;
            }
            else
            {
                Length = 0;
                _root = null;
            }
        }
        // Перегружаем метод Сравнения для класса
        public override bool Equals(object obj)
        {
            LinkedList linkedList = (LinkedList)obj;

            if (Length != linkedList.Length)
            {
                return false;
            }

            //for (int i = 0; i < Length; i++)
            //{
            //    if(this[i]!=linkedList[i])
            //    {
            //        return false;
            //    }
            //}

            Node tmp1 = _root;
            Node tmp2 = linkedList._root;
            for (int i = 0; i < Length; i++)
            {
                if (tmp1.Value != tmp2.Value)
                {
                    return false;
                }
                tmp1 = tmp1.Next;
                tmp2 = tmp2.Next;
            }
            return true;
        }
        // Перегружаем ToString для вывода листа в одну строку
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
        // Задаем стандартный Хэш
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Метод добавления 1 значения в конец. Увеличивает лист на 1
        public void Add(int value)
        {
            Node tmp;
            tmp = new Node(value);
            if (Length == 1)
            {
                _root.Next = tmp; // Нода следующая за рутом, теперь ссылается на tmp
                Length++;
                return;
            }
            //if (Length == 0)
            //{
            //    Length = 1;
            //    _root.Next = tmp;
            //}
            // Альтернативный вариант условия. Если нода за рутом ссылается на Null, то помещаем туда ссылку на tmp
            //if (_root.Next == null) 
            //{
            //    _root.Next = tmp;
            //    Length++;
            //    return;
            //}
            Node current = _root; // Создаем ноду-бегунок-указатель
            for (int i = 0; i <= Length; i++)
            {
                current = current.Next; // Переставляем указатель, пока не дойдем до конца списка
                if (current.Next == null)
                {
                    current.Next = tmp; // Когда указатель в НАЛ, присваеваем ему адрес новой ноды tmp
                }
            }
            Length++;
        }

        // Метод. Добавляет 1 значение в начало. Увеличивает лист на 1 элемент
        public void AddToStart(int value)
        {
            Node tmp = new Node(value); // создали новую ноду со значением
            tmp.Next = _root; // Новая нода тмп теперь ссылается туда же куда ссылался рут
            _root = tmp; // рут теперь ссылает на новую ноду тмп
            Length++;
        }

        // Метод. Добавляем значение по индексу
        public void AddByIndex(int index, int value)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                // Альтернативный вариант плохо понятно
                //Node tmp = _root;
                //_root = new Node(value);
                //_root.Next = tmp; 
                Node tmp = new Node(value); // Создаем новую ноду tmp сбоку
                tmp.Next = _root; // Новая нода tmp теперь ссылается на ссылается туда же куда и root. В руте хранится ссылка, поэтому не обязательно писать _root.next
                _root = tmp; // ссылка root теперь равна ссылке на новую ноду tmp
            }
            else
            {
                Node current = _root;
                //Альтернативный вариант плохо понятен
                //for (int i = 1; i < index; i++)
                //{
                //    current = current.Next;
                //}
                //Node tmp = current.Next;
                //current.Next = new Node(value);
                //current.Next.Next = tmp; 

                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                Node tmp = new Node(value); // Создаем новую ноду tmp сбоку
                tmp.Next = current.Next; // Новая нода tmp теперь ссылается туда же куда ссылается crnt
                current.Next = tmp; // crnt теперь ссылается на новую ноду tmp
            }
            Length++;
        }

        // Метод. Удаляет number элементов.
        public void DelLastNElements(int number = 1)
        {
            if (number < 0)
            {
                return;
            }
            if (number >= Length)
            {
                Length = 0;
                _root = null;
            }
            else
            {
                Node current = _root;
                for (int i = 0; i < Length - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = null;
                Length -= number;
            }
        }

        // Метод. Удаляет первый элемент
        public void DelFirst()
        {
            if (Length <= 1)
            {
                Length = 0;
                return;
            }
            _root = _root.Next;
            Length--;
        }

        // Метод. Удаляет первых N элементов
        public void DelFirstNElements(int number)
        {
            if (Length <= 1 || number >= Length)
            {

                Length = 0;
                _root = null;
                return;
            }
            if (number < 0)
            {
                return;
            }
            else
            {
                Node current = _root; // создаем переменную current для хранения ссылки на Node (_root)
                for (int i = 1; i < number; i++)
                {
                    current = current.Next;
                }
                //   _root.Next = current;
                _root = current.Next;
                Length -= number;
            }
        }
        // Метод. Удаляет по индексу
        public void DelIndex(int index)
        {

            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                _root = _root.Next;
                Length--;
            }
            else
            {
                if (Length <= 1)
                {
                    Length = 0;
                    _root = null;
                    return;
                }
                Node current = _root; // создаем переменную current для хранения ссылки на Node (_root)
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
                Length--;
            }
        }
        // Метод. Возвращает индекс по значению
        public int GetIndexByValue(int value)
        {
            Node tmp = _root;
            for (int i = 0; i <= Length - 1; i++)
            {
                if (tmp.Value == value)
                {
                    return i;
                }
                tmp = tmp.Next;
            }
            return -1;
        }
        // Метод. Получаем максимальное значение в списке
        public int GetMax()
        {
            int max = _root.Value;
            Node tmp = _root;
            //for (int i = 0; i <= Length - 1; i++)
            //{
            //    if (tmp.Value > max)
            //    {
            //        max = tmp.Value;
            //    }
            //    tmp = tmp.Next;
            //}
            //return max;
            while (tmp != null)
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

            for (int i = 0; i <= Length - 1; i++)
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
        // Метод возвращаем индекс минимального значения
        public int GetMaxIndex()
        {
            int max = _root.Value;
            Node tmp = _root;
            int index = 0;

            for (int i = 0; i <= Length - 1; i++)
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
        // Метод. Удаляет одно значение
        public void DelValue(int value)
        {
            if (_root.Value == value)
            {
                DelFirst();
                return;
            }
            Node tmp = _root;
            for (int i = 0; i <= Length - 2; i++)
            {
                if (tmp.Next.Value == value)
                {
                    tmp.Next = tmp.Next.Next;
                    Length--;
                    return;
                }
                tmp = tmp.Next;
            }
        }
        // Метод. Удаляет все значения
        public void DelALLValue(int value)
        {
            while (_root != null && _root.Value == value)
            {
                _root = _root.Next;
                Length--;
            }

            if (_root == null)
                return;

            Node tmp = _root;
            int count = 0;

            while(tmp.Next != null)
            {
                if (tmp.Next.Value == value)
                {
                    tmp.Next = tmp.Next.Next;
                    count++;
                }
                else
                {
                    tmp = tmp.Next;
                }
            }
            Length -= count;
        }
        // Метод. Реверс списка
        public void Reverse()
        {
            Node crnt = _root;
            Node tmp;
            if (_root == null)
            {
                return;
            }
            while (crnt.Next != null)
            {
                tmp = crnt.Next;
                crnt.Next = tmp.Next;
                // crnt.Next = crnt.Next.Next; // альтернативный вариант записи
                tmp.Next = _root;
                _root = tmp;
            }
        }

        // Метод добавления массива в конец
        public void AddArray(int [] adArray)
        {
            Node current = _root; // Создаем ноду-бегунок-указатель
            
            if (Length == 0 && adArray.Length != 0)
            {
                _root = new Node(adArray[0]);
                Node tmp = _root;

                for (int i = 1; i < adArray.Length; i++)
                {
                    tmp.Next = new Node(adArray[i]);
                    tmp = tmp.Next;
                }
                tmp.Next = null;
                Length = adArray.Length;
            return;
            }
            while (current.Next != null)
            {
                current = current.Next;
            }
                for (int i = 0; i < adArray.Length; i++)
                {
                current.Next = new Node(adArray[i]);
                Length++;
                current = current.Next;
                }
           
        }
    }
}
