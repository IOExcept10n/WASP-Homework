using System;
using System.Collections.Generic;

namespace SubwayProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Введите название города: ");
            string city = Console.ReadLine();
            Metro metro = new(city);
            Console.WriteLine("Введите путь к файлу для загрузки датасета: ");
            string filePath = Console.ReadLine();
            metro.LoadStatonsFromFile(filePath);
            string[] menu = new string[]
            {
                "Вывод всех веток и их станций",
                "Вывести станции по названию",
                "Вывести станцию по названию станции и ветки",
                "Вывести все станции определёной ветки",
                "Выйти из программы"
            };
            bool action = true;
            while (action)
            {
                int currentMenuItem = 0;
                ConsoleKeyInfo input;
                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Выберите действие (стрелками вверх-вниз, Enter для выбора):");
                    for (int i = 0; i < menu.Length; i++)
                    {
                        char addChar = i == currentMenuItem ? '>' : ' ';
                        Console.WriteLine(addChar + menu[i]);
                    }
                    input = Console.ReadKey();
                    if (input.Key == ConsoleKey.UpArrow)
                    {
                        if (currentMenuItem == 0) currentMenuItem = menu.Length - 1;
                        else currentMenuItem--;
                    }
                    else if (input.Key == ConsoleKey.DownArrow)
                    {
                        if (currentMenuItem == menu.Length - 1) currentMenuItem = 0;
                        else currentMenuItem++;
                    }
                } while (input.Key != ConsoleKey.Enter);
                Console.Clear();
                Console.ResetColor();
                switch (currentMenuItem)
                {
                    case 0:
                        {
                            foreach (var line in metro.Lines)
                            {
                                line.PrintLine();
                            }
                            break;
                        }
                    case 1:
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Введите название станции: ");
                            string name = Console.ReadLine();
                            List<Station> result = metro.FindStation(name);
                            foreach (Station s in result)
                            {
                                Console.ForegroundColor = s.Color;
                                Console.WriteLine(s);
                                Console.WriteLine($"Ветка: {s.LineName}");
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Введите название станции: ");
                            string name = Console.ReadLine();
                            Console.Write("Введите название ветки: ");
                            string line = Console.ReadLine();
                            Station result = metro.FindStation(name, line);
                            Console.ForegroundColor = result.Color;
                            Console.WriteLine(result);
                            Console.WriteLine($"Ветка: {result.LineName}");
                            Console.WriteLine("Список доступных из неё станций: ");
                            foreach (var s in result.TransferList)
                            {
                                Console.ForegroundColor = s.Color;
                                Console.WriteLine("-- " + s);
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Введите название ветки: ");
                            string line = Console.ReadLine();
                            List<Station> result = metro.GetStationList(line);
                            foreach (Station s in result)
                            {
                                Console.ForegroundColor = s.Color;
                                Console.WriteLine(s);
                            }
                            break;
                        }
                    case 4:
                        {
                            action = false;
                            break;
                        }
                }
                if (action) Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Работа программмы завершена. Спасибо за пользование!");
        }
    }
}
