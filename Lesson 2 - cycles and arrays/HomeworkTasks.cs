using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Homework
{
    class HomeworkTasks
    {
        /// <summary>
        /// Squirrels with nuts
        /// </summary>
        public static void Homework1()
        {
            int N = Convert.ToInt32(Console.ReadLine());
            int K = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(K / N);
        }
        /// <summary>
        /// Last digit
        /// </summary>
        public static void Homework2()
        {
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(num % 10);
        }
        /// <summary>
        /// Number of tens
        /// </summary>
        public static void Homework3()
        {
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(num % 100 / 10);
        }
        /// <summary>
        /// Symmetric number
        /// </summary>
        public static void Homework4()
        {
            string num = Console.ReadLine();
            string ret = "";
            for (int i = num.Length - 1; i >= 0; i--)
            {
                ret += num[i];
            }
            Console.WriteLine(ret);
        }
        /// <summary>
        /// Snail
        /// </summary>
        public static void Homework5()
        {
            int H = Convert.ToInt32(Console.ReadLine());
            int A = Convert.ToInt32(Console.ReadLine());
            int B = Convert.ToInt32(Console.ReadLine());
            int day = 0;
            for (int height = 0; height < H;)
            {
                day++;
                height += A;
                if (height >= H) break;
                height -= B;
            }
            Console.WriteLine(day);
        }
    }
}
