using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubwayProject
{
    /// <summary>
    /// Станция метро. Как просили, комментирую почти каждую строчку кода (кроме присвоений полям значений аргументов функции).
    /// </summary>
    public class Station
    {
        /// <summary>
        /// Имя станции.
        /// </summary>
        string name;
        /// <summary>
        /// Цвет станции (?)
        /// </summary>
        string color;
        /// <summary>
        /// Линия, в которой находится станция.
        /// </summary>
        Line line;
        /// <summary>
        /// Указывает, имеется ли доступ для людей-инвалидов.
        /// </summary>
        bool isWheelChairAccessible;
        /// <summary>
        /// Указывает, есть ли парковка рядом (как я понял)
        /// </summary>
        bool hasParkAndRide;
        /// <summary>
        /// Указывает, есть ли рядом место для зарядки электромобилей.
        /// </summary>
        bool hasNearbyCableCar;
        /// <summary>
        /// Список станций, в которые можно приехать из данной.
        /// </summary>
        List<Station> transfers = new List<Station>();
        /// <summary>
        /// Создаёт новую станцию с указанным цветом и названием.
        /// </summary>
        /// <param name="name">Название станции.</param>
        /// <param name="color">Цвет станции.</param>
        public Station(string name, string color)
        {
            this.name = name;//задаём имя станции.
            this.color = color;//задаём цвет станции.
        }
        //Вместо List<transfer> сделал List<Station>, потому что скорее всего была опечатка, такого класса нет.
        /// <summary>
        /// Создаёт новую станцию с указанным именем, цветом и списком станций, в которые можно приехать.
        /// </summary>
        /// <param name="name">Название станции</param>
        /// <param name="color">Цвет станции</param>
        /// <param name="transfer">Список доступных веток.</param>
        public Station(string name, string color, List<Station> transfer)
        {
            this.name = name;
            this.color = color;
            transfers = transfer;
        }
        /// <summary>
        /// Получает имя станции.
        /// </summary>
        public string GetName() => name;
        /// <summary>
        /// Задаёт новое имя станции.
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name) => this.name = name;
        /// <summary>
        /// Определяет, есть ли доступ к станции для людей с коляской.
        /// </summar>
        public bool IsWheelchairAccessible() => isWheelChairAccessible;
        //2 элемента ниже не были указаны как функции, поэтому я сделал их свойствами (тем более что всё равно к этим полям толком доступа нет, им даже значения присвоить невозможно).
        /// <summary>
        /// Определяет, есть ли рядом парковка
        /// </summary>
        public bool HasParkAndRide { get => hasParkAndRide; set => hasParkAndRide = value; }
        /// <summary>
        /// Определяет, есть ли рядом место для зарядки элетромобилей.
        /// </summary>
        public bool HasNearbyCableCar { get => hasNearbyCableCar; set => hasNearbyCableCar = value; }
        /// <summary>
        /// Возвращает имя ветки.
        /// </summary>
        public string GetLineName() => line.GetName();//Получаем имя ветки данной станции и возвращаем его.
        /// <summary>
        /// Возвращает список станций, доступных с этой станции.
        /// </summary>
        public List<Station> GetTransferList() => transfers;
    }
}
