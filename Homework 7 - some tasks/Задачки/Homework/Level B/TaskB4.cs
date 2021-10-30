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
    public static class TaskB4
    {
        public static bool CheckBrackets(string s)
        {
            // Здесь необходимо написать код.
            Stack<Bracket> bracketsStructure = new Stack<Bracket>();
            foreach (char c in s)
            {
                switch (c)
                {
                    case '(':
                        bracketsStructure.Push(Bracket.Round);
                        break;
                    case '{':
                        bracketsStructure.Push(Bracket.Curly);
                        break;
                    case '[':
                        bracketsStructure.Push(Bracket.Square);
                        break;
                    case '<':
                        bracketsStructure.Push(Bracket.Triangle);
                        break;
                    case ')':
                        if (bracketsStructure.Count == 0 || bracketsStructure.Pop() != Bracket.Round) return false;
                        break;
                    case '}':
                        if (bracketsStructure.Count == 0 || bracketsStructure.Pop() != Bracket.Curly) return false;
                        break;
                    case ']':
                        if (bracketsStructure.Count == 0 || bracketsStructure.Pop() != Bracket.Square) return false;
                        break;
                    case '>':
                        if (bracketsStructure.Count == 0 || bracketsStructure.Pop() != Bracket.Triangle) return false;
                        break;
                }
            }
            if (bracketsStructure.Count == 0) return true;
            return false;
        }
        /// <summary>
        /// Введу перечисление для скобочек, чтобы определять, какая из скобок открыта.
        /// </summary>
        //[Flags]
        public enum Bracket
        {
            /// <summary>
            /// Отсутствие каких-либо скобок.
            /// </summary>
            None = 0,
            /// <summary>
            /// Круглая скобка.
            /// </summary>
            Round = 1,
            /// <summary>
            /// Фигурная скобка.
            /// </summary>
            Curly = 2,
            /// <summary>
            /// Квадратная скобка.
            /// </summary>
            Square = 4,
            /// <summary>
            /// Треугольная скобка (не знаю, как на самом деле называется).
            /// </summary>
            Triangle = 8
        }
    }
}
