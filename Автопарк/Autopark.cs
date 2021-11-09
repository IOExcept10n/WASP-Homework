using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class Autopark
    {
        string name;
        List<PassengerCar> passengerCars;
        List<Truck> trucks;

        public Autopark(string name, List<PassengerCar> passengerCars, List<Truck> trucks)
        {
            this.name = name;
            this.passengerCars = passengerCars;
            this.trucks = trucks;
        }

        public override string ToString()
        {
            string result = "Autopark " + name;
            foreach (var car in passengerCars)
            {
                result += car + "\n";
            }
            foreach (var car in trucks)
            {
                result += car + "\n";
            }
            return result;
        }
    }
}
