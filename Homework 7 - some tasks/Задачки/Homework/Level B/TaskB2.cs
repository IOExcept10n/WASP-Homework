using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    // Задача B2.
    // Кол-во стингеров: 🔹
    //
    // Написать функцию OrderWeight(List<int> list), которая сортирует список положительных чисел.
    // Критерий сортировки - возрастание веса числа (сумма всех цифр числа).
    // Если два числа имеют одинаковый вес, сортировать их так, словно они строки.
    //
    // Пример:
    // [56, 65, 74, 100, 99, 68, 86, 180, 90] ==>
    // [100, 180, 90, 56, 65, 74, 68, 86, 99]
    public static class TaskB2
    {
        public static List<int> OrderWeight(List<int> list)
        {
            // Здесь необходимо написать код.
            list.Sort(CompareNumbers);
            return list;
        }

        public static int CompareNumbers(int n1, int n2)//Создаю функцию для сравнения, чтобы затем использовать её в списке.
        {
            int d1 = TaskA2.SumOfDigits(n1);
            int d2 = TaskA2.SumOfDigits(n2);
            if (d1 == d2) return string.Compare(n1.ToString(), n2.ToString());
            else return d1 - d2;
        }

        [TestMethod]
        public static void Test1() => CollectionAssert.AreEqual(new List<int>() { 2000, 103, 123, 4444, 99 },
            Homework.TaskB2.OrderWeight(new List<int>() { 103, 123, 4444, 99, 2000 }), "TEST ERROR");

        [TestMethod]
        public static void Test2() => CollectionAssert.AreEqual(new List<int>() { 11, 11, 2000, 10003, 22, 123, 1234000, 44444444, 9999 },
            Homework.TaskB2.OrderWeight(new List<int>() { 2000, 10003, 1234000, 44444444, 9999, 11, 11, 22, 123 }), "TEST ERROR");
    }
}
