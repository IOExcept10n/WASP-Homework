using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class Drink : Item
    {
        double volume;

        static List<double> volumes = new List<double>();

        public double Volume => volume;

        public static List<double> Volumes => volumes;

        public Drink(string name, double price, double volume) : base(name, price)
        {
            this.volume = volume;
        }

        public override double Price { get => price * volume * (1 + ValueAddedTax / 100.0); set => base.Price = value; }
    }
}
