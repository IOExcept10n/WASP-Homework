using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    // Задача B6.
    // Кол-во стингеров: ½🔷
    //
    // Написать функцию Reverser, которая меняет порядок букв в каждом слове заданного
    // предложения на противоположный, порядок слов, при этом, должен сохраниться.
    //
    // Пример:
    // Reverser("reverse letters") ==> "esrever srettel".
    [TestClass]
    public static class TaskB6
    {
        public static string Reverser(string s)
        {
            // Здесь необходимо написать код.

            return "";
        }

        [TestMethod]
        public static void Test1() => Assert.AreEqual("esrever srettel", Homework.TaskB6.Reverser("reverse letters"), "TEST ERROR");

        [TestMethod]
        public static void Test2() => Assert.AreEqual("A nuf elttil !egnellahc", Homework.TaskB6.Reverser("A fun little challenge!"), "TEST ERROR");

        [TestMethod]
        public static void Test3() => Assert.AreEqual("  ", Homework.TaskB6.Reverser("  "), "TEST ERROR");
    }
}
