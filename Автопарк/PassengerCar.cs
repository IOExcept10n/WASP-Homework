using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class PassengerCar : Car
    {
        protected int numOfPassengers;

        protected Dictionary<string, int> repairBook;

        public PassengerCar(string label, int power, int year, int passengers, Dictionary<string, int> repairBook) : base(label, power, year)
        {
            numOfPassengers = passengers;
            this.repairBook = repairBook;
        }

        public void AddReapirComponent(string name, int year)
        {
            repairBook.Add(name, year);
        }

        public void PrintRepairBook()
        {
            Console.WriteLine($"Repair book for car {label} {creationYear} year of make:");
            foreach (var c in repairBook)
            {
                Console.WriteLine($"* Component name: {c.Key}, year: {c.Value}");
            }
        }

        public int GetYearOrRepairByName(string name)
        {
            repairBook.TryGetValue(name, out int year);
            return year;
        }

        public override string ToString()
        {
            return $"Passenger car: [label: {label}, power: {power}, creation year: {creationYear}, passengers: {numOfPassengers}]";
        }
    }
}
