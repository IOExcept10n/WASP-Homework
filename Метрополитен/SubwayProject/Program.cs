using System;
using System.Collections.Generic;

namespace SubwayProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;//Задём синий цвет консоли для сообщений-пояснений
            Console.Write("Введите название города: ");//Запрашиваем у пользователя название города
            string city = Console.ReadLine();//Записываем его в переменную city
            Metro metro = new(city);//Создаём новое метро
            Console.WriteLine("Введите путь к файлу для загрузки датасета: ");//Запрашиваем путь к файлу.
            string filePath = Console.ReadLine();//Записываем в переменную
            metro.LoadStatonsFromFile(filePath);//Загружаем станции.
            string[] menu = new string[]//Создаём шаблон для меню действий.
            {
                "Вывод всех веток и их станций",
                "Вывести станции по названию",
                "Вывести станцию по названию станции и ветки",
                "Вывести все станции определёной ветки",
                "Построить маршрут между станциями",
                "Выйти из программы"
            };
            bool action = true;//Создаём переменную-флаг для выхода из цикла.
            while (action)//Псевдобесконечный цикл для выполнения действий программы.
            {
                metro.InitPreviousNextPoint();
                int currentMenuItem = 0;//Переменная для хранения выбранного элемента меню. 
                ConsoleKeyInfo input;//Переменная для хранения клавиши, которую нажмёт пользователь.
                do//Цикл для работы меню:
                {
                    Console.Clear();//Стираем всё, что было в консоли.
                    Console.ForegroundColor = ConsoleColor.Blue;//Синий цвет для системных сообщений
                    Console.WriteLine("Выберите действие (стрелками вверх-вниз, Enter для выбора):");//Просим пользователя нажимать кнопки для выбора
                    for (int i = 0; i < menu.Length; i++)//Циклом выводим элементы меню со стрелочкой-курсором
                    {
                        char addChar = i == currentMenuItem ? '>' : ' ';//Курсор есть, если это элемент, на котором сейчас пользователь.
                        Console.WriteLine(addChar + menu[i]);//Выводим элемент меню.
                    }
                    input = Console.ReadKey();//Получаем данные о вводе.
                    if (input.Key == ConsoleKey.UpArrow)//Если это стрелка вверх, то двигаем крусор вверх
                    {
                        if (currentMenuItem == 0) currentMenuItem = menu.Length - 1;//Или переводим его на самый низ, если он достиг самого верха
                        else currentMenuItem--;
                    }
                    else if (input.Key == ConsoleKey.DownArrow)//Если стрелка вниз, то наоборот
                    {
                        if (currentMenuItem == menu.Length - 1) currentMenuItem = 0;
                        else currentMenuItem++;
                    }
                } while (input.Key != ConsoleKey.Enter);//Если нажат Enter, то выходим из цикла
                Console.Clear();//Очищаем консоль
                Console.ResetColor();//Убираем цвета.
                switch (currentMenuItem)//В зависимости от  выбранного пункта меню выполняем действие:
                {
                    case 0://Если первый пункт:
                        {
                            foreach (var line in metro.Lines)//Выводим все ветки метро
                            {
                                line.PrintLine();
                            }
                            break;
                        }
                    case 1://Второй пункт (найти все станции по названию)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;//Синий цвет для ввода
                            Console.Write("Введите название станции: ");//Просим ввести название для поиска
                            string name = Console.ReadLine();//Записываем в переменную
                            List<Station> result = metro.FindStation(name);//Находим результаты поиска.
                            foreach (Station s in result)//Выводим результаты
                            {
                                Console.ForegroundColor = s.Color;//С цветом данной ветки
                                Console.WriteLine(s);
                                Console.WriteLine($"Ветка: {s.LineName}");
                            }
                            break;
                        }
                    case 2://Третий пункт меню, вывод конкретной станции.
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;//Синий цвет ввода
                            Console.Write("Введите название станции: ");//Просим ввыести название
                            string name = Console.ReadLine();//Сохраняем в переменную
                            Console.Write("Введите название ветки: ");//Просим ввести название ветки
                            string line = Console.ReadLine();//Сохраняем в переменную
                            Station result = metro.FindStation(name, line);//Ищем результат
                            Console.ForegroundColor = result.Color;//Выводим всё с нужным цветом.
                            Console.WriteLine(result);//Выводим результат и список жоступных станций.
                            Console.WriteLine($"Ветка: {result.LineName}");
                            Console.WriteLine("Список доступных из неё станций: ");
                            foreach (var s in result.TransferList)
                            {
                                Console.ForegroundColor = s.Color;
                                Console.WriteLine("-- " + s);
                            }
                            break;
                        }
                    case 3://Четвёртый пункт, вывод всех станций на ветке, всё примерно так же
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
                            Console.ForegroundColor = ConsoleColor.Blue;//Синий цвет ввода
                            Console.Write("Введите название станции отправления: ");//Просим ввыести название
                            string name = Console.ReadLine();//Сохраняем в переменную
                            Console.Write("Введите название ветки со станцией отправления: ");//Просим ввести название ветки
                            string line = Console.ReadLine();//Сохраняем в переменную
                            Station start = metro.FindStation(name, line);//Ищем результат
                            if (start == null)//Проверяем правильность ввода.
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка: введены неверные данные. Попробуйте написать станции заново.");
                                break;
                            }
                            Console.ForegroundColor = ConsoleColor.Blue;//Синий цвет ввода
                            Console.Write("Введите название станции назначения: ");//Просим ввыести название
                            name = Console.ReadLine();//Сохраняем в переменную
                            Console.Write("Введите название ветки со станцией назначения: ");//Просим ввести название ветки
                            line = Console.ReadLine();//Сохраняем в переменную
                            Station end = metro.FindStation(name, line);//Ищем результат
                            if (end == null)//Проверяем правильность ввода.
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка: введены неверные данные. Попробуйте написать станции заново.");
                                break;
                            }
                            List<Station> route = Metro.GetRoute(metro, start, end, new List<Station>());//Получаем маршрут через специализированный метод.
                            if (route != null)//Если маршрут найден:
                            {
                                Console.WriteLine("Полученный маршрут: ");
                                foreach (Station s in route)//Форматированно выводим маршрут.
                                {
                                    Console.ForegroundColor = s.Color;
                                    Console.WriteLine($"-> {s.Name}, Line: {s.LineName}");
                                }
                            }
                            else//Если вдруг маршрут не найден (на всякий случай):
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Ошибка: из данной станции невозможно попасть в указанную! (Правда верится в это с трудом)");
                            }
                            break;
                        }
                    case 5://Шестой пункт, выход из цикла.
                        {
                            action = false;
                            break;
                        }
                }
                if (action) Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.White;//Завершение работы программы.
            Console.WriteLine("Работа программмы завершена. Спасибо за пользование!");
        }
    }
}
