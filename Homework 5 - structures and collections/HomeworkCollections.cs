using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Homework
{
    class HomeworkCollections
    {
        public static void Main(string[] args)
        {
            //Я правильно понял, что раз в задаче не указано о "неправильном" вводе, его не надо обрабатывать?
            Console.WriteLine("Task 1 - single elements.");
            DoTask(Task1);//Так удобнее осуществлять действия, связанные с массивами. Нет необходимости несколько раз писать код для получения массива.

            //Задание 2.
            Console.ResetColor();
            Console.WriteLine("Task 2 - array sorting");
            DoTask(Task2);

            //Задание 3.
            Console.ResetColor();
            Console.WriteLine("Task 3 - exact power");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Введите число N: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите число M: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Task3(n, m);

            //Задание 4.
            Console.ResetColor();
            Console.WriteLine("Task 4 - Sequence shift");
            List<int> numbers = new List<int>();
            n = 0;
            int sumAll = 0, input = 0;
            double s = 0, numerator = 0, sigma = 0;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Введите последовательность натуральных чисел (каждое число на новой строке), признаком окончания будет 0. ");
            input = Convert.ToInt32(Console.ReadLine());
            do
            {
                n++;
                numbers.Add(input);
            } while ((input = Convert.ToInt32(Console.ReadLine())) != 0);
            sumAll = numbers.Sum();
            s = sumAll * 1.0 / n;
            foreach (var xN in numbers)
            {
                numerator += Math.Pow(xN - s, 2);
            }
            sigma = Math.Sqrt(numerator / (n - 1));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(sigma);

            //Задание 5.
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Введите число кегль и бросков через пробел: ");
            int[] inputData = HomeworkArrays.TryMassParse(Console.ReadLine().Split());
            n = inputData[0];
            int k = inputData[1];
            List<bool> pins = new List<bool>(new bool[n]);
            for (int i = 0; i < k; i++)
            {
                Console.Write("Введите номера первой и последней кегли: ");
                inputData = HomeworkArrays.TryMassParse(Console.ReadLine().Split());
                int li = inputData[0] - 1;
                int ri = inputData[1];
                for (int j = li; j < ri; j++)
                {
                    pins[j] = true;
                }
            }
            string result = "";
            foreach (bool c in pins)
            {
                result += c ? "." : "|";
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(result);
        }

        static bool DoTask(Func<int[], int[]> someAction)
        {
            bool flag = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Введите число элементов: ");
                int N = Convert.ToInt32(Console.ReadLine());
                int[] array = HomeworkArrays.TryMassParse(Console.ReadLine().Split());//Использую методы из предыдущего домашнего задания
                if (N == array.Length)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    PrintArray(someAction(array));
                    flag = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка: число элементов в массиве не совпало с числом, указанным до этого. Повторите ввод массива.");
                    continue;
                }
            } while (flag);
            return flag;
        }

        public static int[] Task1(int[] arr)
        {
            var elementRates = CountElements(arr);
            List<int> result = elementRates.Where((x, y) => x.Value == 1).Select((pair, index) => pair.Key).ToList();
            //Это если можно использовать Linq. Если нельзя, то снизу аналогичный закомментированный код:
            /*List<int> result = new List<int>();
            foreach (var c in elementRates)
            {
                if (c.Value == 1) result.Add(c.Key);
            }*/
            return result.ToArray();
        }

        public static int[] Task2(int[] arr)
        {
            for (int n = 0; n < arr.Length; n++)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] >= arr[i + 1])
                    {
                        int temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }
            return arr;
        }

        public static void Task3(int N, int M)
        {
            double log = Math.Log(N, M);
            if (log % 1 == 0 || double.IsNaN(log))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("YES");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO");
            }
            //Или, опять же, если логарифмы нельзя, альтернативное решение:
            /*while (N % M == 0)
            {
                if (N / M == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("YES");
                    break;
                }
                N /= M;
            }
            if (N / M != 1) Console.WriteLine("NO");*/
        }

        /// <summary>
        /// Подсчитывает количество элементов в массиве.
        /// </summary>
        public static Dictionary<int, int> CountElements(int[] arr)
        {
            Dictionary<int, int> result = new();
            foreach (int c in arr)
            {
                if (result.ContainsKey(c)) result[c]++;
                else result.Add(c, 1);
            }
            return result;
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
                output += array[i].ToString() + " ";
            }
            Console.WriteLine(output.Trim(' ', ','));
        }
    }
}
