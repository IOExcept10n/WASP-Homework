using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubwayProject
{
    
    // Класс, представляющий ветку метро.
    
    public class Line
    {
        //Поля класса
        //Поле, хранящее писок станций на этой ветке.
        List<Station> stations;

        
        //Поле, хранящее имя этой ветки.
        
        string name;

        
        //Поле, хранящее цвет этой ветки.
        
        string color;

        //Конструктор
        // Создаёт новую ветку с указанным именем и цветом.
        //name - имя, color - цвет
        public Line(string name, string color)
        {
            stations = new List<Station>();
            this.name = name;
            this.color = color;
        }

        //======Методы класса========


        //Получает станцию по указанному имени.
        public Station GetStation(string name) => stations.FirstOrDefault(x => x.GetName() == name);//Получаем первый элемент списка, имя которого совпадает с аргументом метода. FirstOrDefault возвращает null, если целевой объект не найден, а это как раз то, что нужно.

        
        // Получает имя ветки.
        public string GetName() => name;

        
        // Задаёт имя ветки.
        public void SetName(string name) => this.name = name;

        
        // Получает цвет ветки.
        public string GetColor() => color;

        
        // Задаёт цвет ветки.
        
        public void SetColor(string color) => this.color = color;

        
        // Добавляет новую станцию к ветке.
        
        public void AddStation(string name, string color)
        {
            stations.Add(new Station(name, color));//Добавляем новую станцию в список.
        }

        
        // Добавляет новую станцию к ветке.
        
        public void AddStation(string name, string color, List<Station> transfers)
        {
            stations.Add(new Station(name, color, transfers));//аналогично альтернативной перегрузке.
        }

        
        // Удаляет станцию с указанным именем из ветки.
        
        public void RemoveStation(string name)
        {
            stations.Remove(stations.First(x => x.GetName() == name));//Здесь не буду делать черещ firstordefault, потому что в случае, если не будет найден элемент, исключение выбросит 100%.
            //В общем, удаляю из списка первый элемент, удовлетворяющий условию.
        }

        
        // Находит станцию с указанным именем.
        
        public Station FindStationByName(string name)
        {
            return GetStation(name);
        }

        
        // Находит список станций, доступных из станции по указанному имени.
        public List<Station> GetStationList(string name)
        {
            return GetStation(name).GetTransferList();//Получаем трансферный список станции по заданному имени.
        }
    }
}
