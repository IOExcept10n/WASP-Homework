using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class Truck : Car
    {
        protected int maxWeight;
        protected string driverName;
        protected Dictionary<string, int> currentCargo;

        public Truck(string label, int power, int year, int maxWeight, string driverName, Dictionary<string, int> cargo) : base(label, power, year)
        {
            this.maxWeight = maxWeight;
            this.driverName = driverName;
            currentCargo = cargo;
        }

        public string Driver { set => driverName = value; }

        public void AddCargo(string name, int weight)
        {
            currentCargo.Add(name, weight);
            if (currentCargo.Sum(x => x.Value) > maxWeight) throw new ArgumentException("Превышена грузоподъёмность.", "weight");//Чтобы просто так переменная не болталась. Всё-таки не зря же сделали лимит грузоподъёмности.
        }

        public void RemoveCargo(string name)
        {
            currentCargo.Remove(name);
        }

        public void PrintCargo()
        {
            Console.WriteLine($"Cargo list for truck {label} {creationYear} year of make:");
            foreach (var c in currentCargo)
            {
                Console.WriteLine($"* Cargo name: {c.Key}, weight: {c.Value}");
            }
        }

        public override string ToString()
        {
            return $"Truck: [label: {label}, power: {power}, creation year: {creationYear}, weight limit: {maxWeight}, driver name: {driverName}]";
        }
    }
}
