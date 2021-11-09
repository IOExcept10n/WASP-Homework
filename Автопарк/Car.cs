using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class Car
    {
        protected string label;
        protected int power;
        protected int creationYear;

        public Car(string label, int power, int creationYear)
        {
            this.label = label;
            this.power = power;
            this.creationYear = creationYear;
        }

        public Car()
        {

        }
    }
}
