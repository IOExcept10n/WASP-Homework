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
    public static class TaskB5
    {
        public static string Frame(List<string> text, char symbol)
        {
            // Здесь необходимо написать код.
            text = text.ConvertAll(x => " " + x + " ");//Это нужно, чтобы от красивой рамочки до текста были дополнительные пробелы.
            int height = text.Count + 2;//Высота - число строк + 2 рамки
            int width = text.Max(x => x.Length) + 2;//Ширина - наибольшая длина подстроки + 2 рамки
            string answer = "";
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == 0 || x == width - 1 || y == 0 || y == height - 1) answer += symbol;//Добавляем рамку, если находимся на границе.
                    else
                    {
                        if (x - 1 < text[y - 1].Length) answer += text[y - 1][x - 1];//Порядок именно такой из-за того, что у нас список строк. В нём сначала идёт номер строки, а потом номер символа.
                        else answer += ' ';//Добавляем пробел, если строка закончилась, но не является наибольшей.
                    }
                }
                answer += '\n';
            }
            return answer.Trim('\n');
        }
    }
}
