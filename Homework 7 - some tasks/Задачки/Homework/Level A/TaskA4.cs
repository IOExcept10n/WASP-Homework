using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    // Задача А4.
    // Кол-во стингеров: ⅓🔹
    //
    // Написать функцию ListOfSums(List<int> list), которая получает на вход
    // список чисел и возвращает только те, которые равны сумме всех
    // предшествующих элементов этого списка.
    //
    // Пример:
    // ListOfSums([2,3,5,6]) ==> [5] -> 5 = 2 + 3;
    // ListOfSums([10,20,30,60,-120,0]) ==> [30,60,0].
    [TestClass]
    public static class TaskA4
    {
        public static List<int> ListOfSums(List<int> list)
        {
            // Здесь необходимо написать код.

            return null;
        }

        [TestMethod]
        public static void Test1() => CollectionAssert.AreEqual(new List<int>() { 5 }, Homework.TaskA4.ListOfSums(new List<int>() { 2, 3, 5, 6 }), "TEST ERROR");

        [TestMethod]
        public static void Test2() => CollectionAssert.AreEqual(new List<int>() { 3, 6, 12, 24 }, Homework.TaskA4.ListOfSums(new List<int>() { 1, 2, 3, 6, 12, 24 }), "TEST ERROR");

        [TestMethod]
        public static void Test3() => CollectionAssert.AreEqual(new List<int>() { 30, 60, 0 }, Homework.TaskA4.ListOfSums(new List<int>() { 10, 20, 30, 60, -120, 0 }), "TEST ERROR");

        [TestMethod]
        public static void Test4() => CollectionAssert.AreEqual(new List<int>() { 0, 0, 0 }, Homework.TaskA4.ListOfSums(new List<int>() { 1, -1, 0, 0, 0 }), "TEST ERROR");
    }
}
