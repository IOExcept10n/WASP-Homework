using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    // Задача А2.
    // Кол-во стингеров: ⅓🔹
    //
    // Написать функцию VeryEven(number), которая определяет является ли число "очень четным".
    // Однозначное число "очень четное", если оно четное. Числа больше 10 "очень четные",
    // если сумма их цифр - "очень четное" число.
    //
    // Примеры:
    // VeryEven(88) => false -> 8 + 8 = 16 -> 1 + 6 = 7 => 7 - нечетное;
    // VeryEven(222) => true -> 2 + 2 + 2 = 8 => 8 - четное.
    [TestClass]
    public static class TaskA2
    {
        public static bool VeryEven(int number)
        {
            // Здесь необходимо написать код.

            return false;
        }

        [TestMethod]
        public static void Test1() => Assert.IsTrue(Homework.TaskA2.VeryEven(4), "TEST ERROR");

        [TestMethod]
        public static void Test2() => Assert.IsFalse(Homework.TaskA2.VeryEven(5), "TEST ERROR");

        [TestMethod]
        public static void Test3() => Assert.IsFalse(Homework.TaskA2.VeryEven(12), "TEST ERROR");

        [TestMethod]
        public static void Test4() => Assert.IsFalse(Homework.TaskA2.VeryEven(1234), "TEST ERROR");

        [TestMethod]
        public static void Test5() => Assert.IsTrue(Homework.TaskA2.VeryEven(7897), "TEST ERROR");
    }
}
