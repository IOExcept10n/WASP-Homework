using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Test1.Homework
{
    class HomeworkArrays
    {
        /*public static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;//Делаю, чтобы формат ввода и вывода вещественных чисел не допускал разделительной запятой, а делал вместо этого точку.
            //Задача 1.
            Task1();
            //Задача 2.
            Console.ResetColor();
            Console.WriteLine("Задание 2: нахождение элементов и подсчёт их частоты. ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Введите несколько целых чисел через пробел (в дальнейшем используйте этот формат при вводе массивов): ");
            var array1 = TryMassParse(Console.ReadLine().Split());
            Task2(array1, new int[,]
                {
                    { 12, 45, 12, 3, 78, 1234, 1234, 546, 243, 567, 768574 },
                    { 76, 59, 47, 83, 58, 24, 75, 0, 12, 34, 54 },
                    { 0, 123, 5343, 0, 6543, 9876543, 12345678, 0, 0, 0, 0 },
                    { 85, 21, 75, 84, 34, 54, 54, 34, 54, 34, 54 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                });
            //Задача 3 и 4.
            Console.ResetColor();
            Console.WriteLine("Задания 3-4: Создание 2 массивов и нахождение их подмассива.");
            Task3(out array1, out int[] array2);
            PrintArray(Task4(array1, array2));
            //Я не совсем понял задачи 3 и 4, они просто нужны как вспомогательные для других задач?
            //Задача 5
            Console.ResetColor();
            Console.WriteLine("Задание 5: Сложение массивов.");
            Task3(out array1, out array2);
            PrintArray(Task5(array1, array2));
            //Задача 6
            Console.ResetColor();
            Console.WriteLine("Задание 6: Нахождение процента совпадений в массиве.");
            Task3(out array1, out array2);
            Task6(array1, array2);
            //Задача 7
            Console.ResetColor();
            Console.WriteLine("Задание 7: Нахождение средних значений в массивах.");
            Task3(out array1, out array2);
            Task7(array1, array2);
        }*/

        public static void Task1()
        {
            Console.ResetColor();
            Console.WriteLine("задание 1 - ввод и вывод массивов.");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Пожалуйста, введите список чисел, разделяя их пробелами: ");
            string[] inputs = Console.ReadLine().Split(' ');
            string output = "";
            TryMassParse(inputs).ToList().ForEach(x => output += x + " , ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Вывод первого задания: {output.Trim(' ', ',')}");
            Console.WriteLine("Ниже для примера приведены варианты вывода произвольно заполненных двумерного и вложенного массива: ");
            PrintArray(new int[,]
                {
                    { 1, 2, 434, 456, 789, 900, 1234, 5432 },
                    { 3, 4, 765, 876, 98, 124, 654, 786 },
                    { 1, 2, 3, 4, 5, 6, 7, 8 }
                });
            Console.WriteLine();
            PrintArray(new double[][]
                {
                    new double[] { 1, 8, 3.4, 5.43, 3.14 }, 
                    new double[7],
                    new double[] { 9, 3.14, 98, 123.456, 87 }
                });
        }

        public static void Task2(int[] array, int[,] array2)
        {
            int min = array[0];
            int max = array[0];
            int minF = 1;
            int maxF = 1;
            for (int i = 1; i < array.Length; i++)
            {
                int test = array[i];
                if (test == min) minF++;
                else if (test < min)
                {
                    min = test;
                    minF = 1;
                }
                if (test == max) maxF++;
                else if (test > max)
                {
                    max = test;
                    maxF = 1;
                }
            }
            Console.ResetColor();
            Console.WriteLine($"Проверка массива 1: Минимальное значение: {min}, частота: {minF}. Максимальное значение: {max}, частота: {maxF}");
            min = max = array2[0, 0];
            minF = maxF = 0;
            for (int x = 0; x < array2.GetLength(0); x++)
            {
                for (int y = 0; y < array2.GetLength(1); y++)
                {
                    int test = array2[x, y];
                    if (test == min) minF++;
                    else if (test < min)
                    {
                        min = test;
                        minF = 1;
                    }
                    if (test == max) maxF++;
                    else if (test > max)
                    {
                        max = test;
                        maxF = 1;
                    }
                }
            }
            Console.WriteLine($"Проверка массива 2: Минимальное значение: {min}, частота: {minF}. Максимальное значение: {max}, частота: {maxF}");
        }

        public static void Task3(out int[] arr1, out int[] arr2)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Введите первый массив: ");
            arr1 = TryMassParse(Console.ReadLine().Split());
            Console.Write("Введите второй массив: ");
            arr2 = TryMassParse(Console.ReadLine().Split());
        }

        public static int[] Task4(int[] arr1, int[] arr2)
        {
            int[] ret = new int[Math.Min(arr1.Length, arr2.Length)];
            return ret;
        }
        //Использовать не буду, но сделаю на всякий случай, чтобы поддерживало двумерные массивы.
        public static int[,] Task4(int[,] arr1, int[,] arr2)
        {
            int[,] ret = new int[Math.Min(arr1.GetLength(0), arr2.GetLength(0)), Math.Min(arr1.GetLength(1), arr2.GetLength(1))];
            return ret;
        }

        public static int[] Task5(int[] arr1, int[] arr2)
        {
            int[] ret = new int[Math.Min(arr1.Length, arr2.Length)];//Не должен быть больше первого и второго.
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = arr1[i] + arr2[i];
            }
            return ret;
        }

        public static void Task6(int[] arr1, int[] arr2)
        {
            int subLength = Math.Min(arr1.Length, arr2.Length);
            int matches = 0;
            for (int i = 0; i < subLength; i++)
            {
                if (arr1[i] == arr2[i]) matches++;
            }
            Console.WriteLine($"Анализ проведён успешно, процент совпадений: {matches * 100.0 / subLength}%");
        }

        public static void Task7(int[] arr1, int[] arr2)
        {
            double avg1 = GetAverage(arr1), avg2 = GetAverage(arr2);
            Console.WriteLine($"Среднее значение по массивам: Массив 1 — {avg1}, массив 2 — {avg2}");
            int sum = 0;
            double num = arr1.Length + arr2.Length;
            foreach (var c in arr1) sum += c;
            foreach (var c in arr2) sum += c;
            Console.WriteLine($"Общее среднее значение: {sum / num}");
        }

        public static double GetAverage(int[] arr)
        {
            int sum = 0;
            double num = arr.Length;
            foreach (var c in arr) sum += c;
            return sum / num;
        }

        /// <summary>
        /// Выводит указанный массив в консоль.
        /// </summary>
        /// <typeparam name="T">Тип массива.</typeparam>
        /// <param name="array">Выводимый массив.</param>
        public static void PrintArray<T>(T[] array)
        {
            Console.ResetColor();
            string output = "";
            for (int i = 0; i < array.Length; i++)
            {
                output += array[i].ToString() + " , ";
            }
            Console.WriteLine(output.Trim(' ', ','));
        }
        /// <summary>
        /// Выводит указанный двумерный массив на экран.
        /// </summary>
        /// <typeparam name="T">Тип массива.</typeparam>
        /// <param name="array">Выводимый массив.</param>
        public static void PrintArray<T>(T[,] array)
        {
            Console.ResetColor();
            string output = "";
            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++) output += array[x, y].ToString() + " , ";
                output = output.Trim(',', ' ');
                output += "\n";
            }
            Console.WriteLine(output.Trim(' ', ',', '\n'));
        }
        /// <summary>
        /// Выводит указанный двумерный массив на экран.
        /// </summary>
        /// <typeparam name="T">Тип массива.</typeparam>
        /// <param name="array">Выводимый массив.</param>
        public static void PrintArray<T>(T[][] array)
        {
            Console.ResetColor();
            string output = "";
            for (int x = 0; x < array.GetLength(0); x++)
            {
                foreach (var c in array[x]) output += c.ToString() + " , ";
                output = output.Trim(',', ' ');
                output += "\n";
            }
            Console.WriteLine(output.Trim(' ', ',', '\n'));
        }

        public static int[] TryMassParse(params string[] inputs)
        {
            bool flag = false;
            int[] ret = new int[inputs.Length];
            int i = 0;
            do
            {
                if (flag)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Произошла ошибка при конвертировании. Пожалуйста, введите числа заново, разделяя их пробелами: ");
                    inputs = Console.ReadLine().Split();
                    ret = new int[inputs.Length];
                }
                foreach (var c in inputs)
                {
                    if (!int.TryParse(c, out ret[i++]))
                    {
                        i = 0;
                        flag = true;
                        break;
                    }
                }
                if (i == inputs.Length) flag = false;
            } while (flag);
            return ret;
        }
    }
}
