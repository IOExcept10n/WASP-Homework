using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    // Задача C2.
    // Кол-во стингеров: 🔷
    //
    // Написать функцию ChangeCent(int money), которая принимает количество американской валюты в центах и
    // возвращает список из четырех значений, который показывает наименьшее количество монет, используемых для составления этой суммы. 
    // Рассматриваются только монетные номиналы: Pennie (1 цент), Nickel (5 центов), Dime (10 центов) and Quarter (25 центов).
    // Возвращаемый список должен быть формата [кол-во Pennie, кол-во Nickel, кол-во Dime, кол-во Quarter].
    // Если в функцию передается вещественное число, его значение сперва должно быть округлено в меньшую сторону.
    // 
    // Пример:
    // ChangeCent(56) ==> [1,1,0,2] --> 1 * 1 + 1 * 5 + 0 * 10 + 2 * 25.
    [TestClass]
    public static class TaskC2
    {
        public static List<int> ChangeCent(double money)
        {
            // Здесь необходимо написать код.

            return null;
        }

        [TestMethod]
        public static void Test1() => CollectionAssert.AreEqual(new List<int>() { 4, 0, 0, 1 }, Homework.TaskC2.ChangeCent(29), "TEST ERROR");

        [TestMethod]
        public static void Test2() => CollectionAssert.AreEqual(new List<int>() { 1, 1, 1, 3 }, Homework.TaskC2.ChangeCent(91), "TEST ERROR");

        [TestMethod]
        public static void Test3() => CollectionAssert.AreEqual(new List<int>() { 0, 0, 0, 0 }, Homework.TaskC2.ChangeCent(0), "TEST ERROR");

        [TestMethod]
        public static void Test4() => CollectionAssert.AreEqual(new List<int>() { 2, 1, 2, 4 }, Homework.TaskC2.ChangeCent(127), "TEST ERROR");

        [TestMethod]
        public static void Test5() => CollectionAssert.AreEqual(new List<int>() { 3, 0, 0, 0 }, Homework.TaskC2.ChangeCent(3.9), "TEST ERROR");
    }
}
