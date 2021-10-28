using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    // Задача B5.
    // Кол-во стингеров: ½🔷
    //
    // Написать функцию Frame(string text, char symbol), которая заключает
    // список строк text в рамку из символов char и возвращает данную строку.
    //
    // Пример:
    // frame(['Create', 'a', 'frame'], '+') ==>
    // ++++++++++
    // + Create +
    // + a      +
    // + frame  +
    // ++++++++++
    [TestClass]
    public static class TaskB5
    {
        public static string Frame(List<string> text, char symbol)
        {
            // Здесь необходимо написать код.

            return "";
        }

        [TestMethod]
        public static void Test1() => Assert.AreEqual("~~~~~~~~~\n~ Small ~\n~ text  ~\n~ frame ~\n~~~~~~~~~",
           Homework.TaskB5.Frame(new List<string>() { "Small", "text", "frame" }, '~'), "TEST ERROR");

        [TestMethod]
        public static void Test2() => Assert.AreEqual("------------------------------------\n- This is a very long single frame -\n------------------------------------",
            Homework.TaskB5.Frame(new List<string>() { "This is a very long single frame" }, '-'), "TEST ERROR");
    }
}
