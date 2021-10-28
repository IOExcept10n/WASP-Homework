using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    // Задача B1.
    // Кол-во стингеров: ½🔹
    //
    // Написать функцию MeanSquare(List<int> list1, List<int> list2),
    // которая получает два целочисленных списка одинаковой длины,
    // сравнивает значение каждого члена в одном списке с соответствующим
    // элементом в другом, возводит в квадрат разницу абсолютных значений
    // между этими двумя значениями и возвращает среднее значение квадратов
    // каждой парой элементов. 
    //
    // Пример:
    // MeanSquare([0, -1], [-1, 0]) ==> 1 --> ( (0-(-1))^2 + (-1-0)^2 ) / 2 = 1
    [TestClass]
    public static class TaskB1
    {
        public static double MeanSquare(List<int> list1, List<int> list2)
        {
            // Здесь необходимо написать код.

            return 0;
        }

        [TestMethod]
        public static void Test1() => Assert.AreEqual(9, Homework.TaskB1.MeanSquare(new List<int>() { 1, 2, 3 }, new List<int>() { 4, 5, 6 }), "TEST ERROR");

        [TestMethod]
        public static void Test2() => Assert.AreEqual(16.5, Homework.TaskB1.MeanSquare(new List<int>() { 10, 20, 10, 2 }, new List<int>() { 10, 25, 5, -2 }), "TEST ERROR");

        [TestMethod]
        public static void Test3() => Assert.AreEqual(1, Homework.TaskB1.MeanSquare(new List<int>() { 0, -1 }, new List<int>() { -1, 0 }), "TEST ERROR");

        [TestMethod]
        public static void Test4() => Assert.AreEqual(0, Homework.TaskB1.MeanSquare(new List<int>() { 10, 10 }, new List<int>() { 10, 10 }), "TEST ERROR");
    }
}
