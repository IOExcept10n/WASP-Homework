using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class Item
    {
        protected string name;
        protected double price;
        static int valueAddedTax;

        public virtual double Price { get => price; set => price = value; }

        public static int ValueAddedTax { get; set; }

        public Item()
        {

        }

        public Item(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

        public static void AddItem(List<Item> items, Item item)
        {
            if (item is Drink)
            {
                Drink d = (Drink)item;
                if (Drink.Volumes.Contains(d.Volume)) items.Add(d);
                else
                {
                    throw new ArgumentException($"Такого объёма напитка ({d.Volume}) не существует");
                }
            }
            else
            {
                Food f = (Food)item;
                if (Food.Amounts.Contains(f.Amount)) items.Add(f);
                else
                {
                    throw new ArgumentException($"Такого количества продукта ({f.Amount}) не существует");
                }
            }
        }

        public override string ToString()
        {
            return $"Name: {name}, total price: {Price}";
        }
    }
}
