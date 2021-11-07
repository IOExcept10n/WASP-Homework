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
        //Поле, хранящее cписок станций на этой ветке.
        List<Station> stations;

        
        //Поле, хранящее имя этой ветки.
        
        string name;

        
        //Поле, хранящее цвет этой ветки.
        
        ConsoleColor color;

        //Конструктор
        // Создаёт новую ветку с указанным именем и цветом.
        //name - имя, color - цвет
        public Line(string name, ConsoleColor color)
        {
            stations = new List<Station>();
            this.name = name;
            this.color = color;
        }

        // Свойство, предоставляющее доступ к имени
        public string Name { get => name; set => name = value; }

        //Свойство, предоставляющее доступ к цвету.
        public ConsoleColor Color { get => color; set => color = value; }

        //======Методы класса========


        //Получает станцию по указанному имени.
        public Station GetStation(string name) => stations.FirstOrDefault(x => x.Name == name);//Получаем первый элемент списка, имя которого совпадает с аргументом метода. FirstOrDefault возвращает null, если целевой объект не найден, а это как раз то, что нужно.
        
        // Добавляет новую станцию к ветке.
        
        public void AddStation(string name, ConsoleColor color)
        {
            stations.Add(new Station(name, color) { line = this });//Добавляем новую станцию в список.
        }

        
        // Добавляет новую станцию к ветке.
        
        public void AddStation(string name, ConsoleColor color, List<Station> transfers)
        {
            stations.Add(new Station(name, color, transfers) { line = this });//аналогично альтернативной перегрузке.
        }

        
        // Удаляет станцию с указанным именем из ветки.
        
        public void RemoveStation(string name)
        {
            stations.Remove(stations.First(x => x.Name == name));//Здесь не буду делать через firstordefault, потому что в случае, если не будет найден элемент, исключение выбросит 100%.
            //В общем, удаляю из списка первый элемент, удовлетворяющий условию.
        }

        
        // Находит станцию с указанным именем.
        
        public Station FindStationByName(string name)
        {
            return GetStation(name);
        }

        public virtual void PrintLine()
        {
            Console.ForegroundColor = Color;
            string ret = $"Name: \'{Name}\'; Stations: \n";
            stations.ForEach(x => ret += $" --- {x};\n");
            Console.WriteLine(ret);
            Console.ResetColor();
        }
        
        // Находит список станций, доступных из станции по указанному имени.
        public List<Station> GetStationList(string name)
        {
            return GetStation(name).TransferList;//Получаем трансферный список станции по заданному имени.
        }
        //Метод, возвращает список всех станций данной линии.
        public List<Station> GetStationList() => stations;
    }
}
