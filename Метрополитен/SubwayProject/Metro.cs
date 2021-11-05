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
        /// <summary>
        /// Список веток данного метро.
        /// </summary>
        List<Line> lines;
        /// <summary>
        /// Название города, в котром находится метро.
        /// </summary>
        string city;
        /// <summary>
        /// Создаёт новое метро с указанным названием города.
        /// </summary>
        public Metro(string city)
        {
            this.city = city;
        }
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
        /// <summary>
        /// Находит станции с указанным именем
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Список найденных станций на всех ветках.</returns>
        public List<Station> FindStation(string name)
        {
            List<Station> foundResults = new List<Station>();
            foreach (Line line in lines)
            {
                Station result = line.GetStation(name);
                if (result != null) foundResults.Add(result);
            }
            return foundResults;
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
            throw new NotImplementedException();
        }

        public void LoadStatonsFromFile(string filename)
        {
            throw new NotImplementedException();
        }
    }
}
