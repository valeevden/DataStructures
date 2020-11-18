using System;
using System.Collections.Generic;
using System.Text;

namespace SelfMadeList.LinkedLists
{
    public class Node
    {
        // Свойство. Можем читать и менять. Значение
        public int Value { get; set; }
        public Node Next { get; set; }

        // Конструктор на основе значения. Устанавливает значение и ссылку на следующее
        public Node(int value)
        {
            Value = value;
            Next = null;
        }
        // Конструктор. Пустая нода
        public Node()
        {
            Next = null;
        }
        // Конструктор. На входе нода, на выходе копирует ноду
        public Node(Node node)
        {
            Next = node.Next;
            Value = node.Value;
        }

        // Перезаписываем ToString для удобства дебага
        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
