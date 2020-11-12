﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SelfMadeList.LinkedLists
{
    public class LinkedList
    {
        public int Length { get; set; }

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
                Length = array.Length;
            }
            else
            {
                Length = 0;
                _root = null;
            }
        }

        public void AddByIndex(int index, int value)
        {
            if (index == 0)
            {
                Node tmp = _root;
                _root = new Node(value);
                _root.Next = tmp;
            }
            else
            {
                Node current = _root;
                for (int i = 1; i < index; i++)
                {
                    current = current.Next;
                }

                Node tmp = current.Next;
                current.Next = new Node(value);

                current.Next.Next = tmp;
            }
            Length++;
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
        // Метод добавления 1 значения в конец. Увеличивает лист на 1
        public void Add(int value)
        {
            Node tmp;
            if (Length == 1)
            {
                tmp = new Node(value);
                _root.Next = tmp;
                Length++;
                return;
            }
            //if (_root.Next == null)
            //{
            //    tmp = new Node(value);
            //    _root.Next = tmp;
            //    Length++;
            //    return;
            //}
            tmp = _root;
            for (int i = 1; i <= Length; i++)
            {
                tmp = tmp.Next;
                if (tmp.Next == null)
                {
                    Node newNode;
                    newNode = new Node(value);
                    //Node newNode1 = new Node(value);
                    tmp.Next = newNode;
                }
            }
            Length++;
        }

        // Метод. Добавляет 1 значение в начало. Увеличивает лист на 1 элемент
        public void AddToStart(int value)
        {
            Node addNew = new Node(value);
            addNew.Next = _root;
            _root = addNew;
           Length++;
        }
        // Метод. Удаляет number элементов
        public void DelLastNElements(int number)
        {
            if (number < 0)
            {
                number = 0;
            }
            if (number >= Length)
            {
                Length = 0;
            }
            else
            {
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

        // Метод. Удаляет первый элемент
        public void DelFirstNElements(int number)
        {
            if (Length <= 1 || number >= Length)
            {
                Length = 0;
                return;
            }
            if (number < 0)
            {
                number = 0;
            }
            else
            {
                Node current = _root;
                for (int i = 1; i < number; i++)
                {
                current = current.Next;
                }
                _root.Next = current;
                _root = current.Next;
                Length -= number;
            }
            //Node tmp = current.Next;
            //current.Next = new Node(value);

            //current.Next.Next = tmp;

        }

    }
}
