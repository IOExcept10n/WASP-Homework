using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Restaurant
    {
        public static void Main(string[] args)
        {
            Food.Amounts.AddRange(new List<int>() { 1, 2, 3, 5, 10 });
            Drink.Volumes.AddRange(new List<double>() { 0.33, 0.5, 1, 1.5, 2 });
            List<Item> items = new();
            Item.AddItem(items, new Food("Котлета с макаронами", 2.33, 2));
            Item.AddItem(items, new Drink("Вода", 0.99, 0.5));
            Item.AddItem(items, new Food("Шашлык", 6.85, 3));
            try
            {
                Item.AddItem(items, new Drink("Сок", 1.75, 1.2));
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
