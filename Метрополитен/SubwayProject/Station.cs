using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubwayProject
{
    //Класс станции метро.
    public class Station
    {
        //Это всё поля класса
        //Поле, обозначающее имя станции
        string name;

        //Поле, обозначающее цвет
        string color;

        //Поле, обозначающее линию, на которой находится станция.
        Line line;

        //Поле, обозначающее доступ к станции для инвалидов-колясочников
        bool isWheelChairAccessible;

        //Поле, обозначающее, есть ли рядом парковка (вроде бы)
        bool hasParkAndRide;

        //Поле, обозначающее, есть ли рядом возможность зарядить электромобиль
        bool hasNearbyCableCar;

        //Поле, хранящее список станций, в которые можно приехать из данной
        List<Station> transfers = new List<Station>();//Сразу добавлю инициализатор в месте объявления станции.

        //Дальше идут 2 конструктора
        //Первый конструктор создаёт новую станцию с указанным цветом и названием.
        //name - название, color - цвет
        public Station(string name, string color)
        {
            this.name = name;//задаём имя станции.
            this.color = color;//задаём цвет станции.
        }

        //Второй конструктор создаёт новую станцию с указанным именем, цветом и списком станций, в которые можно приехать.
        //name - Название станции
        //color - Цвет станции
        //transfer - Список доступных веток.
        public Station(string name, string color, List<Station> transfer)
        {
            this.name = name;//Задаём полю name значение параметра name.
            this.color = color;//Задаём значение полю color
            transfers = transfer;//Задаём значение полю transfers
        }
        /*
         * По сути, запись => заменяет {}, но работает только в 1 строчку. Для удобства я буду использовать её
         * */
        //Этот метод получает имя станции.
        public string GetName() => name;

        //Метод, задаёт новое имя станции.
        public void SetName(string name) => this.name = name;

        //Метод, определяющий, есть ли доступ к станции для людей с коляской.
        public bool IsWheelchairAccessible() => isWheelChairAccessible;

        
        // Метод, определяющий, есть ли рядом парковка
        public bool HasParkAndRide() => hasParkAndRide;

        // Метод, определяет, есть ли рядом место для зарядки элетромобилей.
        public bool HasNearbyCableCar() => hasNearbyCableCar;

        // Метод GetLineName возвращает имя ветки.
        public string GetLineName() => line.GetName();//Получаем имя ветки данной станции и возвращаем его.

        // Метод, возвращает список станций, доступных с этой станции.
        public List<Station> GetTransferList() => transfers;//Возвращаем список доступных станций.
    }
}
