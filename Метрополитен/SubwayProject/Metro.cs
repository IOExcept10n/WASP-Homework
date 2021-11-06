using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.city = city;
        }

        //=========Методы========

        // Получает название города, в котором находится это метро.

        public string GetCity() => city;


        // Добавляет ветку в метро.

        public void AddLine(string name, string color)
        {
            lines.Add(new Line(name, color));
        }


        // Удаляет ветку по указанному имени.

        public void RemoveLine(string name)
        {
            lines.Remove(lines.First(x => x.GetName() == name));//Удаляем первый элемент списка, имя котрого равно аргументу.
        }

        //Методы ниже не требовалось заполнять, но я увлёкся и сделал 2 случайно. Оставшиеся 2 я пока что оставил пустыми.

        // Находит станции с указанным именем

        public List<Station> FindStation(string name)
        {
            List<Station> foundResults = new List<Station>();//Создаём список тех станций, которые мы нашли.
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
            return lines.First(x => x.GetName() == lineName).GetStation(name);//Получаем первую ветку, имя которой равно искомому, затем ищем в ней станцию, имя которой равно заданному.
        }

        public List<Station> GetStationList()
        {
            throw new NotImplementedException();//Выбрасываем исключение, чтобы показать, что метод нереализован. Вдобавок, это избавит нас от ошибки при компиляции.
        }

        public void LoadStatonsFromFile(string filename)
        {
            
        }
    }
}
