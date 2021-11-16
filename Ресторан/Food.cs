using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class Food : Item
    {
        int amount;

        static List<int> amounts = new List<int>();

        public int Amount => amount;

        public static List<int> Amounts => amounts;

        public Food(string name, double price, int amount) : base(name, price)
        {
            this.amount = amount;
        }

        public override double Price { get => price * amount * (1 + ValueAddedTax / 100.0); set => base.Price = value; }
    }
}
