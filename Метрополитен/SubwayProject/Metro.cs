using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SubwayProject
{

    // Класс, представляющий метро какого-либо города.

    public class Metro
    {
        //=======Поля класса=========

        // Список веток данного метро.

        List<Line> lines;


        // Название города, в котром находится метро.

        string city;

        //=======Конструктор========

        // Создаёт новое метро с указанным названием города.

        public Metro(string city)
        {
            lines = new();
            this.city = city;
        }

        //=========Методы========

        // Свойство, получает название города, в котором находится это метро.

        public string City => city;


        // Добавляет ветку в метро.

        public void AddLine(string name, ConsoleColor color)
        {
            lines.Add(new Line(name, color));
        }


        // Удаляет ветку по указанному имени.

        public void RemoveLine(string name)
        {
            lines.Remove(lines.First(x => x.Name == name));//Удаляем первый элемент списка, имя котрого равно аргументу.
        }

        //Методы ниже не требовалось заполнять, но я увлёкся и сделал 2 случайно. Оставшиеся 2 я пока что оставил пустыми.

        // Находит станции с указанным именем

        public List<Station> FindStation(string name)
        {
            List<Station> foundResults = new();//Создаём список тех станций, которые мы нашли.
            foreach (Line line in lines)//Циклом проходим по всем веткам
            {
                Station result = line.GetStation(name);//Пытаемся найти станцию по имени в ветке.
                if (result != null) foundResults.Add(result);//Если нашли, то добавляем к списку.
            }
            return foundResults;//Возвращаем получившийся список.
        }


        // Находит станцию с указанным именем в указанной ветке.

        public Station FindStation(string name, string lineName)
        {
            return lines.FirstOrDefault(x => x.Name == lineName)?.GetStation(name);//Получаем первую ветку, имя которой равно искомому, затем ищем в ней станцию, имя которой равно заданному.
        }
        //Метод, возвращающий список всех станций.
        public List<Station> GetStationList(string line) => lines.First(x => x.Name == line).GetStationList();//Выбрасываем исключение, чтобы показать, что метод нереализован. Вдобавок, это избавит нас от ошибки при компиляции.
        //Метод, осуществляющий загрузку данных о метро из файла.
        public void LoadStatonsFromFile(string filename)
        {
            StreamReader sr = new(filename);//Создаём считывающий поток для указанного файла.
            string line;//Переменная, в которой будем хранить строчку файла.
            while ((line = sr.ReadLine()) != null)//До тех пор, пока файл не закончится:
            {
                string[] columns = line.Split(';');//Разделяем строку на колонки по разделителю
                string lineId = columns[0];//Получаем название ветки в первой колонке.
                TryMakeLine(lineId);//Переходим ко вспомогательному методу, чтобы сделать ветку, если её ещё нет
                string stationName = columns[1];//Имя станции во второй колонке.
                string[] transfers = columns[2].Split(',');//Список доступных из неё станций со своими ветками из третьей колонки.
                List<Station> transferList = new();//Создаём переменную-список доступных станций для дальнейшего формирования.
                if (!(transfers.Length == 1 && transfers[0] == ""))
                    foreach (var c in transfers)//Для каждой доступной станции:
                    {
                        string tLineId = c.Split('-')[0];//Первым значением является название линии
                        TryMakeLine(tLineId);//Пытаемся сделать её, если таковой ещё нет.
                        string tStationName = c.Split('-')[1];//Вторым значением идёт имя станции
                        if (FindStation(tStationName, tLineId) == null)//Тут мы создаём её, если её ещё нет.
                        {
                            var found = lines.First(x => x.Name == tLineId);
                            found.AddStation(tStationName, found.Color);
                        }
                        transferList.Add(FindStation(tStationName, tLineId));//Теперь эта станция точно есть, поэтому мы можем добавить её в этот список.
                    }
                Station station = FindStation(stationName, lineId);//Проверяем, была ли станция создана ранее.
                if (station == null)//Если нет, то создаём её.
                {
                    Line currentLine = lines.First(x => x.Name == lineId);
                    currentLine.AddStation(stationName, currentLine.Color, transferList);
                }
                else station.TransferList.AddRange(transferList);//Если да, то просто добавляем список доступных станций.
            }
            lines.Sort(CompareLines);//Отсортируем ветки по именам
            sr.Close();
        }
        //Метод для сортировки списка веток
        private int CompareLines(Line l1, Line l2)
        {
            if (int.TryParse(l1.Name, out int c1) && int.TryParse(l2.Name, out int c2) || int.TryParse(l1.Name[..^1], out c1) && int.TryParse(l2.Name[..^1], out c2) || int.TryParse(l1.Name, out c1) && int.TryParse(l2.Name[..^1], out c2) || int.TryParse(l1.Name[..^1], out c1) && int.TryParse(l2.Name, out c2))//Сначала проверяем, можно ли спрасить всю строку, потом всю, кроме последнего символа. Перебираем все 4 возможных варианта сравнения
            {
                return c1.CompareTo(c2);//Если хоть один получился, то сравниваем.
            }
            return string.Compare(l1.Name, l2.Name);//Если нельзя привести к числу, то сравниваем как строки.
        }

        //Метод, осуществляющий создание ветки из названия, если этой ветки ещё нет.
        //Возврат: true, если ветки не было, false, если была.
        private bool TryMakeLine(string lineId)
        {
            if (!lines.Any(x => x.Name == lineId))//Если ветки нет в списке:
            {
                ConsoleColor color;
                if (int.TryParse(lineId, out int iLineId) && iLineId <= 15)//Задаём цвет по номеру, если это возможно (если в названии число и оно не больше 15)
                {
                    color = (ConsoleColor)iLineId;
                }
                else color = ConsoleColor.White;
                AddLine(lineId, color);//Создаём ветку и добавляем её.
                return true;
            }
            return false;
        }
        //Вспомогательное свойство для получения списка линий, а то я не смогу их иначе вывести.
        public List<Line> Lines => new(lines);//Создаю новый список, чтобы нельзя было изменить внутреннее поле.
        //Метод для установки значений для построения маршрутов.
        public void InitPreviousNextPoint()
        {
            Station old;//Перменная для предыдущей станции.
            foreach (Line line in lines)//Для каждой ветки:
            {
                old = null;//Обнуляем предыдущую станцию
                foreach (Station station in line.GetStationList())//Для каждой станции на ветке
                {
                    station.Previous = old;//Задаём предыдущую
                    if (old != null) old.Next = station;//Задаём предыдущей эту в качестве следующей
                    station.Visited = false;//Задаём Visited в false.
                    old = station;//Теперь предыдущей станет эта
                }
            }
        }
        //Метод для вычисления оптимального маршрута
        //Параметры:
        //metro - метро, которое на самом деле в методе не используется, но нужно по заданию.
        //current - текущая станция, с которой начинать строить маршрут.
        //target - станция назначения
        //route - уже построенный до этого маршрут (используется при рекурсии для построения маршрута).
        //minCount - Максимальная длина маршрута. Если более короткого не было найдено, метод вернёт null. -1 означает, что ограничений нет.
        public static List<Station> GetRoute(Metro metro, Station current, Station target, List<Station> route, int lengthLimit = -1)
        {
            route.Add(current);//Добавляем станцию в маршрут
            current.Visited = true;//Помечаем её как посещённую (хотя я не использовал это свойство, но всё же).
            if (lengthLimit != -1 && route.Count > lengthLimit) return null;//Если мы достигли лимита по длине, то искать смысла больше нет.
            if (current == target)//Если мы прибыли в место назначения, то возвращаем маршрут
            {
                return route;
            }
            List<Station> minRoute = null;//Данный список будет кратчайшим маршрутом среди всех доступных из этой станции
            foreach (var way in current.TransferList + current.Next + current.Previous)//Для каждого из выходов со станции (для пересадки, следующая станция и предыдущая):
            {
                if (!(way == null || route.Contains(way)))//Если эта станция вообще есть и её ещё не было на маршруте:
                {
                    List<Station> newRoute = GetRoute(metro, way, target, new List<Station>(route), minRoute?.Count ?? lengthLimit);//Производим расчёт маршрута для неё с учётом того, что лимитом будет минимальный, найденный до этого.
                    if (newRoute != null && (minRoute == null || newRoute.Count < minRoute.Count))//Если такой маршрут найден и он короче оптимального/ни одного маршрута ещё нет, 
                    {
                        minRoute = newRoute;//Назначаем его как оптимальный
                    }
                }
            }
            return minRoute;//Возвращаем оптимальный маршрут.
        }

        public override string ToString()
        {
            return $"{City} : {lines.Count} lines";
        }
    }
}
