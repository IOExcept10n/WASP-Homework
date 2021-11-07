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
        protected string name;

        //Поле, обозначающее цвет
        protected ConsoleColor color;

        //Поле, обозначающее линию, на которой находится станция.
        protected internal Line line;

        //Поле, обозначающее доступ к станции для инвалидов-колясочников
        protected bool isWheelChairAccessible;

        //Поле, обозначающее, есть ли рядом парковка (вроде бы)
        protected bool hasParkAndRide;

        //Поле, обозначающее, есть ли рядом возможность зарядить электромобиль
        protected bool hasNearbyCableCar;

        //Поле, хранящее список станций, в которые можно приехать из данной
        protected List<Station> transfers = new();//Сразу добавлю инициализатор в месте объявления станции.

        //Дальше идут 2 конструктора
        //Первый конструктор создаёт новую станцию с указанным цветом и названием.
        //name - название, color - цвет
        public Station(string name, ConsoleColor color, params string[] info)
        {
            this.name = name;//задаём имя станции.
            this.color = color;//задаём цвет станции.
            if (info.Length > 0) IsWheelChairAccessible = Convert.ToBoolean(info[0]);//Если есть хотя бы 1 элемент в info, присваиваем значение iswheelchairaccessible
            if (info.Length > 1) HasParkAndRide = Convert.ToBoolean(info[1]);//Если больше одного, присваиваем следующему свойству
            if (info.Length > 2) hasNearbyCableCar = Convert.ToBoolean(info[2]);//Если больше двух, присваиваем последнему свойству.
        }

        //Второй конструктор создаёт новую станцию с указанным именем, цветом и списком станций, в которые можно приехать.
        //name - Название станции
        //color - Цвет станции
        //transfer - Список доступных веток.
        public Station(string name, ConsoleColor color, List<Station> transfer, params string[] info) : this(name, color, info)//Делаем то же самое, что и в другом конструкторе.
        {
            transfers = transfer;//Задаём значение полю transfers
        }
        /*
         * По сути, запись => заменяет {}, но работает только в 1 строчку. Для удобства я буду использовать её
         * */
        //Свойство, указывающее имя станции. 
        public string Name { get => name; set => name = value; }

        //Свойство, определяющее, есть ли доступ к станции для людей с коляской.
        public bool IsWheelChairAccessible { get => isWheelChairAccessible; set => isWheelChairAccessible = value; }
        //Свойство, получающее цвет станции. Нужно для красивого вывода в задании.
        public ConsoleColor Color { get => color; }
        // Свойство, определяющее, есть ли рядом парковка
        public bool HasParkAndRide { get => hasParkAndRide; set => hasParkAndRide = value; }

        // Свойство, определяет, есть ли рядом место для зарядки элетромобилей.
        public bool HasNearbyCableCar { get => hasNearbyCableCar; set => hasNearbyCableCar = value; }

        // Свойство LineName возвращает имя ветки.
        public string LineName { get => line.Name; }//Получаем имя ветки данной станции и возвращаем его.

        // Свойство, возвращает список станций, доступных с этой станции.
        public List<Station> TransferList => transfers;//Возвращаем список доступных станций. 

        public override string ToString()
        {
            /*wheel access: {isWheelChairAccessible}, park: {hasParkAndRide}, cable car: {HasNearbyCableCar}*/
            return $"[{Name}, transit length: {transfers.Count}]";
        }
    }
}
