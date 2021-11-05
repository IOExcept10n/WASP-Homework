using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubwayProject
{
    /// <summary>
    /// Класс, представляющий метро какого-либо города.
    /// </summary>
    public class Metro
    {
        //Поля класса
        /// <summary>
        /// Список веток данного метро.
        /// </summary>
        List<Line> lines;

        /// <summary>
        /// Название города, в котром находится метро.
        /// </summary>
        string city;

        //Конструктор
        /// <summary>
        /// Создаёт новое метро с указанным названием города.
        /// </summary>
        public Metro(string city)
        {
            this.city = city;
        }

        //Методы
        /// <summary>
        /// Получает название города, в котором находится это метро.
        /// </summary>
        public string GetCity() => city;

        /// <summary>
        /// Добавляет ветку в метро.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="color"></param>
        public void AddLine(string name, string color)
        {
            lines.Add(new Line(name, color));
        }

        /// <summary>
        /// Удаляет ветку по указанному имени.
        /// </summary>
        public void RemoveLine(string name)
        {
            lines.Remove(lines.First(x => x.GetName() == name));//Удаляем первый элемент списка, имя котрого равно аргументу.
        }

        //Методы ниже не требовалось заполнять, но я увлёкся и сделал 2 случайно. Оставшиеся 2 я пока что оставил пустыми.
        /// <summary>
        /// Находит станции с указанным именем
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Список найденных станций на всех ветках.</returns>
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

        /// <summary>
        /// Находит станцию с указанным именем в указанной ветке.
        /// </summary>
        /// <param name="name">Имя станции.</param>
        /// <param name="lineName">Имя ветки</param>
        /// <returns></returns>
        public Station FindStation(string name, string lineName)
        {
            return lines.First(x => x.GetName() == lineName).GetStation(name);//Получаем первую ветку, имя которой равно искомому, затем ищем в ней станцию, имя которой равно заданному.
        }

        public List<Station> GetStationList()
        {
            throw new NotImplementedException();//Выбрасываем исключение, чтобы показать, что метод нереализован. Вдобавок, это избавить нас от ошибки при компиляции.
        }

        public void LoadStatonsFromFile(string filename)
        {
            
        }
    }
}
