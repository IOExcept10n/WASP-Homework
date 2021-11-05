using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubwayProject
{
    /// <summary>
    /// Класс, представляющий ветку метро.
    /// </summary>
    public class Line
    {
        //Поля класса
        /// <summary>
        /// Список станций на этой ветке.
        /// </summary>
        List<Station> stations;

        /// <summary>
        /// Имя этой ветки.
        /// </summary>
        string name;

        /// <summary>
        /// Цвет этой ветки.
        /// </summary>
        string color;

        //Конструктор
        /// <summary>
        /// Создаёт новую ветку с указанным именем и цветом.
        /// </summary>
        /// <param name="name">Имя ветки.</param>
        /// <param name="color">Цвет ветки.</param>
        public Line(string name, string color)
        {
            stations = new List<Station>();
            this.name = name;
            this.color = color;
        }

        //Методы класса
        /// <summary>
        /// Получает станцию по указанному имени.
        /// </summary>
        /// <param name="name">Название искомой станции</param>
        /// <returns>Станция по указанному имени либо null, если станция не была найдена.</returns>
        public Station GetStation(string name) => stations.FirstOrDefault(x => x.GetName() == name);//Получаем первый элемент списка, имя которого совпадает с аргументом метода.

        /// <summary>
        /// Получает имя ветки.
        /// </summary>
        public string GetName() => name;

        /// <summary>
        /// Задаёт имя ветки.
        /// </summary>
        public void SetName(string name) => this.name = name;

        /// <summary>
        /// Получает цвет ветки.
        /// </summary>
        public string GetColor() => color;

        /// <summary>
        /// Задаёт цвет ветки.
        /// </summary>
        public void SetColor(string color) => this.color = color;

        /// <summary>
        /// Добавляет новую станцию к ветке.
        /// </summary>
        public void AddStation(string name, string color)
        {
            stations.Add(new Station(name, color));//Добавляем новую станцию в список.
        }

        /// <summary>
        /// Добавляет новую станцию к ветке.
        /// </summary>
        public void AddStation(string name, string color, List<Station> transfers)
        {
            stations.Add(new Station(name, color, transfers));//аналогично альтернативной перегрузке.
        }

        /// <summary>
        /// Удаляет станцию с указанным именем из ветки.
        /// </summary>
        public void RemoveStation(string name)
        {
            stations.Remove(stations.First(x => x.GetName() == name));//Здесь не буду делать черещ firstordefault, потому что в случае, если не будет найден элемент, исключение выбросит 100%.
            //В общем, удаляю из списка первый элемент, удовлетворяющий условию.
        }

        /// <summary>
        /// Находит станцию с указанным именем.
        /// </summary>
        public Station FindStationByName(string name)
        {
            return GetStation(name);
        }

        /// <summary>
        /// Находит список станций, доступных из станции по указанному имени.
        /// </summary>
        /// <param name="name">Имя станции, по которому нужно искать список.</param>
        public List<Station> GetStationList(string name)
        {
            return GetStation(name).GetTransferList();//Получаем трансферный список станции по заданному имени.
        }
    }
}
