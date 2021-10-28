using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    // Задача А6.
    // Кол-во стингеров: ⅓🔹
    //
    // Написать функцию OddNumbers, которая получает на вход список целых чисел arr и целое число n и
    // возвращает список, состоящий из n последних вхождений нечетных чисел списка arr в том же порядке
    //
    // Пример:
    // ([1, 2, 3, 4, 5, 6, 7, 8, 9], 3) => [5, 7, 9]
    [TestClass]
    public static class TaskA6
    {
        public static List<int> OddNumbers(List<int> arr, int n)
        {
            // Здесь необходимо написать код.

            return null;
        }

        [TestMethod]
        public static void Test1() => CollectionAssert.AreEqual(new List<int>() { 7, 9 }, Homework.TaskA6.OddNumbers(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 2), "TEST ERROR");

        [TestMethod]
        public static void Test2() => CollectionAssert.AreEqual(new List<int>() { 9, -81, 7 }, Homework.TaskA6.OddNumbers(new List<int>() { -15, 3, 6, 9, 12, -24, -81, 7 }, 3), "TEST ERROR");

        [TestMethod]
        public static void Test3() => CollectionAssert.AreEqual(new List<int>() { -3 }, Homework.TaskA6.OddNumbers(new List<int>() { 6, -25, 3, 7, 5, 5, 7, -3, 24 }, 1), "TEST ERROR");
    }
}
