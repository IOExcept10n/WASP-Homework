using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    // Задача А3.
    // Кол-во стингеров: ⅓🔹
    //
    // Напишите функцию SumCube(int n, int m), которая будет вычислять сумму кубов чисел в заданном диапазоне, 
    // начиная с меньшего (но не включая его) до большего (включая). Первый аргумент не обязательно
    // должен быть большим числом. Если оба числа совпадают, тогда диапазон пуст и результат должен быть 0.
    //
    // Примеры:
    // sum_cube(2,3) => 27 -> 3^3 = 27;
    // sum_cube(3,2) => 27 -> 3^3 = 27;
    // sum_cube(0,4) => 100 -> 1^3+2^3+3^3+4^3 = 100;
    // sum_cube(17, 14) => 12384 -> 15^3+16^3+17^3 = 12384.
    [TestClass]
    public static class TaskA3
    {
        public static int SumCube(int n, int m)
        {
            // Здесь необходимо написать код.

            return 0;
        }

        [TestMethod]
        public static void Test1() => Assert.AreEqual(27, Homework.TaskA3.SumCube(2, 3), "TEST ERROR");

        [TestMethod]
        public static void Test2() => Assert.AreEqual(27, Homework.TaskA3.SumCube(3, 2), "TEST ERROR");

        [TestMethod]
        public static void Test3() => Assert.AreEqual(100, Homework.TaskA3.SumCube(0, 4), "TEST ERROR");

        [TestMethod]
        public static void Test4() => Assert.AreEqual(12384, Homework.TaskA3.SumCube(17, 14), "TEST ERROR");

        [TestMethod]
        public static void Test5() => Assert.AreEqual(0, Homework.TaskA3.SumCube(9, 9), "TEST ERROR");

        [TestMethod]
        public static void Test6() => Assert.AreEqual(225, Homework.TaskA3.SumCube(5, 0), "TEST ERROR");
    }
}
