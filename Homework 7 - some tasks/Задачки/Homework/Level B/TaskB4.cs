using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    // Задача B4.
    // Кол-во стингеров: 🔷
    //
    // Написать функцию CheckBrackets(string s), которая определяет,
    // правильно ли расставлены скобки () {} [] <> в предложении.
    //
    // Примеры:
    // CheckBrackets("(abc)[]{0:1}") ==> true;
    // CheckBrackets("(abc)]{0:1}[") ==> false.
    [TestClass]
    public static class TaskB4
    {
        public static bool CheckBrackets(string s)
        {
            // Здесь необходимо написать код.

            return false;
        }

        [TestMethod]
        public static void Test1() => Assert.IsTrue(Homework.TaskB4.CheckBrackets("(5+5)/[4+4]*{2*2}"), "TEST ERROR");

        [TestMethod]
        public static void Test2() => Assert.IsFalse(Homework.TaskB4.CheckBrackets("(3+[2*3)]"), "TEST ERROR");

        [TestMethod]
        public static void Test3() => Assert.IsTrue(Homework.TaskB4.CheckBrackets("[{([[[<>]]])(<>)(){}}]"), "TEST ERROR");

        [TestMethod]
        public static void Test4() => Assert.IsFalse(Homework.TaskB4.CheckBrackets("]()(){<>}[[()]]"), "TEST ERROR");

        [TestMethod]
        public static void Test5() => Assert.IsTrue(Homework.TaskB4.CheckBrackets("[(sjd),\"2\"],{2:3}, [<>]"), "TEST ERROR");

        [TestMethod]
        public static void Test6() => Assert.IsFalse(Homework.TaskB4.CheckBrackets("{[[[[((()))]]<]>]}"), "TEST ERROR");
    }
}
