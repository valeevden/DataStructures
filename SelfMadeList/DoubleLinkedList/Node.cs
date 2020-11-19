using System;
using System.Collections.Generic;
using System.Text;

namespace SelfMadeList.DoubleLinkedList
{
    class Node
    {
        // Свойство. Можем читать и менять. Значение
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }

        // Конструктор на основе значения. Устанавливает значение и ссылку на следующее и предыдущее
        public Node(int value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }

        // Конструктор. Пустая нода
        public Node()
        {
            Next = null;
            Prev = null;
        }

        // Конструктор. На входе нода, на выходе копирует ноду
        public Node(Node node)
        {
            Next = node.Next;
            Value = node.Value;
            Prev = node.Prev;
        }

        // Перезаписываем ToString для удобства дебага
        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
