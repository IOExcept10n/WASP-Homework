using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubwayProject
{
    //Интерфейс для определения маршрута в станциях.
    interface IPoint
    {
        //Свойство для хранения следующей станции.
        public Station Next { get; set; }
        //Свойство для хранения предыдущей станции.
        public Station Previous { get; set; }
        //Свойство, указывающее, была ли станция посещена.
        public bool Visited { get; set; }
    }
}
