using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    // Задача А1.
    // Кол-во стингеров: ⅓🔹
    //
    // Напишите функцию NumberOfSquares(int limit), которая будет возвращать,
    // сколько целых (начиная с 1, 2 ...) чисел, возведенных в степень 2,
    // а затем суммированных, меньше некоторого заданного числа в качестве
    // параметра limit.
    //
    // Примеры:
    // NumberOfSquares(6) => 2 -> 1 ^ 2 + 2 ^ 2 = 1 + 4 = 5 и 5 < 6;
    // NumberOfSquares(15) => 3 -> 1 ^ 2 + 2 ^ 2 + 3 ^ 2 = 1 + 4 + 9 = 14 и 14 < 15.
    [TestClass]
    public static class TaskA1
    {
        public static int NumberOfSquares(int limit)
        {
            // Здесь необходимо написать код.
            
            return 0;
        }

        [TestMethod]
        public static void Test1() => Assert.AreEqual(0, Homework.TaskA1.NumberOfSquares(1), "TEST ERROR");

        [TestMethod]
        public static void Test2() => Assert.AreEqual(1, Homework.TaskA1.NumberOfSquares(2), "TEST ERROR");

        [TestMethod]
        public static void Test3() => Assert.AreEqual(1, Homework.TaskA1.NumberOfSquares(5), "TEST ERROR");

        [TestMethod]
        public static void Test4() => Assert.AreEqual(2, Homework.TaskA1.NumberOfSquares(6), "TEST ERROR");

        [TestMethod]
        public static void Test5() => Assert.AreEqual(3, Homework.TaskA1.NumberOfSquares(15), "TEST ERROR");

        [TestMethod]
        public static void Test6() => Assert.AreEqual(6, Homework.TaskA1.NumberOfSquares(100), "TEST ERROR");
    }
}
