using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    // Задача А5.
    // Кол-во стингеров: ⅓🔹
    //
    // Написать функцию ArrayOfTiers(int number), которая принимает число и возвращает список чисел, 
    // последовательно отсеченных по одному разряду.
    //
    // Пример:
    // ArrayOfTiers(420) ==> [4, 42, 420]
    // ArrayOfTiers(2021) ==> [2, 20, 202, 2021]
    [TestClass]
    public static class TaskA5
    {
        public static List<int> ArrayOfTiers(int number)
        {
            // Здесь необходимо написать код.

            return null;
        }

        [TestMethod]
        public static void Test1() => CollectionAssert.AreEqual(new List<int>() { 4, 42, 420 }, Homework.TaskA5.ArrayOfTiers(420), "TEST ERROR");

        [TestMethod]
        public static void Test2() => CollectionAssert.AreEqual(new List<int>() { 2, 20, 202, 2021 }, Homework.TaskA5.ArrayOfTiers(2021), "TEST ERROR");

        [TestMethod]
        public static void Test3() => CollectionAssert.AreEqual(new List<int>() { 8, 80, 802, 8020, 80200 }, Homework.TaskA5.ArrayOfTiers(80200), "TEST ERROR");
    }
}
