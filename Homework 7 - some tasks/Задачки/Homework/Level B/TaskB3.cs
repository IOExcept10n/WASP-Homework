using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    // Задача B3.
    // Кол-во стингеров: ½🔹
    //
    // Написать функцию Decrypt(string key), которая подсчитывает количество вхождений символов с 'a' до 'z' и 
    // возвращает строку длиной 26 символов, где на каждой позиции - количетво вхождений этой буквы в строке. 
    // Буквы должны быть упорядочены, как в алфавите.
    //
    // Примеры:
    // decrypt('$aaaa#bbb*cc^fff!z') ==> '43200300000000000000000001'
    //           ^    ^   ^  ^  ^         ^^^  ^                   ^
    //          [4]  [3] [2][3][1]        abc  f                   z
    [TestClass]
    public static class TaskB3
    {
        public static string Decrypt(string key)
        {
            // Здесь необходимо написать код.

            return "";
        }

        [TestMethod]
        public static void Test1() => Assert.AreEqual("43200300000000000000000001", Homework.TaskB3.Decrypt("$aaaa#bbb*ccfff!z"), "TEST ERROR");

        [TestMethod]
        public static void Test2() => Assert.AreEqual("30303000000000000000000001", Homework.TaskB3.Decrypt("z$aaa#ccc%eee1234567890"), "TEST ERROR");
    }
}
