using System;
using SelfMadeList;

namespace ConsoleForTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] array;
            //array = new int[6];

            //Random r = new Random();


            //for (int i = 0; i < array.Length; i++)
            //{
            //    array[i] = r.Next(-30, 30); // Наполняем массив рандомными значениями
            //    Console.Write(array[i] + " "); // выводим для наглядности
            //}

            ////int[] array2 = SelfMadeList.ArrayList.DecreaseByIndex(array, 2);

            //Console.WriteLine();
            //Console.WriteLine();

            //for (int i = 0; i < array2.Length; i++)
            //{

            //    Console.Write(array2[i] + " "); // выводим для наглядности
            //}

            //Console.WriteLine();
            //Console.WriteLine(array.Length);
            //Console.WriteLine(array2.Length);

            ArrayList artest = new ArrayList();
            artest.AddArrayToStart(new int [] { 0, 2, 4, 5, 6});
            artest[3]=99;
            Console.WriteLine(artest[4]);
            //int f = artest.ListLength;
            //Console.WriteLine(f);


        }
    }
}
