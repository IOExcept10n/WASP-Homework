using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubwayProject
{
    public class DiameterLine : Line
    {
        public DiameterLine(string name, ConsoleColor color) : base(name, color)
        {

        }

        public override void PrintLine()
        {
            Console.ForegroundColor = Color;
            Console.Write("Diameter line, ");
            base.PrintLine();
        }

    }
}
